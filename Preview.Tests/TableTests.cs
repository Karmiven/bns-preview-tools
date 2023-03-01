using System;
using System.Data;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Tests
{
	[TestClass]
	public class TableTests
	{
		//[TestMethod]
		[DataRow("TrainDesc.Trait_Summoner_base_3_01")]
		public void Text(string alias)
		{
			var table = FileCache.Data.TextData;
			var record = table[alias];

			Console.WriteLine(record);
			Console.WriteLine(record.GetText());
		}

		//[TestMethod]
		[DataRow("Bard_G1_Var_1")]
		public void ContextScript(string alias)
		{
			var table = FileCache.Data.ContextScript;
			var record = table[alias];

			record.Test();
		}

		//[TestMethod]
		[DataRow(1931)]
		public void Quest(int id)
		{
			var table = FileCache.Data.Quest;
			var record = table[id];

			Console.WriteLine(record);
			Console.WriteLine(record.XmlInfo());
		}
		
		//[TestMethod]
		public void Category()
		{
			foreach (var seq in Enum.GetValues<MarketCategory2Seq>())
			{
				if (seq == MarketCategory2Seq.None) continue;

				Console.WriteLine($"Name.item.game-category-2.{seq.GetSignal()}".GetText());
			}

			Console.WriteLine();
			foreach (var seq in Enum.GetValues<MarketCategory3Seq>())
			{
				if (seq == MarketCategory3Seq.None) continue;

				Console.WriteLine($"Name.item.game-category-3.{seq.GetSignal()}".GetText());
			}
		}


		[TestMethod]
		public void RecordTest()
		{
			BaseRecord text1 = new() { alias = "123" };
			BaseRecord text2 = new() { alias = "123" };

			Console.WriteLine(text1 == text2);
		}
	}
}