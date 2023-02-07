using System.Collections.Generic;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.GameUI.Scene.Game_QuestJournal;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class QuestReward : BaseRecord
	{
		#region 属性字段
		public bool QuestFirstProgress => this.Attributes["quest-first-progress"].ToBool();
		public int BasicProductionExp => this.Attributes["basic-production-exp"].ToInt();
		public int BasicFactionReputation => this.Attributes["basic-faction-reputation"].ToInt();
		public int BasicMoney => this.Attributes["basic-money"].ToInt();
		public int BasicExp => this.Attributes["basic-exp"].ToInt();
		public int BasicAccountExp => this.Attributes["basic-account-exp"].ToInt();
		public int BasicDuelPoint => this.Attributes["basic-duel-point"].ToInt();
		public int BasicPartyBattlePoint => this.Attributes["basic-party-battle-point"].ToInt();
		public int BasicFieldPlayPoint => this.Attributes["basic-field-play-point"].ToInt();
		#endregion


		#region 结构字段
		public bool FinalReward = true;

		public byte Step = 0;

		/// <summary>
		/// 固定奖励
		/// </summary>
		public List<RewardGroup> Fixeds
		{
			get
			{
				var Result = new List<RewardGroup>();
				for (int i = 1; i <= 16; i++)
				{
					if (!this.ContainsAttribute($"fixed-{i}-slot-1", out _)) break;
					 Result.Add(new RewardGroup(this.Attributes, $"fixed-{i}"));
				}

				return Result;
			}
		}

		/// <summary>
		/// 可选奖励
		/// </summary>
		public List<RewardGroup> Optionals
		{
			get
			{
				var Result = new List<RewardGroup>();
				for (int i = 1; i <= 16; i++)
				{
					if (!this.ContainsAttribute($"optional-{i}-slot-1", out _)) break;
					 Result.Add(new RewardGroup(this.Attributes, $"fixed-{i}"));
				}

				return Result;
			}
		}
		#endregion
	}
}