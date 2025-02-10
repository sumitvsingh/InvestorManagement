using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorManagement.Domain.Enities;

namespace InvestorManagement.Application.Interfaces
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<Investor>> GetAllInvestorsAsync();
        Task<Investor> GetInvestorByIdAsync(int id);
        Task AddInvestorAsync(Investor investor);
        Task DeleteInvestorAsync(int id);
        Task AddFundToInvestorAsync(int investorId, string fundName);
    }
}
