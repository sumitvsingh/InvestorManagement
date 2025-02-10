using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorManagement.Application.DTOs;

namespace InvestorManagement.Application.Interfaces
{
    public interface IInvestorService
    {
        Task<IEnumerable<InvestorDto>> GetAllInvestorsAsync();
        Task<InvestorDto> GetInvestorByIdAsync(int id);
        Task AddInvestorAsync(CreateInvestorDto newInvestor);
        Task DeleteInvestorAsync(int id);
        Task AddFundToInvestorAsync(int investorId, string fundName);
    }

}
