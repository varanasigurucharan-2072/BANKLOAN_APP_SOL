using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKLOAN_APP_DA_LIB.Models
{
    public class Repayment
    {
        public int RepaymentId { get; set; }
        public int ApplicationId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public override string ToString()
        {
            return string.Format($"{RepaymentId,10}{ApplicationId,10}{DueDate,10}{AmountDue,10}{PaymentDate,10}{PaymentStatus,10}");
        }
    }
}
