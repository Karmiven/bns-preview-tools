using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xylia.bns.Modules.AIData.NpcBrainParameters.Enums
{
	/// <summary>
	/// 隐藏类型
	/// </summary>
	public enum HideType
	{
		None,

		/// <summary>
		/// 地下，无法攻击
		/// </summary>
		Burrow,

		/// <summary>
		/// 只是无法锁定，还是可以攻击到
		/// </summary>
		Hide,
	}
}
