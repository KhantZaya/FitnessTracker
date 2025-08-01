//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Configuration;
//using FitnessTracker.Models;

//namespace FitnessTracker.Services
//{
//    internal class TestService
//    {
//        static string myConnString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

//        public DataTable Select()
//        {
//            // Step 1: Database Connection
//            SqlConnection conn = new SqlConnection(myConnString);
//            DataTable dt = new DataTable();

//            try
//            {
//                //Step 2: Writing SQL query
//                string sql = "SELECT * FROM tbl_contact";

//                // Create cmd using sql and conn
//                SqlCommand cmd = new SqlCommand(sql, conn);

//                // Creating SQL DataAdapter using cmd
//                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                conn.Open();

//                adapter.Fill(dt);
//            }
//            catch (Exception e)
//            {

//            }
//            finally
//            {
//                conn.Close();
//            }

//            return dt;
//        }


//        // Inserting Data into Database
//        public bool Insert(Test test)
//        {
//            // Creating a default return type and setting it's value to false
//            bool isSuccess = false;

//            // Step 1: Connect Database
//            SqlConnection conn = new SqlConnection(myConnString);

//            try
//            {
//                // Step 2: Create SQL query to insert Data
//                string sql = "INSERT INTO tbl_contact (FirstName, LastName, ContactNumber, Address, City) VALUES (@FirstName, @LastName, @ContactNumber, @Address, @City)";

//                // Creating SQL Command using sql and conn
//                SqlCommand cmd = new SqlCommand(sql, conn);

//                // Create Parameters to add data
//                //cmd.Parameters.AddWithValue("@FirstName", test.FirstName);
//                //cmd.Parameters.AddWithValue("@LastName", test.LastName);
//                //cmd.Parameters.AddWithValue("@ContactNumber", test.ContactNumber);
//                //cmd.Parameters.AddWithValue("@Address", test.Address);
//                //cmd.Parameters.AddWithValue("@City", test.City);`

//                // Connection Open Here
//                conn.Open();

//                int rows = cmd.ExecuteNonQuery();

//                // If the query runs successfully then the value of rows will be greater than zero else its value will be 0
//                if (rows > 0)
//                {
//                    isSuccess = true;
//                }
//                else
//                {
//                    isSuccess = false;
//                }


//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//            finally
//            {
//                conn.Close();
//            }

//            return isSuccess;
//        }


//        // Method to update data in database from our application
//        public bool Update(Test test)
//        {
//            // Create a default return type and set it's value to false
//            bool isSuccess = false;

//            SqlConnection conn = new SqlConnection(myConnString);

//            try
//            {
//                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@LastName, ContactNumber=@ContactNumber, Address=@Address, City=@City WHERE ContactID=@ContactID";

//                // Creating SQL Command
//                SqlCommand cmd = new SqlCommand(sql, conn);

//                // Create  Parameter to add value
//                cmd.Parameters.AddWithValue("@FirstName", test.FirstName);
//                cmd.Parameters.AddWithValue("@LastName", test.LastName);
//                cmd.Parameters.AddWithValue("@ContactNumber", test.ContactNumber);
//                cmd.Parameters.AddWithValue("@Address", test.Address);
//                cmd.Parameters.AddWithValue("@City", test.City);
//                cmd.Parameters.AddWithValue("@ContactID", test.ContactID);

//                // Open Database Connection
//                conn.Open();

//                int rows = cmd.ExecuteNonQuery();

//                // if the query runs successfully then the value of row will be greater than zero else itz value will be zero
//                if (rows > 0)
//                {
//                    isSuccess = true;
//                }
//                else
//                {
//                    isSuccess = false;
//                }

//            }
//            catch (Exception ex)
//            {

//            }
//            finally
//            {
//                conn.Close();
//            }


//            return isSuccess;
//        }


//        // Method to Delete Data from Database
//        public bool Delete(Test test)
//        {
//            // Create a default return value and set its value to false
//            bool isSuccess = false;

//            // create SQL test
//            SqlConnection conn = new SqlConnection(myConnString);

//            try
//            {
//                // SQL ro Delete Data
//                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";

//                // Creating SQL Command
//                SqlCommand cmd = new SqlCommand(sql, conn);
//                cmd.Parameters.AddWithValue("@ContactID", test.ContactID);

//                // Open Connection
//                conn.Open();

//                int rows = cmd.ExecuteNonQuery();

//                // if the query runs successfully then the value of row will be greater than zero else itz value will be zero
//                if (rows > 0)
//                {
//                    isSuccess = true;
//                }
//                else
//                {
//                    isSuccess = false;
//                }

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message.ToString());

//            }
//            finally
//            {
//                conn.Close();
//            }

//            return isSuccess;
//        }
//    };
//}
//}
