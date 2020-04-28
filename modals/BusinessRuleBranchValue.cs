using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEFCoreDemo.modals
{
    [Serializable]
    [Table("TB_SYS_CFG_BIZRULEBRANCHVAL")]
    public class BusinessRuleBranchValue : BaseObject
    {
        /// <summary>
        /// 规则编号
        /// </summary>
        public virtual string RULENO { get; set; }

        /// <summary>
        /// 规则值
        /// </summary>
        public virtual String RULEVALUE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual long RULE_PK { get; set; }

        /// <summary>
        /// 是否集中控管
        /// </summary>
        public virtual Boolean ISCENTRALIZEDADMIN { get; set; }

        /// <summary>
        /// 规则
        /// </summary>
        public virtual BusinessRule Rule { get; set; }
    }
}
