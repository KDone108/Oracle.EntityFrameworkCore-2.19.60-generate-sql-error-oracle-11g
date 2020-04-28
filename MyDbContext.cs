using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEFCoreDemo.maps;
using WebEFCoreDemo.modals;

namespace WebEFCoreDemo
{
    public class MyDbContext : DbContext
    {
        private readonly IOptionsMonitor<ConsoleLoggerOptions> _optionsMonitor;
        public MyDbContext(DbContextOptions<MyDbContext> options, IOptionsMonitor<ConsoleLoggerOptions> optionsMonitor)
           : base(options)
        {
            _optionsMonitor = optionsMonitor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BusinessRuleConfigMap());
            modelBuilder.ApplyConfiguration(new BusinessRuleBranchValueMap());
            modelBuilder.ApplyConfiguration(new BusinessRuleMap());
            modelBuilder.ApplyConfiguration(new BusinessRuleValueMap());
            modelBuilder.ApplyConfiguration(new BusinessRuleValueItemMap());
        }
        public DbSet<BusinessRuleConfig> BusinessRules { get; set; }
    }
}
