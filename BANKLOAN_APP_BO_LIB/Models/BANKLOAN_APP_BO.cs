using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Repositories;

namespace BANKLOAN_APP_BO_LIB.Models
{
    public class BANKLOAN_APP_BO
    {
        static CustomerRepository custRepo = new CustomerRepository();
        static LoanProductRepository loanPRepo = new LoanProductRepository();
        static RepaymentRepository repayRepo = new RepaymentRepository();
        public static void UpdateCustomer(string customerId)
        {
            var Customer = custRepo.GetById(customerId);
            if (Customer == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                Console.WriteLine("Enter the name, email, phone, address, password, Kyc status:");
                BANKLOAN_APP_DA_LIB.Models.Customer c = new BANKLOAN_APP_DA_LIB.Models.Customer()
                {
                    CustomerId = Customer.CustomerId,
                    Name = Console.ReadLine(),
                    Email = Console.ReadLine(),
                    Phone = Console.ReadLine(),
                    Address = Console.ReadLine(),
                    Password = Console.ReadLine(),
                    KycStatus = Console.ReadLine()
                };
                bool b = custRepo.Update(c);
                if (b)
                {
                    Console.WriteLine("Customer updated successfully");
                }
                else
                {
                    Console.WriteLine("Customer not updated");
                }
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
                Console.WriteLine("Enter the product name, interest rate, duration, max amount, min amount:");
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
        public static void UpdateRepayment(string repayId)
        {
            var repayment = repayRepo.GetById(repayId);
            if (repayment == null)
            {
                Console.WriteLine("Repayment not found");
            }
            else
            {
                Console.WriteLine("Enter the Appication Id, due date, due amount, amount, payment date :");
                BANKLOAN_APP_DA_LIB.Models.Repayment r = new BANKLOAN_APP_DA_LIB.Models.Repayment()
                {
                    RepaymentId = repayment.RepaymentId,
                    ApplicationId= Int32.Parse(Console.ReadLine()),
                    DueDate = DateTime.Parse(Console.ReadLine()),
                    AmountDue = Decimal.Parse(Console.ReadLine()),
                    PaymentDate = DateTime.Parse(Console.ReadLine()),
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
        public static void RemoveCustomer(string custId)
        {
            var Customer = custRepo.GetById(custId);
            if (Customer == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                bool b = custRepo.Delete(Customer);
                if (b)
                {
                    Console.WriteLine("Customer deleted successfully");
                }
                else
                {
                    Console.WriteLine("Customer not deleted");
                }
            }

        }
        public static void RemoveLoanProduct(string loanProductId)
        {
            var LoanProduct = loanPRepo.GetById(loanProductId);
            if (LoanProduct == null)
            {
                Console.WriteLine("LoanProduct not found");
            }
            else
            {
                bool b = loanPRepo.Delete(LoanProduct);
                if (b)
                {
                    Console.WriteLine("LoanProduct deleted successfully");
                }
                else
                {
                    Console.WriteLine("LoanProduct not deleted");
                }
            }
        }
        public static void RemoveRepayment(string repayId)
        {
            var repayment = repayRepo.GetById(repayId);
            if (repayment == null)
            {
                Console.WriteLine("Repayment not found");
            }
            else
            {
                bool b = repayRepo.Delete(repayment);
                if (b)
                {
                    Console.WriteLine("Repayment deleted successfully");
                }
                else
                {
                    Console.WriteLine("Repayment not deleted");
                }
            }
        }
        public static void SearchCustomer(string custId)
        {
            var Customer = custRepo.GetById(custId);
            if (Customer == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                Console.WriteLine(Customer);
            }
        }
        public static void SearchLoanProduct(string loanProductId)
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
        public static void SearchRepayment(string repayId)
        {
            var repayment = repayRepo.GetById(repayId);
            if (repayment == null)
            {
                Console.WriteLine("Repayment not found");
            }
            else
            {
                Console.WriteLine(repayment);
            }
        }
        public static void ShowCustomer()
        {
            var Customer = custRepo.GetAll();
            Console.WriteLine("{0,10}{1,20}{2,20}{3,15}{4,30}{5,15}{6,15}", "CustomerId", "Name", "Email", "Phone", "Address", "Password", "KycStatus");
            foreach (var c in Customer)
            {
                Console.WriteLine(c);
            }
        }
        public static void ShowLoanProduct()
        {
            var LoanProduct = loanPRepo.GetAll();
            Console.WriteLine("{0,10}{1,15}{2,10}{3,10}{4,10}{5,15}", "LoanProductId", "ProductName", "InterestRate", "MaxAmount", "MinAmount", "Tenure");
            foreach (var l in LoanProduct)
            {
                Console.WriteLine(l);
            }
        }
        public static void ShowRepayment()
        {
            var repayment = repayRepo.GetAll();
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}", "RepaymentId", "ApplicationId", "DueDate", "AmountDue", "PaymentDate","PaymentStatus");
            foreach (var r in repayment)
            {
                Console.WriteLine(r);
            }
        }
        public static void AddCustomer()
        {
            Console.WriteLine("Enter the name, email, phone, address, password:");
            BANKLOAN_APP_DA_LIB.Models.Customer c = new BANKLOAN_APP_DA_LIB.Models.Customer()
            {
                Name = Console.ReadLine(),
                Email = Console.ReadLine(),
                Phone = Console.ReadLine(),
                Address = Console.ReadLine(),
                Password = Console.ReadLine(),
                KycStatus = "PENDING"
            };
            bool b = custRepo.Add(c);
            if (b)
            {
                Console.WriteLine("Customer added successfully");
            }
            else
            {
                Console.WriteLine("Customer not added");
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
        public static void AddRepayment()
        {
            Console.WriteLine("Enter the Appication Id, due date, due amount, amount, payment date :");
            BANKLOAN_APP_DA_LIB.Models.Repayment r = new BANKLOAN_APP_DA_LIB.Models.Repayment()
            {
                ApplicationId = Int32.Parse(Console.ReadLine()),
                DueDate = DateTime.Parse(Console.ReadLine()),
                AmountDue = Decimal.Parse(Console.ReadLine()),
                PaymentDate = DateTime.Parse(Console.ReadLine()),
                PaymentStatus = "PENDING"
            };
            bool b = repayRepo.Add(r);
            if (b)
            {
                Console.WriteLine("Repayment added successfully");
            }
            else
            {
                Console.WriteLine("Repayment not added");
            }
        }
    }

}
