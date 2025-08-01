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
    public class MetricService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public List<Metric> GetAllMetrics()
        {
            List<Metric> metrics = new List<Metric>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Metric";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        metrics.Add(new Metric
                        {
                            MetricID = reader["MetricID"].ToString(),
                            MetricName = reader["MetricName"].ToString(),
                            Unit = reader["Unit"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return metrics;
        }

        public bool AddMetric(Metric metric)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Metric (MetricID, MetricName, Unit) VALUES (@MetricID, @MetricName, @Unit)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MetricID", metric.MetricID);
                cmd.Parameters.AddWithValue("@MetricName", metric.MetricName);
                cmd.Parameters.AddWithValue("@Unit", metric.Unit);

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

        public bool DeleteMetric(string metricId)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Metric WHERE MetricID = @MetricID";
                SqlCommand cmd = new SqlCommand(sql, conn);
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

        public Metric GetMetricById(string metricId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT MetricID, MetricName, Unit FROM Metric WHERE MetricID = @MetricID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MetricID", metricId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Metric
                        {
                            MetricID = reader["MetricID"].ToString(),
                            MetricName = reader["MetricName"].ToString(),
                            Unit = reader["Unit"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}
