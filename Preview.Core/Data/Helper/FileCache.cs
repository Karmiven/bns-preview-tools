using Xylia.Preview.Data.Helper;
using Xylia.Preview.Data.Package.Pak;

public static class FileCache
{
	public static DataTableSet Data = new();

	public static PakData PakData = new();


	public static void Clear()
	{
		Data?.Dispose();
		Data = new();

		PakData?.Dispose();
		PakData = new();
	}
}