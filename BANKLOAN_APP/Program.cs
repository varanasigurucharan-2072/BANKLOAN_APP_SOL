using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_BO_LIB.Models;
namespace BANKLOAN_APP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.add customer");
                Console.WriteLine("2.display customer");
                Console.WriteLine("3.search customer");
                Console.WriteLine("4.modify customer");
                Console.WriteLine("5.delete customer");
                Console.WriteLine("6.add Loan product");
                Console.WriteLine("7.display Loan product");
                Console.WriteLine("8.search Loan product");
                Console.WriteLine("9.modify Loan product");
                Console.WriteLine("10.delete Loan product");
                Console.WriteLine("11.add repayment");
                Console.WriteLine("12.display repayment");
                Console.WriteLine("13.search repayment");
                Console.WriteLine("14.modify repayment");
                Console.WriteLine("15.delete repayment");
                Console.WriteLine("16.Add Loan Application");
                Console.WriteLine("17.Display Loan Application");
                Console.WriteLine("18.Search Loan Application");
                Console.WriteLine("19.Modify Loan Application");
                Console.WriteLine("20.Delete Loan Application");
                Console.WriteLine("21.exit");
                Console.WriteLine("enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BANKLOAN_APP_BO.AddCustomer();
                        break;
                    case 2:
                        BANKLOAN_APP_BO.ShowCustomer();
                        break;
                    case 3:
                        Console.WriteLine("Enter Customer Id:");
                        string custId = Console.ReadLine();
                        BANKLOAN_APP_BO.SearchCustomer(custId);
                        break;
                    case 4:
                        Console.WriteLine("Enter Customer Id");
                        string custId1 = Console.ReadLine();
                        BANKLOAN_APP_BO.UpdateCustomer(custId1);
                        break;
                    case 5:
                        Console.WriteLine("Enter Customer Id:");
                        string custId2 = Console.ReadLine();
                        BANKLOAN_APP_BO.RemoveCustomer(custId2);
                        break;
                    case 6:
                        BANKLOAN_APP_BO.AddLoanProduct();
                        break;
                    case 7:
                        BANKLOAN_APP_BO.ShowLoanProduct();
                        break;
                    case 8:
                        Console.WriteLine("Enter Loan Product Id:");
                        string loanProductId = Console.ReadLine();
                        BANKLOAN_APP_BO.SearchLoanProduct(loanProductId);
                        break;
                    case 9:
                        Console.WriteLine("Enter Loan Product Id:");
                        string loanProductId1 = Console.ReadLine();
                        BANKLOAN_APP_BO.UpdateLoanProduct(loanProductId1);
                        break;
                    case 10:
                        Console.WriteLine("Enter Loan Product Id:");
                        string loanProductId2 = Console.ReadLine();
                        BANKLOAN_APP_BO.RemoveLoanProduct(loanProductId2);
                        break;
                    case 11:
                        BANKLOAN_APP_BO.AddRepayment();
                        break;
                    case 12:
                        BANKLOAN_APP_BO.ShowRepayment();
                        break;
                    case 13:
                        Console.WriteLine("Enter Repayment Id:");
                        string repaymentId = Console.ReadLine();
                        BANKLOAN_APP_BO.SearchRepayment(repaymentId);
                        break;
                    case 14:
                        Console.WriteLine("Enter Repayment Id:");
                        string repaymentId1 = Console.ReadLine();
                        BANKLOAN_APP_BO.UpdateRepayment(repaymentId1);
                        break;
                    case 15:
                        Console.WriteLine("Enter Repayment Id:");
                        string repaymentId2 = Console.ReadLine();
                        BANKLOAN_APP_BO.RemoveRepayment(repaymentId2);
                        break;
                    case 16:
                        BANKLOAN_APP_BO.AddLoanApplication();
                        break;
                    case 17:
                        BANKLOAN_APP_BO.ShowLoanApplication();
                        break;
                    case 18:
                        Console.WriteLine("Enter Application Id:");
                        string applicationId = Console.ReadLine();
                        BANKLOAN_APP_BO.SearchLoanApplication(applicationId);
                        break;
                    case 19:
                        Console.WriteLine("Enter Application Id:");
                        string applicationId1 = Console.ReadLine();
                        BANKLOAN_APP_BO.UpdateLoanApplication(applicationId1);
                        break;
                    case 20:
                        Console.WriteLine("Enter Application Id:");
                        string applicationId2 = Console.ReadLine();
                        BANKLOAN_APP_BO.RemoveLoanApplication(applicationId2);
                        break;
                    case 21:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }
    }
}