using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Models;
using Microsoft.Data.SqlClient;


namespace BANKLOAN_APP_DA_LIB.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public string ConnectionString
        {
            get
            {

                return "Data Source=LTIN557127\\SQLEXPRESS;Initial Catalog=BANKLOAN_APP;Integrated Security=True;TrustServerCertificate=True;";
            }
        }
        public bool Add(Customer entity)
        {
            bool b = false;
            //try
            //{
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer (name, email, phone, address, password) VALUES(@P1, @P2, @P3, @P4, @P5)", con);
                cmd.Parameters.AddWithValue("@P1", entity.Name);
                cmd.Parameters.AddWithValue("@P2", entity.Email);
                cmd.Parameters.AddWithValue("@P3", entity.Phone);
                cmd.Parameters.AddWithValue("@P4", entity.Address);
                cmd.Parameters.AddWithValue("@P5", entity.Password);
                int r = cmd.ExecuteNonQuery();
                if (r > 0) {
                    b = true;
                }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("insert operation failure, Cannot add Customer details.");
            //    b = false;
            //}
            return b;
        }

        public bool Delete(Customer entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE customerId = @P", con);
                cmd.Parameters.AddWithValue("@P", entity.CustomerId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete Customer details.");
                b = false;
            }
            return b;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                Customer c = new Customer()
                {
                    CustomerId = Int32.Parse(sqlDr[0].ToString()),
                    Name = sqlDr[1].ToString(),
                    Email = sqlDr[2].ToString(),
                    Phone = sqlDr[3].ToString(),
                    Address = sqlDr[4].ToString(),
                    Password = sqlDr[5].ToString(),
                    KycStatus = sqlDr[6].ToString()
                };
                customers.Add(c);
            }
            sqlDr.Close();
            return customers;
        }

        public Customer GetById(object id)
        {
            int cusId = Int32.Parse((string)id);
            Customer cusObj = GetAll().Where(c => c.CustomerId == cusId).FirstOrDefault();
            return cusObj;

        }

        public bool Update(Customer entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Customer SET name=@P2,email=@P3, phone=@P4, address=@P5, password=@P6, kycStatus=@P7 WHERE customerId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", entity.Name);
                cmd.Parameters.AddWithValue("@P3", entity.Email);
                cmd.Parameters.AddWithValue("@P4", entity.Phone);
                cmd.Parameters.AddWithValue("@P5", entity.Address);
                cmd.Parameters.AddWithValue("@P6", entity.Password);
                cmd.Parameters.AddWithValue("@P7", entity.KycStatus);
                cmd.Parameters.AddWithValue("@P1", entity.CustomerId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot update Customer details.");
                b = false;
            }
            return b;
        }
    }
}
