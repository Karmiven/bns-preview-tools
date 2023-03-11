using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.CombatSequence.Action;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.CombatSequence
{
	/// <summary>
	/// 战斗序列类
	/// </summary>
	public abstract class ISequence : BaseNode
    {
        #region 字段
        public short ID;

        [Signal("attack-limit")]
        public byte AttackLimit;

        [Signal("range-attack-limit")]
        public byte RangeAttackLimit;

        [Signal("combat-distance")]
        public byte CombatDistance;

        [DefaultValue(1)]
        [Signal("max-count")]
        public short MaxCount;

        [Signal("script-debug-enable")]
        public bool ScriptDebugEnable;


        /// <summary>
        /// 普通序列过程中调用特殊序列
        /// </summary>
        [Signal("special-1")] public byte Special1;
        [Signal("special-2")] public byte Special2;
        [Signal("special-3")] public byte Special3;
        [Signal("special-4")] public byte Special4;
        [Signal("special-5")] public byte Special5;
        #endregion


        #region 结构字段
        /// <summary>
        /// 执行活动
        /// </summary>
        [FStruct(StructType.Meta)]
        public List<IAction> Actions = new();
        #endregion

        #region 方法
        public override void LoadData(XmlElement xe)
        {
            base.LoadData(xe);

            //Special1、Special2存在默认值，当定义 Special1 后 Special2 会默认为空
            if(this.Special1 != 0)    
                this.Special2 = 0;


            this.Actions = new List<IAction>();
            var Actions = xe.SelectNodes("./action");
            for (int i = 0; i < Actions.Count; i++)
            {
                var ActionNode = (XmlElement)Actions[i];
                this.Actions.Add(ActionNode.ActionFactory());
            }
        }
        #endregion
    }
}