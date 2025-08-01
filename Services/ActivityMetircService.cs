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
    public class ActivityMetricService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public List<ActivityMetric> GetMetricsForActivity(string activityId)
        {
            List<ActivityMetric> list = new List<ActivityMetric>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Activity_Metric WHERE ActivityID = @ActivityID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ActivityID", activityId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ActivityMetric
                        {
                            ActivityID = reader["ActivityID"].ToString(),
                            MetricID = reader["MetricID"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return list;
        }

        public bool AddActivityMetric(ActivityMetric mapping)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Activity_Metric (ActivityID, MetricID) VALUES (@ActivityID, @MetricID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ActivityID", mapping.ActivityID);
                cmd.Parameters.AddWithValue("@MetricID", mapping.MetricID);

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

        public bool DeleteActivityMetric(string activityId, string metricId)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Activity_Metric WHERE ActivityID = @ActivityID AND MetricID = @MetricID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ActivityID", activityId);
                cmd.Parameters.AddWithValue("@MetricID", metricId);

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
