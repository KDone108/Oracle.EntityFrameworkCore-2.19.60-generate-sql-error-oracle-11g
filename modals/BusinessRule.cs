using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEFCoreDemo.modals
{
    [Serializable]
    [Table("TB_SYS_CFG_BUSINESSRULE")]
    public class BusinessRule : BaseObject
    {
        private string _ruleName { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual String CATEGORYNAME { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public virtual String CATEGORYNO { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual String DESCRIPTION { get; set; }

        /// <summary>
        /// 规则名称
        /// </summary>
        public virtual String RULENAME
        {
            get
            {
                if (_ruleName == null)
                {
                    return RULENO;
                }

                return _ruleName;
            }
            set
            {
                _ruleName = value;
            }
        }

        /// <summary>
        /// 规则编号
        /// </summary>
        public virtual String RULENO { get; set; }

        /// <summary>
        /// 规则值PK
        /// </summary>
        public virtual long RULEVALUE_PK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual BusinessRuleValue RuleValues { get; set; }
    }
}
