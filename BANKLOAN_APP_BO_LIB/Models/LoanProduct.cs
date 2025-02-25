using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BANKLOAN_APP_BO_LIB.Models
{
    public class LoanProduct
    {
        public int LoanProductId { get; set; }
        public string ProductName { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Tenure { get; set; }
    }
}
