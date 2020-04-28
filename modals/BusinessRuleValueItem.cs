using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEFCoreDemo.modals
{
    /// <summary>
    /// 业务规则值明细
    /// </summary>
    [Serializable]
    [Table("TB_SYS_CFG_BIZRULEVALUEITEM")]
    public class BusinessRuleValueItem : BaseObject
    {
        /// <summary>
        /// 规则描述
        /// </summary>
        public virtual String DESCRIPTION { get; set; }

        /// <summary>
        /// 规则值
        /// </summary>
        public virtual String VALUE { get; set; }
    }
}
