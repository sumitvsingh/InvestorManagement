using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorManagement.Domain.Enities;
using Microsoft.EntityFrameworkCore;

namespace InvestorManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Investor> Investors { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<InvestorFund> InvestorFunds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvestorFund>()
                .HasKey(ifr => new { ifr.InvestorId, ifr.FundId });

            modelBuilder.Entity<InvestorFund>()
                .HasOne(ifr => ifr.Investor)
                .WithMany(i => i.InvestorFunds)
                .HasForeignKey(ifr => ifr.InvestorId);

            modelBuilder.Entity<InvestorFund>()
                .HasOne(ifr => ifr.Fund)
                .WithMany(f => f.InvestorFunds)
                .HasForeignKey(ifr => ifr.FundId);
        }
    }
}
