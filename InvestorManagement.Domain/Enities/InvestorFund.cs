using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorManagement.Domain.Enities
{
    public class InvestorFund
    {
        public int InvestorId { get; set; }
        public Investor Investor { get; set; }

        public int FundId { get; set; }
        public Fund Fund { get; set; }
    }
}
