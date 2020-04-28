using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEFCoreDemo.modals;

namespace WebEFCoreDemo.maps
{
    public class BusinessRuleConfigMap : IEntityTypeConfiguration<BusinessRuleConfig>
    {
        public void Configure(EntityTypeBuilder<BusinessRuleConfig> builder)
        {
            builder.Ignore(c => c.WORKFLOWGUID);
            builder.Ignore(c => c.WORKFLOWSTATE);

            builder.Property(c => c.BRANCHID).IsRequired();

            builder.HasMany(x => x.Values).WithOne().HasForeignKey(y => y.FK).OnDelete(DeleteBehavior.Cascade);
        }
        
    }

    public class BusinessRuleBranchValueMap : IEntityTypeConfiguration<BusinessRuleBranchValue>
    {
        public void Configure(EntityTypeBuilder<BusinessRuleBranchValue> builder)
        {
            builder.Ignore(c => c.WORKFLOWGUID);
            builder.Ignore(c => c.WORKFLOWSTATE);

            builder.HasOne(x => x.Rule).WithMany().HasForeignKey(c => c.RULE_PK);
        }
    }
    public class BusinessRuleMap : IEntityTypeConfiguration<BusinessRule>
    {
        public void Configure(EntityTypeBuilder<BusinessRule> builder)
        {
            builder.Ignore(c => c.WORKFLOWGUID);
            builder.Ignore(c => c.WORKFLOWSTATE);
            builder.HasOne(x => x.RuleValues).WithOne().HasForeignKey<BusinessRuleValue>(c => c.PK);
        }
    }

    public class BusinessRuleValueMap : IEntityTypeConfiguration<BusinessRuleValue>
    {
        public void Configure(EntityTypeBuilder<BusinessRuleValue> builder)
        {
            builder.Ignore(c => c.WORKFLOWGUID);
            builder.Ignore(c => c.WORKFLOWSTATE);
            //builder.Property(c => c.PK).HasColumnAnnotation("NoIdGenerate", new NoIdGenerateAttribute());
            builder.HasMany(x => x.Values).WithOne().HasForeignKey(y => y.FK).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BusinessRuleValueItemMap : IEntityTypeConfiguration<BusinessRuleValueItem>
    {
        public void Configure(EntityTypeBuilder<BusinessRuleValueItem> builder)
        {
            builder.Ignore(c => c.WORKFLOWGUID);
            builder.Ignore(c => c.WORKFLOWSTATE);
        }
    }
}
