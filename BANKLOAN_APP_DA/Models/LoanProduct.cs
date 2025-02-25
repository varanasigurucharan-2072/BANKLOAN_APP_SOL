using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BANKLOAN_APP_DA_LIB.Models
{
    public class LoanProduct
    {

        public int LoanProductId { get; set; }
        public string ProductName { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Tenure { get; set; }
        public override string ToString()
        {
            return string.Format($"{LoanProductId,10}{ProductName,15}{InterestRate,10}{MinAmount,10}{MaxAmount,10}{Tenure,15}");
        }
    }
}
