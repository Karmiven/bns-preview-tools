﻿using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.Script.Reaction;
using Xylia.bns.Modules.AIData.Script.Reaction.Subclass;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.Script
{
	[Signal("reaction-set")]
	public sealed class ReactionSet : BaseNode
	{
		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<IReaction> Reactions;
		#endregion

		#region 字段
		/// <summary>
		/// 概率 0~100，decision 下的所有 ReactionSet 概率和不能超过最大值
		/// </summary>
		public byte Probability;

		/// <summary>
		/// 概率 0~10000，decision 下的所有 ReactionSet 概率和不能超过最大值 
		/// </summary>
		public short Probability10000;
		#endregion

		


		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Reactions = new List<IReaction>();
			var Reactions = xe.SelectNodes("./reaction");
			for (int idx = 0; idx < Reactions.Count; idx++)
			{
				var ReactionNode = Reactions[idx];
				this.Reactions.Add(ReactionNode.TypeFactory<ReactionType, IReaction>(s => s switch
				{
					ReactionType.AcquireFieldItem => new AcquireFieldItem(),
					ReactionType.ActivateTeleport => new ActivateTeleport(),
					ReactionType.ActResume => new ActResume(),
					ReactionType.AddZoneScore => new AddZoneScore(),
					ReactionType.CopyNpcHate => new CopyNpcHate(),
					ReactionType.Damage => new Damage(),
					ReactionType.DeactivateTeleport => new DeactivateTeleport(),
					ReactionType.DebugPrint => new DebugPrint(),
					ReactionType.DebugTrace => new DebugTrace(),
					ReactionType.DespawnNpc => new DespawnNpc(),
					ReactionType.DespawnNpcGroups => new DespawnNpcGroups(),
					ReactionType.DespawnNpcIndex => new DespawnNpcIndex(),
					ReactionType.DiffNpcHate => new DiffNpcHate(),
					ReactionType.DiffNpcNumber => new DiffNpcNumber(),
					ReactionType.DiffPartyNumber => new DiffPartyNumber(),
					ReactionType.DispelBuff => new DispelBuff(),
					ReactionType.DispelByAttr => new DispelByAttr(),
					ReactionType.DispelByType => new DispelByType(),
					ReactionType.DispelDebuff => new DispelDebuff(),
					ReactionType.Heal => new Heal(),
					ReactionType.HealMax => new HealMax(),
					ReactionType.InOutDetectStart => new InOutDetectStart(),
					ReactionType.InOutDetectStop => new InOutDetectStop(),
					ReactionType.InvokeEffect => new InvokeEffect(),
					ReactionType.Kill => new Kill(),
					ReactionType.NpcFireSpecial => new NpcFireSpecial(),
					ReactionType.NpcTalkFinish => new NpcTalkFinish(),
					ReactionType.PatternStart => new PatternStart(),
					ReactionType.PatternSuccess => new PatternSuccess(),
					ReactionType.PlayCinematic => new PlayCinematic(),
					ReactionType.PlayIndexedSocial => new PlayIndexedSocial(),
					ReactionType.PlaySocial => new PlaySocial(),
					ReactionType.PlaySurroundSocial => new PlaySurroundSocial(),
					ReactionType.RemoveFieldItem => new RemoveFieldItem(),
					ReactionType.ResetNpcAllHate => new ResetNpcAllHate(),
					ReactionType.ResetNpcHate => new ResetNpcHate(),
					ReactionType.ResetStage => new ResetStage(),
					ReactionType.ResetZoneObject => new ResetZoneObject(),
					ReactionType.SetEnvEnable => new SetEnvEnable(),
					ReactionType.SetEnvInitEnable => new SetEnvInitEnable(),
					ReactionType.SetEnvState => new SetEnvState(),
					ReactionType.SetNpcAct => new SetNpcAct(),
					ReactionType.SetNpcAttackable => new SetNpcAttackable(),
					ReactionType.SetNpcBrain => new SetNpcBrain(),
					ReactionType.SetNpcCombatMode => new SetNpcCombatMode(),
					ReactionType.SetNpcFollow => new SetNpcFollow(),
					ReactionType.SetNpcHateOn => new SetNpcHateOn(),
					ReactionType.SetNpcIndexedAct => new SetNpcIndexedAct(),
					ReactionType.SetNpcInteractive => new SetNpcInteractive(),
					ReactionType.SetNpcNumber => new SetNpcNumber(),
					ReactionType.SetPartyNumber => new SetPartyNumber(),
					ReactionType.SetPartyObject => new SetPartyObject(),
					ReactionType.SetPublicRaidEvent => new SetPublicRaidEvent(),
					ReactionType.SetUndying => new SetUndying(),
					ReactionType.SetZoneObject => new SetZoneObject(),
					ReactionType.SpawnFieldItem => new SpawnFieldItem(),
					ReactionType.SpawnNpc => new SpawnNpc(),
					ReactionType.SpawnNpcGroups => new SpawnNpcGroups(),
					ReactionType.SpawnNpcIndex => new SpawnNpcIndex(),
					ReactionType.SpawnRandomNpc => new SpawnRandomNpc(),
					ReactionType.SpawnRandomNpcGroup => new SpawnRandomNpcGroup(),
					ReactionType.TransitNpcCombat => new TransitNpcCombat(),
					ReactionType.TransitNpcCombatIndex => new TransitNpcCombatIndex(),
					ReactionType.Warp => new Warp(),
					ReactionType.WarpParty => new WarpParty(),
					ReactionType.WarpToReentrance => new WarpToReentrance(),

					_ => null
				}));
			}
		}
		#endregion
	}
}