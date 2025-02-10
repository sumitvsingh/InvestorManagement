using InvestorManagement.Application.DTOs;
using InvestorManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestorManagement.Api.Controllers
{
    [ApiController]
	[Authorize]
	[Route("api/[controller]")]
    public class InvestorsController : ControllerBase
    {
        private readonly IInvestorService _investorService;

        public InvestorsController(IInvestorService investorService)
        {
            _investorService = investorService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvestors()
        {
            var investors = await _investorService.GetAllInvestorsAsync();
            return Ok(investors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvestorById(int id)
        {
            var investor = await _investorService.GetInvestorByIdAsync(id);
            if (investor == null)
                return NotFound();
            return Ok(investor);
        }

        [HttpPost]
        public async Task<IActionResult> AddInvestor([FromBody] CreateInvestorDto newInvestor)
        {
            await _investorService.AddInvestorAsync(newInvestor);
            return CreatedAtAction(nameof(GetInvestorById), new { id = newInvestor.Name }, newInvestor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestor(int id)
        {
            await _investorService.DeleteInvestorAsync(id);
            return NoContent();
        }

        [HttpPost("{investorId}/funds")]
        public async Task<IActionResult> AddFundToInvestor(int investorId, [FromBody] AddFundToInvestorDto fundDto)
        {
            await _investorService.AddFundToInvestorAsync(investorId, fundDto.FundName);
            return NoContent();
        }
    }
}
