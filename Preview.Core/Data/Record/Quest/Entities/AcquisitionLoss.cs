﻿using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData
{
	/// <summary>
	/// 接取任务时失去
	/// </summary>
	[Signal("acquisition-loss")]
	public class AcquisitionLoss : CompletionLoss
	{

	}
}
