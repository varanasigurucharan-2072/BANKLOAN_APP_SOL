using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using BANKLOAN_APP_DA_LIB.Models;

using Microsoft.Data.SqlClient;

namespace BANKLOAN_APP_DA_LIB.Repositories

{

    public class RepaymentRepository : IRepository<Repayment>

    {

        public string ConnectionString

        {

            get

            {

                return "Data Source=LTIN557127\\SQLEXPRESS;Initial Catalog=BANKLOAN_APP;Integrated Security=True;TrustServerCertificate=True;";

            }

        }

        public bool Add(Repayment entity)

        {

            bool b = false;

            //try

            //{

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Repayment (applicationId, dueDate, amountDue, paymentDate) VALUES(@P2, @P3, @P4, @P5)", con);

            cmd.Parameters.AddWithValue("@P2", entity.ApplicationId);

            cmd.Parameters.AddWithValue("@P3", entity.DueDate);

            cmd.Parameters.AddWithValue("@P4", entity.AmountDue);

            cmd.Parameters.AddWithValue("@P5", entity.PaymentDate);

            int r = cmd.ExecuteNonQuery();

            if (r > 0)

            {

                b = true;

            }

            //}

            //catch (Exception ex)

            //{

            //    Console.WriteLine("insert operation failure, Cannot add Repayment Details.");

            //    b = false;

            //}

            return b;

        }



        public bool Delete(Repayment entity)

        {

            bool b = false;

            try

            {

                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Repayment WHERE repaymentId = @P", con);

                cmd.Parameters.AddWithValue("@P", entity.RepaymentId);

                int r = cmd.ExecuteNonQuery();

                if (r > 0)

                {

                    b = true;

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine("Delete operation failure, Cannot delete Repayment details.");

                b = false;

            }

            return b;

        }

        public List<Repayment> GetAll()

        {

            List<Repayment> Repayments = new List<Repayment>();

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Repayment", con);

            SqlDataReader sqlDr = cmd.ExecuteReader();

            while (sqlDr.Read())

            {

                Repayment r = new Repayment()

                {

                    RepaymentId = Int32.Parse(sqlDr[0].ToString()),

                    ApplicationId = Int32.Parse(sqlDr[1].ToString()),

                    DueDate = DateTime.Parse(sqlDr[2].ToString()),

                    AmountDue = Decimal.Parse(sqlDr[3].ToString()),

                    PaymentDate = DateTime.Parse(sqlDr[4].ToString()),

                    PaymentStatus = sqlDr[5].ToString()

                };

                Repayments.Add(r);

            }

            sqlDr.Close();

            return Repayments;

        }

        public Repayment GetById(object id)

        {

            int RepaymentId = Int32.Parse((string)id);

            Repayment repayObj = GetAll().Where(r => r.RepaymentId == RepaymentId).FirstOrDefault();

            return repayObj;

        }

        public bool Update(Repayment entity)

        {

            bool b = false;

            //try

            //{

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Repayment SET applicationId=@P2, dueDate=@P3, amountDue=@P4, paymentDate=@P5, paymentStatus=@P6 WHERE repaymentId=@P1", con);

            cmd.Parameters.AddWithValue("@P2", entity.ApplicationId);

            cmd.Parameters.AddWithValue("@P3", entity.DueDate);

            cmd.Parameters.AddWithValue("@P4", entity.AmountDue);

            cmd.Parameters.AddWithValue("@P5", entity.PaymentDate);

            cmd.Parameters.AddWithValue("@P6", entity.PaymentStatus);

            cmd.Parameters.AddWithValue("@P1", entity.RepaymentId);

            int r = cmd.ExecuteNonQuery();

            if (r > 0)

            {

                b = true;

            }

            //}

            //catch (Exception ex)

            //{

            //    Console.WriteLine("Update operation failure, Cannot update Repayment details.");

            //    b = false;

            //}

            return b;

        }

    }

}
