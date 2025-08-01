using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public class GoalService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool AddGoal(Goal goal)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Goal (GoalID, UserID, Description, TargetCalories, StartDate) " +
                             "VALUES (@GoalID, @UserID, @Description, @TargetCalories, @StartDate)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@GoalID", goal.GoalID);
                cmd.Parameters.AddWithValue("@UserID", goal.UserID);
                cmd.Parameters.AddWithValue("@Description", goal.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TargetCalories", goal.TargetCalories);
                cmd.Parameters.AddWithValue("@StartDate", goal.StartDate);

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

        public DataTable GetGoalsByUser(string userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Goal WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dt;
        }

        public bool DeleteGoal(string goalId)
        {
            bool isSuccess = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Goal WHERE GoalID = @GoalID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@GoalID", goalId);

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

        public bool MarkGoalCompleted(string goalId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Goal SET Status = 'Completed' WHERE GoalID = @GoalID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@GoalID", goalId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
