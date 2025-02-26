using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_BO_LIB.BO;

namespace BANKLOAN_APP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("1. customer");
                Console.WriteLine("2. loan application");
                Console.WriteLine("3. loan product");
                Console.WriteLine("4. repayment");
                Console.WriteLine("5. report");
                Console.WriteLine("6. exit");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("1. Register Customer");
                        Console.WriteLine("2. Get Customer Details");
                        Console.WriteLine("3. Update Customer Profile");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("Enter your choice:");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        switch(ch)
                        {
                            case 1:
                                CustomerBO.RegisterCustomer();
                                break;
                            case 2:
                                Console.WriteLine("Enter the customer id:");
                                string custId = Console.ReadLine();
                                CustomerBO.GetCustomerDetails(custId);
                                break;
                            case 3:
                                Console.WriteLine("Enter the customer id:");
                                string custId1 = Console.ReadLine();
                                CustomerBO.UpdateCustomerProfile(custId1);
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("1. Apply for Loan");
                        Console.WriteLine("2. Get Application Status");
                        Console.WriteLine("3. Process Loan Application");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("Enter your choice:");
                        int ch1 = Convert.ToInt32(Console.ReadLine());
                        switch (ch1)
                        {
                            case 1:
                                LoanApplicationBO.ApplyForLoan();
                                break;
                            case 2:
                                Console.WriteLine("Enter the application id:");
                                string appId = Console.ReadLine();
                                LoanApplicationBO.GetApplicationStatus(appId);
                                break;
                            case 3:
                                Console.WriteLine("Enter the application id:");
                                string appId1 = Console.ReadLine();
                                LoanApplicationBO.ProcessLoanApplication(appId1);
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("1. Add Loan Product");
                        Console.WriteLine("2. Update Loan Product");
                        Console.WriteLine("3. Get Loan Product Details");
                        Console.WriteLine("4. Exit");

                        Console.WriteLine("Enter your choice:");
                        int ch2 = Convert.ToInt32(Console.ReadLine());
                        switch (ch2)
                        {
                            case 1:
                                LoanProductBO.AddLoanProduct();
                                break;
                            case 2:
                                Console.WriteLine("Enter the loan product id:");
                                string loanProductId = Console.ReadLine();
                                LoanProductBO.UpdateLoanProduct(loanProductId);
                                break;
                            case 3:
                                Console.WriteLine("Enter the loan product id:");
                                string loanProductId1 = Console.ReadLine();
                                LoanProductBO.GetLoanProduct(loanProductId1);
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("1. Get Repayment Schedule");
                        Console.WriteLine("2. Make Repayment");
                        Console.WriteLine("3. Get outstanding Balance");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("Enter your choice:");
                        int ch3 = Convert.ToInt32(Console.ReadLine());
                        switch (ch3)
                        {
                            case 1:
                                Console.WriteLine("Enter the loan application id:");
                                string loanAppId = Console.ReadLine();
                                RepaymentBO.GetRepaymentSchedule(loanAppId);
                                break;
                            case 2:
                                Console.WriteLine("Enter the loan application id:");
                                string loanAppId1 = Console.ReadLine();
                                RepaymentBO.MakePayment(loanAppId1);
                                break;
                            case 3:
                                Console.WriteLine("Enter the loan application id:");
                                string loanAppId2 = Console.ReadLine();
                                RepaymentBO.GetOutstandingBalance(loanAppId2);
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("1. Get Loan Report");
                        Console.WriteLine("2. Get Repayment Report");
                        Console.WriteLine("3. Generate outstanding loan amount");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("Enter your choice:");
                        int ch4 = Convert.ToInt32(Console.ReadLine());
                        switch (ch4)
                        {
                            case 1: 
                                ReportBO.GenerateLoanReport();
                                break;
                            case 2:
                                ReportBO.GenerateRepaymentReport();
                                break;
                            case 3:
                                ReportBO.GenerateOutstandingLoansReport();
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}