using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;
using Xylia.bns.Modules.Quest.Enums;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	[Signal("mission-step")]
	public class MissionStep : BaseNode
	{
		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<Mission> Missions = new();

		[FStruct(StructType.Meta)]
		public MissionStepSuccess MissionStepSuccess;

		[FStruct(StructType.Meta)]
		public MissionStepFail MissionStepFail;
		#endregion

		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Missions = BaseNode.LoadChildren<Mission>(xe, "mission");
			this.MissionStepSuccess = BaseNode.LoadChildren<MissionStepSuccess>(xe, "mission-step-success").FirstOrDefault();
			this.MissionStepFail = BaseNode.LoadChildren<MissionStepFail>(xe, "mission-step-fail").FirstOrDefault();
		}
		#endregion



		#region 共同字段
		/// <summary>
		/// 步骤编号
		/// </summary>
		public byte id;

		[Signal("completion-type")]
		public OpCheck CompletionType;

		[Signal("giveup-warp-to-pcspawn")]
		public string GiveupWarpToPcSpawn;

		[Signal("giveup-zone-1")] public string GiveupZone1;
		[Signal("giveup-zone-2")] public string GiveupZone2;
		[Signal("giveup-zone-3")] public string GiveupZone3;

		[Signal("progress-talksocial")]
		public string ProgressTalkSocial;

		[Signal("progress-talksocial-delay")]
		public float ProgressTalkSocialDelay;

		/// <summary>
		/// 指示是否废弃步骤
		/// </summary>
		public bool Retired;

		[Signal("skip-dest-mission-step")]
		public bool SkipDestMissionStep;

		[Signal("time-limit-type")]
		public TimeLimitType TimeLimitType;

		[Signal("time-limit")]
		public short TimeLimit;

		public bool Hide;

		[Signal("mission-map-type")]
		public MissionMapType MissionMapType;



		[Side(Side.Type.Client)]
		public string Desc;

		[Side(Side.Type.Client)]
		[Signal("guide-message-category")]
		public GuideMessageCategory GuideMessageCategory;

		[Side(Side.Type.Client)]
		[Signal("guide-message")]
		public string GuideMessage;

		[Side(Side.Type.Client)]
		[Signal("guide-message-zone-1")]
		public string GuideMessageZone1;

		[Side(Side.Type.Client)]
		[Signal("guide-message-zone-2")]
		public string GuideMessageZone2;

		[Side(Side.Type.Client)]
		[Signal("location-x")]
		public float LocationX;

		[Side(Side.Type.Client)]
		[Signal("location-y")]
		public float LocationY;

		[Side(Side.Type.Client)]
		public string Map;

		[Obsolete]
		[Side(Side.Type.Client)]
		[Signal("map-zoom-rate")]
		public string MapZoomRate;


		[Side(Side.Type.Client)]
		[Signal("enable-navigation")]
		public bool EnableNavigation;

		/// <summary>
		/// 使用自动导航
		/// </summary>
		[Side(Side.Type.Client)]
		[Signal("use-auto-navigation")]
		public bool UseAutoNavigation;




		[Side(Side.Type.Server)]
		[Signal("quest-decision")] 
		public string QuestDecision;
		
		[Side(Side.Type.Server)] 
		[Signal("zone-1")] 
		public string Zone1;

		[Side(Side.Type.Server)] 
		[Signal("zone-2")] 
		public string Zone2;

		[Side(Side.Type.Server)] 
		[Signal("skip-quest-decision")] 
		public string SkipQuestDecision;

		[Side(Side.Type.Server)] 
		[Signal("skip-quest-decision-zone")] 
		public string SkipQuestDecisionZone;

		[Side(Side.Type.Server)]
		public RollBack RollBack;
		#endregion
	}
}
