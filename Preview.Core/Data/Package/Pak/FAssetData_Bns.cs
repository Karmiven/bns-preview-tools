using System.Collections.Generic;

using CUE4Parse.UE4.AssetRegistry.Readers;
using CUE4Parse.UE4.Objects.UObject;


namespace CUE4Parse.UE4.AssetRegistry.Objects
{
	public class FAssetData_Bns
	{
		public FName ObjectPath;
		public FName PackagePath;
		public FName AssetClass;
		public FName PackageName;
		public FName AssetName;
		public IDictionary<FName, string> TagsAndValues;
		public FAssetBundleData TaggedAssetBundles;
		public int[] ChunkIDs;
		public uint[] PackageFlags;


		public readonly long[] ChunkIDs2;
		public readonly string ObjectPath2;

		public FAssetData_Bns(FAssetRegistryArchive Ar, bool Simple = false)
		{
			ObjectPath = Ar.ReadFName();
			PackagePath = Ar.ReadFName();
			AssetClass = Ar.ReadFName();
			PackageName = Ar.ReadFName();
			AssetName = Ar.ReadFName();

			this.SerializeTagsAndBundles(Ar, Simple);

			ChunkIDs2 = Ar.ReadArray<long>();
			ObjectPath2 = Ar.ReadFString();
		}


		public void SerializeTagsAndBundles(FAssetRegistryArchive Ar, bool Simple)
		{
			int num = Ar.Read<int>();
			Dictionary<FName, string> dictionary = new Dictionary<FName, string>();
			for (int i = 0; i < num; i++)
			{
				if (!Simple) dictionary[Ar.ReadFName()] = Ar.ReadFString();
				else
				{
					Ar.Position += 8;

					int Length = Ar.Read<int>();
					Ar.Position += Length > 0 ? Length : -Length * 2;
				}
			}

			this.TagsAndValues = dictionary;
			this.TaggedAssetBundles = new FAssetBundleData();
		}
	}
}