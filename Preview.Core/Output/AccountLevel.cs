namespace Xylia.Preview.Output
{
	public sealed class AccountLevel : OutBase
	{
		protected override void CreateData()
		{
			#region Title
			this.ExcelInfo.SetColumn("", 10);
			#endregion

			foreach (var record in FileCache.Data.AccountLevel)
			{
				var row = this.ExcelInfo.CreateRow();
				
			}
		}
	}
}