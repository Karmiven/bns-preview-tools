﻿using System.Runtime.InteropServices;
using Xylia.Preview.Data.Engine.BinData.Models;
using Xylia.Preview.Data.Models;

namespace Xylia.Preview.Data.Engine.BinData.Serialization;
internal class TableArchive
{
	private readonly RecordCompressedReader _recordCompressedReader;
	private readonly RecordUncompressedReader _recordUncompressedReader;
	private DataArchive Source;

	public TableArchive(
		RecordCompressedReader recordCompressedReader = null,
		RecordUncompressedReader recordUncompressedReader = null)
	{
		_recordUncompressedReader = recordUncompressedReader ?? new RecordUncompressedReader();
		_recordCompressedReader = recordCompressedReader ?? new RecordCompressedReader();
	}

	public static Table LazyLoad(DataArchive reader)
	{
		var table = new Table() { IsBinary = true };
		var tableStart = reader.Position;
		table.ReadHeaderFrom(reader);
		table.Archive = new TableArchive() { Source = reader.OffsetedSource(tableStart, table.Size + 11), };
		reader.Seek(table.Size - 1, SeekOrigin.Current);

		return table;
	}

	public Stream LazyStream() => Source.CreateStream();

	public void ReadFrom(Table table)
	{
		table.ReadHeaderFrom(Source);

		if (table.IsCompressed) ReadCompressed(Source, table);
		else ReadUncompressed(Source, table);
	}

	private unsafe void ReadCompressed(DataArchive reader, Table table)
	{
		var records = new List<Record>();

		if (!_recordCompressedReader.Initialize(reader, reader.Is64Bit))
			throw new Exception("Failed to initialize compressed record reader");

		var rowMemory = new RecordMemory();

		while (_recordCompressedReader.Read(reader, ref rowMemory))
		{
			var buffer = new byte[rowMemory.DataSize];
			var stringBuffer = new byte[rowMemory.StringBufferSize];
			Marshal.Copy((nint)rowMemory.DataBegin, buffer, 0, rowMemory.DataSize);
			Marshal.Copy((nint)rowMemory.StringBufferBegin, stringBuffer, 0, rowMemory.StringBufferSize);

			var row = new Record
			{
				Owner = table,
				Data = buffer,
				StringLookup = new StringLookup { IsPerTable = false, Data = stringBuffer },
			};

			records.Add(row);
		}

		// sort
		table.Records = [.. records.OrderBy(x => x.PrimaryKey)];
	}

	private unsafe void ReadUncompressed(DataArchive reader, Table table)
	{
		var records = new List<Record>();

		if (!_recordUncompressedReader.Initialize(reader,
			reader.Is64Bit && !table.IsCompressed && table.ElementCount == 1))
			throw new Exception("Failed to initialize uncompressed record reader");

		var rowMemory = new RecordMemory();
		var stringLookup = new StringLookup { IsPerTable = true };

		while (_recordUncompressedReader.Read(reader, ref rowMemory))
		{
			// 255 0 255 255 6 0
			// XmlNodeType = -1	 SubclassType = -1	DataSize=6
			if (rowMemory.DataSize == 6) continue;

			var row = new Record
			{
				Owner = table,
				Data = new byte[rowMemory.DataSize],
				StringLookup = stringLookup
			};

			Marshal.Copy((nint)rowMemory.DataBegin, row.Data, 0, rowMemory.DataSize);
			records.Add(row);
		}

		table.RecordCountOffset = _recordUncompressedReader.GetRecordCountOffset();

		if (rowMemory.StringBufferBegin != null)
		{
			var stringBuffer = new byte[rowMemory.StringBufferSize];
			Marshal.Copy((nint)rowMemory.StringBufferBegin, stringBuffer, 0, rowMemory.StringBufferSize);

			stringLookup.Data = stringBuffer;
		}

		_recordUncompressedReader.GetPadding(out var padding);
		if (padding.Length > 0)
			table.Padding = padding.ToArray();

		table.Records = records;

#if DEVELOP
		if (table.RecordCountOffset != 0)
		{
			System.Diagnostics.Debug.WriteLine($"RecordCountOffset {table.Name ?? table.Type.ToString()}");
		}
#endif
	}
}