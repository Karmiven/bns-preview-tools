﻿using System.Diagnostics;
using System.IO;
using System.Text;

namespace Xylia.Match.Util.Writer
{
	/// <summary>
	/// 用于显示消息来源函数
	/// </summary>
	public class DebugWriter : TextWriter
	{
		public override Encoding Encoding => Encoding.UTF8;

		public override void WriteLine(string value)
		{
			Debug.WriteLine(new StackTrace().GetFrame(3).GetMethod() + "  " + value);
		}
	}
}