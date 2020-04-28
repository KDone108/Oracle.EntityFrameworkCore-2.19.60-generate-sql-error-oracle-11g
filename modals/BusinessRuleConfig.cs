using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEFCoreDemo.modals
{

    [Serializable]
    [Table("TB_SYS_CFG_BUSINESSRULECFG")]
    public class BusinessRuleConfig : BaseObject
    {
        public virtual String BRANCHID { get; set; }

        public virtual String BRANCHNAME { get; set; }

        /// <summary>
        /// 不可以初始化 不然ignite会报错
        /// </summary>
        public virtual ICollection<BusinessRuleBranchValue> Values { get; set; }
    }
}
