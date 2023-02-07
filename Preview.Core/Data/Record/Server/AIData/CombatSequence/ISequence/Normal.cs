using Xylia.Attribute.Component;

using Xylia.Preview.Common.Seq;


namespace Xylia.bns.Modules.AIData.CombatSequence
{
	public sealed class Normal : ISequence
	{
		[Signal("change-min-msec")]
		public byte ChangeMinMsec;

		[Signal("except-summoned")]
		public bool ExceptSummoned;

		[Signal("hide-seq-start")]
		public bool HideSeqStart;

		[Signal("seq-start-social")]
		public byte SeqStartSocial;

		[Signal("setup-position")]
		public bool SetupPosition;

		[Signal("setup-dir")]
		public Direction SetupDir;
	}
}