using System.Collections.Generic;
using System.Linq;

using NPOI.SS.UserModel;

using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Scene.Game_ChallengeToday;

namespace Xylia.Preview.Output
{
	public sealed class ChallengeList : OutBase
	{
		protected override string Name => "今日挑战";

		protected override void CreateData()
		{
			#region Title
			foreach (var ChallengeType in Game_ChallengeTodayScene.TodayChallengeType)
				this.ExcelInfo.SetColumn(ChallengeType.Value, 30);

			var rows = new List<IRow>();
			for (int idx = 0; idx <= 50; idx++) rows.Add(this.ExcelInfo.CreateRow());
			#endregion

			int cellIdx = -1;
			foreach (var ChallengeType in Game_ChallengeTodayScene.TodayChallengeType)
			{
				var challengeList = FileCache.Data.ChallengeList.FirstOrDefault(o => o.ChallengeType == ChallengeType.Key);
				if (challengeList is null) continue;

				cellIdx++;
				int rowIdx = 0;

				#region 加载任务课题
				for (int Idx = 1; Idx <= 20; Idx++)
				{
					var ChallengeQuestBasic = challengeList.Attributes["challenge-quest-basic-" + Idx];
					var ChallengeQuestExpansion = challengeList.Attributes["challenge-quest-expansion-" + Idx];

					if (ChallengeQuestBasic is null) break;

					var Info = FileCache.Data.Quest[ChallengeQuestBasic].Name2.GetText();
					rows[rowIdx++].CreateCell(cellIdx).SetCellValue(Info);
				}
				#endregion

				#region 加载击杀课题
				for (int Idx = 1; Idx <= 20; Idx++)
				{
					var ChallengeNpcDifficulty = challengeList.Attributes["challenge-npc-difficulty-" + Idx].ToEnum<DifficultyType>();
					var ChallengeNpcKill = challengeList.Attributes["challenge-npc-kill-" + Idx];
					var ChallengeNpcAttraction = challengeList.Attributes["challenge-npc-attraction-" + Idx];

					var KillNpc = FileCache.Data.Npc[ChallengeNpcKill];
					if (KillNpc is null) break;

					var AttractionInfo = ChallengeNpcAttraction.CastObject().GetName();
					var Info = $"[{ ChallengeNpcDifficulty.GetName() }] { AttractionInfo } - { KillNpc.Name2.GetText() }";
					rows[rowIdx++].CreateCell(cellIdx).SetCellValue(Info);
				}
				#endregion
			}
		}
	}
}