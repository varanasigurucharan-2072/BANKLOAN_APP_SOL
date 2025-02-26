using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Repositories;

namespace BANKLOAN_APP_BO_LIB.BO
{
    public class RepaymentBO
    {
        //        getRepaymentSchedule()
        //▪ makePayment()
        //▪ getOutstandingBalance()
        static RepaymentRepository repayRepo = new RepaymentRepository();
        public static void GetOutstandingBalance(string ApplicationId)
        {
            var repayment = repayRepo.GetAll();
            decimal balance = 0;
            foreach (var r in repayment)
            {
                if (r.ApplicationId == Int32.Parse(ApplicationId))
                {
                    balance += r.AmountDue;
                }
            }
            Console.WriteLine("Outstanding balance is : " + balance);
        }
        public static void MakePayment(string repayId)
        {
            var repayment = repayRepo.GetById(repayId);
            if (repayment == null)
            {
                Console.WriteLine("Repayment not found");
            }
            else
            {
                Console.WriteLine("Enter the Appication Id, due date, due amount, amountdue, payment date, payment status :");
                BANKLOAN_APP_DA_LIB.Models.Repayment r = new BANKLOAN_APP_DA_LIB.Models.Repayment()
                {
                    RepaymentId = repayment.RepaymentId,
                    ApplicationId = Int32.Parse(Console.ReadLine()),
                    DueDate = DateTime.Parse(Console.ReadLine()),
                    AmountDue = Decimal.Parse(Console.ReadLine()),
                    PaymentDate = DateTime.Parse(Console.ReadLine()),
                    PaymentStatus = Console.ReadLine()
                };
                bool b = repayRepo.Update(r);
                if (b)
                {
                    Console.WriteLine("Repayment updated successfully");
                }
                else
                {
                    Console.WriteLine("Repayment not updated");
                }

            }
        }
        public static void GetRepaymentSchedule(string ApplicationId)
        {
            var repayment = repayRepo.GetAll();
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}", "RepaymentId", "ApplicationId", "DueDate", "AmountDue", "PaymentDate", "PaymentStatus");
            foreach (var r in repayment)
            {   if(r.ApplicationId == Int32.Parse(ApplicationId))
                {
                    Console.WriteLine(r);
                }
            }
        }
    }
}
