using InvestorManagement.Application.DTOs;
using InvestorManagement.Application.Interfaces;
using InvestorManagement.Domain.Enities;


namespace InvestorManagement.Application.Services
{
    public class InvestorService : IInvestorService
    {
        private readonly IInvestorRepository _investorRepository;

        public InvestorService(IInvestorRepository investorRepository)
        {
            _investorRepository = investorRepository;
        }

        public async Task<IEnumerable<InvestorDto>> GetAllInvestorsAsync()
        {
            var investors = await _investorRepository.GetAllInvestorsAsync();
            return investors.Select(i => new InvestorDto
            {
                Id = i.Id,
                Name = i.Name,
                Phone = i.Phone,
                Email = i.Email,
                Country = i.Country,
                Funds = i.InvestorFunds.Select(ifr => ifr.Fund.Name).ToList()
            }).ToList();
        }

        public async Task<InvestorDto> GetInvestorByIdAsync(int id)
        {
            var investor = await _investorRepository.GetInvestorByIdAsync(id);
            if (investor == null) return null;

            return new InvestorDto
            {
                Id = investor.Id,
                Name = investor.Name,
                Phone = investor.Phone,
                Email = investor.Email,
                Country = investor.Country,
                Funds = investor.InvestorFunds.Select(ifr => ifr.Fund.Name).ToList()
            };
        }

        public async Task AddInvestorAsync(CreateInvestorDto newInvestor)
        {
            var investor = new Investor
            {
                Name = newInvestor.Name,
                Phone = newInvestor.Phone,
                Email = newInvestor.Email,
                Country = newInvestor.Country
            };
            await _investorRepository.AddInvestorAsync(investor);
        }

        public async Task DeleteInvestorAsync(int id)
        {
            await _investorRepository.DeleteInvestorAsync(id);
        }

        public async Task AddFundToInvestorAsync(int investorId, string fundName)
        {
            await _investorRepository.AddFundToInvestorAsync(investorId, fundName);
        }
    }
}
