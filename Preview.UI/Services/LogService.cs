﻿using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xylia.Preview.UI.ViewModels;

namespace Xylia.Preview.UI.Services;
internal class LogService : TextWriter, IService
{
	#region IService
	public bool Register()
	{
		// If output directory exists, register the service
		if (Directory.Exists(UserSettings.Default.OutputFolder))
		{
			var foloder = UserSettings.Default.OutputFolder;
			string template = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message:lj}{NewLine}{Exception}";
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Debug(LogEventLevel.Warning, outputTemplate: template)
				.WriteTo.File(Path.Combine(foloder, "Logs", $"{DateTime.Now:yyyy-MM-dd}.log"), outputTemplate: template)
				.CreateLogger();

			return true;
		}

		return false;
	}
	#endregion

	#region Redirect
	public override Encoding Encoding => Encoding.UTF8;

	public override void WriteLine(string? value)
	{
		// base.WriteLine(value);
		Debug.WriteLine(value);
	}
	#endregion
}