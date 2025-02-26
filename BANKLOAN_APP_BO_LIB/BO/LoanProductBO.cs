using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Repositories;

namespace BANKLOAN_APP_BO_LIB.BO
{
    public class LoanProductBO
    {
        //        addLoanProduct()
        //▪ updateLoanProduct()
        //▪ getLoanProductDetails()
        static LoanProductRepository loanPRepo = new LoanProductRepository();
        public static void GetLoanProduct(string loanProductId)
        {
            var LoanProduct = loanPRepo.GetById(loanProductId);
            if (LoanProduct == null)
            {
                Console.WriteLine("LoanProduct not found");
            }
            else
            {
                Console.WriteLine(LoanProduct);
            }
        }
        public static void UpdateLoanProduct(string loanProductId)
        {
            var LoanProduct = loanPRepo.GetById(loanProductId);
            if (LoanProduct == null)
            {
                Console.WriteLine("LoanProduct not found");
            }
            else
            {
                Console.WriteLine("Enter the product name, interest rate, Tenure, max amount, min amount:");
                BANKLOAN_APP_DA_LIB.Models.LoanProduct l = new BANKLOAN_APP_DA_LIB.Models.LoanProduct()
                {
                    LoanProductId = LoanProduct.LoanProductId,
                    ProductName = Console.ReadLine(),
                    InterestRate = Decimal.Parse(Console.ReadLine()),
                    Tenure = Convert.ToInt32(Console.ReadLine()),
                    MaxAmount = Decimal.Parse(Console.ReadLine()),
                    MinAmount = Decimal.Parse(Console.ReadLine())
                };
                bool b = loanPRepo.Update(l);
                if (b)
                {
                    Console.WriteLine("LoanProduct updated successfully");
                }
                else
                {
                    Console.WriteLine("LoanProduct not updated");
                }
            }
        }
        public static void AddLoanProduct()
        {
            Console.WriteLine("Enter the name, interest rate, duration, max amount, min amount:");
            BANKLOAN_APP_DA_LIB.Models.LoanProduct l = new BANKLOAN_APP_DA_LIB.Models.LoanProduct()
            {
                ProductName = Console.ReadLine(),
                InterestRate = Decimal.Parse(Console.ReadLine()),
                Tenure = Convert.ToInt32(Console.ReadLine()),
                MaxAmount = Decimal.Parse(Console.ReadLine()),
                MinAmount = Decimal.Parse(Console.ReadLine())
            };
            bool b = loanPRepo.Add(l);
            if (b)
            {
                Console.WriteLine("LoanProduct added successfully");
            }
            else
            {
                Console.WriteLine("LoanProduct not added");
            }
        }


    }
}
