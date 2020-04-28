using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEFCoreDemo.modals
{
    /// <summary>
    /// 业务规则值配置
    /// </summary>
    [Serializable]
    [Table("TB_SYS_CFG_BIZRULEVALUE")]
    public class BusinessRuleValue : BaseObject
    {
        /// <summary>
        /// 规则编号
        /// </summary>
        public virtual String RULENO { get; set; }

        /// <summary>
        /// 规则值类型
        /// </summary>
        public virtual String VALUETYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<BusinessRuleValueItem> Values { get; set; }
    }
}
