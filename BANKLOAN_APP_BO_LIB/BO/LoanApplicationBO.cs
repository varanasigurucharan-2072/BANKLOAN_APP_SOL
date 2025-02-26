using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Repositories;

namespace BANKLOAN_APP_BO_LIB.BO
{
    public class LoanApplicationBO
    {
        //        applyForLoan()
        //▪ getApplicationStatus()
        //▪ processLoanApplication()
        static LoanApplicationRepository loanAppRepo = new LoanApplicationRepository();
        public static void ProcessLoanApplication(string loanAppId)
        {
            var loanApp = loanAppRepo.GetById(loanAppId);
            if (loanApp == null)
            {
                Console.WriteLine("LoanApplication not found");
            }
            else
            {
                Console.WriteLine("Enter the customer id, loan product id, loan amount, tenure, application date,application status:");
                BANKLOAN_APP_DA_LIB.Models.LoanApplication l = new BANKLOAN_APP_DA_LIB.Models.LoanApplication()
                {
                    ApplicationId = loanApp.ApplicationId,
                    CustomerId = Convert.ToInt32(Console.ReadLine()),
                    LoanProductId = Convert.ToInt32(Console.ReadLine()),
                    LoanAmount = Decimal.Parse(Console.ReadLine()),
                    ApplicationDate = DateTime.Parse(Console.ReadLine()),
                    ApprovalStatus = Console.ReadLine()
                };
                bool b = loanAppRepo.Update(l);
                if (b)
                {
                    Console.WriteLine("LoanApplication updated successfully");
                }
                else
                {
                    Console.WriteLine("LoanApplication not updated");
                }
            }
        }
        public static void GetApplicationStatus(string loanAppId)
        {
            var loanApp = loanAppRepo.GetById(loanAppId);
            if (loanApp == null)
            {
                Console.WriteLine("LoanApplication not found");
            }
            else
            {
                Console.WriteLine(loanApp);
            }
        }
        public static void ApplyForLoan()
        {
            Console.WriteLine("Enter the customer id, loan product id, loan amount, tenure, status, date:");
            BANKLOAN_APP_DA_LIB.Models.LoanApplication l = new BANKLOAN_APP_DA_LIB.Models.LoanApplication()
            {
                CustomerId = Convert.ToInt32(Console.ReadLine()),
                LoanProductId = Convert.ToInt32(Console.ReadLine()),
                LoanAmount = Decimal.Parse(Console.ReadLine()),
                ApplicationDate = DateTime.Parse(Console.ReadLine()),
                ApprovalStatus = "PENDING"
            };
            bool b = loanAppRepo.Add(l);
            if (b)
            {
                Console.WriteLine("LoanApplication added successfully");
            }
            else
            {
                Console.WriteLine("LoanApplication not added");
            }
        }
    }
}
