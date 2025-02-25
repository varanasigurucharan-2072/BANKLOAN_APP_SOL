using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BANKLOAN_APP_DA_LIB.Models
{
    public class LoanApplication
    {
        public int ApplicationId { get; set; }
        public int CustomerId { get; set; }
        public int LoanProductId { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApprovalStatus { get; set; }
        public override string ToString()
        {
            return string.Format($"{ApplicationId,10}{CustomerId,10}{LoanProductId,15}{LoanAmount,15}{ApplicationDate,15}{ApprovalStatus,15}");
        }

    }
}
