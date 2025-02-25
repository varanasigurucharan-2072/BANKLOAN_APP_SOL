using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKLOAN_APP_BO_LIB.Models
{
    public class LoanApplication
    {
        public int ApplicationId { get; set; }
        public int CustomerId { get; set; }
        public int LoanProductId { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApprovalStatus { get; set; }
        
    }
}
