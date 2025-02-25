using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKLOAN_APP_DA_LIB.Models;
using Microsoft.Data.SqlClient;

namespace BANKLOAN_APP_DA_LIB.Repositories
{
    public class LoanApplicationRepository : IRepository<LoanApplication>
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN557127\\SQLEXPRESS;Initial Catalog=BANKLOAN_APP;Integrated Security=True;TrustServerCertificate=True;";
            }
        }
        public bool Add(LoanApplication entity)
        {
            bool b = false;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LoanApplication (customerId, loanProductId, loanAmount, applicationDate, approvalStatus) VALUES (@P1, @P2, @P3, @P4, @P5)", con);
                cmd.Parameters.AddWithValue("@P1", entity.CustomerId);
                cmd.Parameters.AddWithValue("@P2", entity.LoanProductId);
                cmd.Parameters.AddWithValue("@P3", entity.LoanAmount);
                cmd.Parameters.AddWithValue("@P4", entity.ApplicationDate);
                cmd.Parameters.AddWithValue("@P5", entity.ApprovalStatus);


                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("insert operation failure, Cannot add Doctor details.");
                b = false;
            }
            return b;


        }

        public bool Delete(LoanApplication entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM LoanApplication WHERE applicationId = @P", con);
                cmd.Parameters.AddWithValue("@P", entity.ApplicationId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete operation failure, Cannot delete loan application details.");
                b = false;
            }
            return b;
        }

        public List<LoanApplication> GetAll()
        {
            List<LoanApplication> LoanApplication = new List<LoanApplication>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM LoanApplication", con);
            SqlDataReader sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                LoanApplication c = new LoanApplication()
                {
                    ApplicationId = Int32.Parse(sqlDr[0].ToString()),
                    CustomerId = Int32.Parse(sqlDr[1].ToString()),
                    LoanProductId = Int32.Parse(sqlDr[2].ToString()),
                    LoanAmount = Decimal.Parse(sqlDr[3].ToString()),
                    ApplicationDate = DateTime.Parse(sqlDr[4].ToString()),
                    ApprovalStatus = sqlDr[5].ToString()
                };
                LoanApplication.Add(c);
            }
            sqlDr.Close();
            return LoanApplication;
        }

        public LoanApplication GetById(object id)
        {

            int loanappId = Int32.Parse((string)id);
            LoanApplication loanappObj = GetAll().Where(c => c.ApplicationId == loanappId).FirstOrDefault();
            return loanappObj;
        }

        public bool Update(LoanApplication entity)
        {
            bool b = false;

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LoanApplication SET CustomerId=@P2, LoanProductId=@P3, LoanAmount=@P4, ApplicationDate=@P5,ApprovalStatus=@P6 WHERE ApplicationId=@P1", con);
                cmd.Parameters.AddWithValue("@P2", entity.CustomerId);
                cmd.Parameters.AddWithValue("@P3", entity.LoanProductId);
                cmd.Parameters.AddWithValue("@P4", entity.LoanAmount);
                cmd.Parameters.AddWithValue("@P5", entity.ApplicationDate);
                cmd.Parameters.AddWithValue("@P6", entity.ApprovalStatus);
                cmd.Parameters.AddWithValue("@P1", entity.ApplicationId);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update operation failure, Cannot update loan application details.");
                b = false;
            }
            return b;
        }
    }
}