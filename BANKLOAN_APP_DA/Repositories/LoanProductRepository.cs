using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Models;
using Microsoft.Data.SqlClient;

namespace BANKLOAN_APP_DA_LIB.Repositories
{
    public class LoanProductRepository : IRepository<LoanProduct>
    {
        public string ConnectionString
        {
            get
            {

                return "Data Source=LTIN557127\\SQLEXPRESS;Initial Catalog=BANKLOAN_APP;Integrated Security=True;TrustServerCertificate=True;";
            }
        }
        public bool Add(LoanProduct entity)
        {
            bool b = false;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LoanProduct  (productName, interestRate, minAmount, maxAmount, tenure) VALUES(@P1, @P2, @P3, @P4, @P5)", con);
                cmd.Parameters.AddWithValue("@P1", entity.ProductName);
                cmd.Parameters.AddWithValue("@P2", entity.InterestRate);
                cmd.Parameters.AddWithValue("@P3", entity.MinAmount);
                cmd.Parameters.AddWithValue("@P4", entity.MaxAmount);
                cmd.Parameters.AddWithValue("@P5", entity.Tenure);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("insert operation failure, Cannot add Loan Product details.");
                b = false;
            }
            return b;
        }

        public bool Delete(LoanProduct entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM LoanProduct WHERE loanProductId = @P", con);
                cmd.Parameters.AddWithValue("@P", entity.LoanProductId);
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

        public List<LoanProduct> GetAll()
        {
            List<LoanProduct> loanProducts = new List<LoanProduct>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM LoanProduct", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                LoanProduct l = new LoanProduct()
                {
                    LoanProductId = Int32.Parse(sqlDr[0].ToString()),
                    ProductName = sqlDr[1].ToString(),
                    InterestRate = Decimal.Parse(sqlDr[2].ToString()),
                    MinAmount = Decimal.Parse(sqlDr[3].ToString()),
                    MaxAmount = Decimal.Parse(sqlDr[4].ToString()),
                    Tenure = Int32.Parse(sqlDr[5].ToString())
                }; 
                loanProducts.Add(l);
            }
            sqlDr.Close();
            return loanProducts;
        }

        public LoanProduct GetById(object id)
        {
            int loanPId = Int32.Parse((string)id);
            LoanProduct loanPObj= GetAll().Where(lp => lp.LoanProductId == loanPId).FirstOrDefault();
            return loanPObj;
        }

        public bool Update(LoanProduct entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LoanProduct SET productName=@P2,interestRate=@P3, minAmount=@P4, maxAmount=@P5, tenure=@P6 WHERE loanProductId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", entity.ProductName);
                cmd.Parameters.AddWithValue("@P3", entity.InterestRate);
                cmd.Parameters.AddWithValue("@P4", entity.MinAmount);
                cmd.Parameters.AddWithValue("@P5", entity.MaxAmount);
                cmd.Parameters.AddWithValue("@P6", entity.Tenure);
                cmd.Parameters.AddWithValue("@P1", entity.LoanProductId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot update loan product details.");
                b = false;
            }
            return b;
        }
    }
}
