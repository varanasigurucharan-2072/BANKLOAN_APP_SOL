using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Repositories;

namespace BANKLOAN_APP_BO_LIB.BO
{
    public class ReportBO
    {
        //        generateLoanReport()
        //▪ generateRepaymentReport()
        //▪ generateOutstandingLoansReport()
        static LoanApplicationRepository loanAppRepo = new LoanApplicationRepository();
        static RepaymentRepository repayRepo = new RepaymentRepository();
        public static void GenerateOutstandingLoansReport()
        {
            var loanApp = loanAppRepo.GetAll();
            var repayment = repayRepo.GetAll();
            Console.WriteLine("{0,10}{1,10}{2,15}{3,15}{4,15}{5,15}", "ApplicationId", "CustomerId", "LoanProductId", "LoanAmount", "ApplicationDate", "ApprovalStatus");
            foreach (var l in loanApp)
            {
                foreach (var r in repayment)
                {
                    if (l.ApplicationId == r.ApplicationId)
                    {
                        if (r.PaymentStatus == "Pending")
                        {
                            Console.WriteLine(l);
                        }
                    }
                }
            }
        }
        public static void GenerateRepaymentReport()
        {
            var repayment = repayRepo.GetAll();
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}", "RepaymentId", "ApplicationId", "DueDate", "AmountDue", "PaymentDate", "PaymentStatus");
            foreach (var r in repayment)
            {
                Console.WriteLine(r);
            }
        }

        public static void GenerateLoanReport()
        {
            var loanApp = loanAppRepo.GetAll();
            Console.WriteLine("{0,10}{1,10}{2,15}{3,15}{4,15}{5,15}", "ApplicationId", "CustomerId", "LoanProductId", "LoanAmount", "ApplicationDate", "ApprovalStatus");
            foreach (var l in loanApp)
            {
                Console.WriteLine(l);
            }
        }

    }
}
