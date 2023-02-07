using System;

using CUE4Parse.UE4.AssetRegistry.Objects;
using CUE4Parse.UE4.AssetRegistry.Readers;
using CUE4Parse.UE4.Readers;

using Newtonsoft.Json;

namespace CUE4Parse.UE4.AssetRegistry
{
	[JsonConverter(typeof(FAssetRegistryStateConverter))]
	public class FAssetRegistryState_Bns
	{
		public FAssetData_Bns[] PreallocatedAssetDataBuffers;

		public FAssetRegistryState_Bns(FArchive Ar)
		{
			FAssetRegistryVersion.TrySerializeVersion(Ar, out var version);
			var nameTableReader = new FNameTableArchiveReader(Ar,null);
			Load(nameTableReader, version);

			Ar.Dispose();
			GC.Collect();
		}

		private void Load(FAssetRegistryArchive Ar, FAssetRegistryVersionType version)
		{
			PreallocatedAssetDataBuffers = Ar.ReadArray(() => new FAssetData_Bns(Ar, true));
		}
	}
}