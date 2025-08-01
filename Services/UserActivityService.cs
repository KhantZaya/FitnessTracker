using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FitnessTracker.Services
{
    public class UserActivityService
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool AddUserActivity(string userActivityId, string userId, string activityId, decimal caloriesBurned)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "INSERT INTO UserActivity (UserActivityID, UserID, ActivityID, DatePerformed, CaloriesBurned) " +
                               "VALUES (@UserActivityID, @UserID, @ActivityID, GETDATE(), @CaloriesBurned)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserActivityID", userActivityId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ActivityID", activityId);
                cmd.Parameters.AddWithValue("@CaloriesBurned", caloriesBurned);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool AddUserActivityMetric(string userActivityId, string metricId, decimal value)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "INSERT INTO UserActivityMetric (UserActivityID, MetricID, Value) VALUES (@UserActivityID, @MetricID, @Value)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserActivityID", userActivityId);
                cmd.Parameters.AddWithValue("@MetricID", metricId);
                cmd.Parameters.AddWithValue("@Value", value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public decimal CalculateCalories(string activityId, Control metricPanel)
        {
            // Dummy logic for now, real logic would depend on activity + metric
            decimal calories = 0;
            foreach (Control ctrl in metricPanel.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    if (decimal.TryParse(txt.Text, out decimal value))
                        calories += value; // Add weight, distance etc.
                }
            }
            return calories;
        }

        public DataTable GetUserActivitiesByUser(string userId)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = @"
                    SELECT UA.DatePerformed, A.ActivityName, UA.CaloriesBurned
                    FROM UserActivity UA
                    INNER JOIN Activity A ON UA.ActivityID = A.ActivityID
                    WHERE UA.UserID = @UserID
                    ORDER BY UA.DatePerformed DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
