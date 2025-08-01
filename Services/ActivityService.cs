using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public class ActivityService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public List<Activity> GetAllActivities()
        {
            List<Activity> activities = new List<Activity>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Activity";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        activities.Add(new Activity
                        {
                            ActivityID = reader["ActivityID"].ToString(),
                            ActivityName = reader["ActivityName"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return activities;
        }

        public bool AddActivity(Activity activity)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Activity (ActivityID, ActivityName, Description) VALUES (@ActivityID, @ActivityName, @Description)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ActivityID", activity.ActivityID);
                cmd.Parameters.AddWithValue("@ActivityName", activity.ActivityName);
                cmd.Parameters.AddWithValue("@Description", activity.Description ?? (object)DBNull.Value);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    isSuccess = rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return isSuccess;
        }

        public bool DeleteActivity(string activityId)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Activity WHERE ActivityID = @ActivityID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ActivityID", activityId);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    isSuccess = rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return isSuccess;
        }
    }
}
