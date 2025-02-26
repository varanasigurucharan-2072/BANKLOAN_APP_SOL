using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Repositories;

namespace BANKLOAN_APP_BO_LIB.BO
{
    public class CustomerBO
    {
        static CustomerRepository custRepo = new CustomerRepository();
        public static void GetCustomerDetails(string custId)
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
        public static void RegisterCustomer()
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
        public static void UpdateCustomerProfile(string customerId)
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

    }
}
