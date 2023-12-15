﻿using Xylia.Preview.Data.Models;

namespace Xylia.Preview.Data.Client;
/// <summary>
/// Basic query pipe workflow - support filter, includes and orderby
/// </summary>
internal class QueryPipe : BasePipe
{
	public override IEnumerable<AttributeDocument> Pipe(IEnumerable<Record> records, QueryPlan query)
	{                          
		// starts pipe loading document
		var source = this.LoadDocument(records);

		// do includes in result before filter
		foreach (var path in query.IncludeBefore)
		{
			source = this.Include(source, path);
		}

		// filter results according expressions
		foreach (var expr in query.Filters)
		{
			source = this.Filter(source, expr);
		}

		if (query.OrderBy != null)
		{
			// pipe: orderby with offset+limit
			source = this.OrderBy(source, query.OrderBy.Expression, query.OrderBy.Order, query.Offset, query.Limit);
		}
		else
		{
			// pipe: apply offset (no orderby)
			if (query.Offset > 0) source = source.Skip(query.Offset);

			// pipe: apply limit (no orderby)
			if (query.Limit < int.MaxValue) source = source.Take(query.Limit);
		}

		// do includes in result after filter
		foreach (var path in query.IncludeAfter)
		{
			source = this.Include(source, path);
		}

		// if is an aggregate query, run select transform over all resultset - will return a single value
		if (query.Select.All)
		{
			return this.SelectAll(source, query.Select.Expression);
		}
		// run select transform in each document and return a new document or value
		else
		{
			return this.Select(source, query.Select.Expression);
		}
	}

	/// <summary>
	/// Pipe: Transaform final result appling expressin transform. Can return document or simple values
	/// </summary>
	private IEnumerable<AttributeDocument> Select(IEnumerable<AttributeDocument> source, BsonExpression select)
	{
		var defaultName = select.DefaultFieldName();

		foreach (var doc in source)
		{
			var value = select.ExecuteScalar(doc);

			if (value.IsDocument)
			{
				yield return value.AsDocument;
			}
			else
			{
				yield return new AttributeDocument { [defaultName] = value };
			}
		}
	}

	/// <summary>
	/// Pipe: Run select expression over all recordset
	/// </summary>
	private IEnumerable<AttributeDocument> SelectAll(IEnumerable<AttributeDocument> source, BsonExpression select)
	{
		var defaultName = select.DefaultFieldName();
		var result = select.Execute(source);

		foreach (var value in result)
		{
			if (value.IsDocument)
			{
				yield return value.AsDocument;
			}
			else
			{
				yield return new AttributeDocument() { [defaultName] = value };
			}
		}
	}
}