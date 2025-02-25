using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BANKLOAN_APP_BO_LIB.Models
{
    public class Repayment
    {
        public int RepaymentId {  get; set; }
        public int ApplicationId {  get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountDue {  get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus {  get; set; }
    }
}
