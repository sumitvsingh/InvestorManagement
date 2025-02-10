using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorManagement.Application.Interfaces;
using InvestorManagement.Domain.Enities;
using InvestorManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace InvestorManagement.Infrastructure.Repositories
{
    public class InvestorRepository : IInvestorRepository
    {
        private readonly ApplicationDbContext _context;

        public InvestorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investor>> GetAllInvestorsAsync()
        {
            return await _context.Investors.Include(i => i.InvestorFunds)
                                           .ThenInclude(ifr => ifr.Fund)
                                           .ToListAsync();
        }

        public async Task<Investor> GetInvestorByIdAsync(int id)
        {
            return await _context.Investors.Include(i => i.InvestorFunds)
                                           .ThenInclude(ifr => ifr.Fund)
                                           .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddInvestorAsync(Investor investor)
        {
            _context.Investors.Add(investor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvestorAsync(int id)
        {
            var investor = await _context.Investors.FindAsync(id);
            if (investor != null)
            {
                _context.Investors.Remove(investor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddFundToInvestorAsync(int investorId, string fundName)
        {
            var fund = await _context.Funds.FirstOrDefaultAsync(f => f.Name == fundName);
            if (fund == null) return;

            var investorFund = new InvestorFund
            {
                InvestorId = investorId,
                FundId = fund.Id
            };

            _context.InvestorFunds.Add(investorFund);
            await _context.SaveChangesAsync();
        }
    }
}