// File: Services/UserService.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using FitnessApp.Models;
using FitnessTracker.Models;

namespace FitnessApp.Services
{
    public class UserService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        private const int MaxFailedAttempts = 5;
        private readonly TimeSpan LockoutWindow = TimeSpan.FromMinutes(15);



        public bool RegisterUser(User user)
        {
            user.UserID = Guid.NewGuid().ToString().Trim();
            user.Password = PasswordHelper.HashPassword(user.Password);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Users (UserID, Name, UserName, Phone, Gender, Password, Dob, Height, Weight, Remark)
                               VALUES (@UserID, @Name, @UserName, @Phone, @Gender, @Password, @Dob, @Height, @Weight, @Remark)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", user.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Dob", user.Dob ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Height", user.Height ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Weight", user.Weight ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Remark", user.Remark ?? (object)DBNull.Value);

                conn.Open();

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong!" + e.Message);
                    return false;
                }
            }
        }

        public User GetUserByUserName(string username)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Users WHERE UserName = @UserName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserName", username);

                conn.Open();
                try
                {
                SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())  
                    {
                        return new User
                        {
                            UserID = reader["UserID"].ToString(),
                            Name = reader["Name"].ToString(),
                            UserName = reader["UserName"].ToString(),
                            Password = reader["Password"].ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Gender = reader["Gender"]?.ToString(),
                            Dob = reader["Dob"] as DateTime?,
                            Height = reader["Height"] as decimal?,
                            Weight = reader["Weight"] as decimal?,
                            Remark = reader["Remark"]?.ToString(),
                            DateRegistered = reader["DateRegistered"] as DateTime?
                        };
                    }
                }
                catch (Exception e) 
                {
                    MessageBox.Show("Something went wrong");
                };
                

                return null;
            }
        }


        public bool ValidateLogin(string username, string password)
        {
            var user = GetUserByUserName(username);
            if (user == null)
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            // Lock logic
            // Reset the lock status, if last failed login attempt is more than 15mins
            if (user.IsLocked)
            {
                if (user.LastFailedLogin.HasValue && DateTime.Now - user.LastFailedLogin.Value > LockoutWindow)
                {
                    ResetFailedLogin(user.UserID); // Unlock user after timeout
                }
                else
                {
                    MessageBox.Show("Account is temporarily locked. Please try again later.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            if (!VerifyPassword(password, user.Password))
            {
                IncrementFailedLogin(user.UserID, user.FailedLoginAttempts + 1);
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Success: Reset failed attempts
            ResetFailedLogin(user.UserID);
            return true;
        }

        private void IncrementFailedLogin(string userId, int failedCount)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"
            UPDATE Users
            SET FailedLoginAttempts = @FailedLoginAttempts,
                LastFailedLogin = @LastFailedLogin,
                IsLocked = CASE WHEN @FailedLoginAttempts >= @MaxAttempts THEN 1 ELSE 0 END
            WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FailedLoginAttempts", failedCount);
                cmd.Parameters.AddWithValue("@LastFailedLogin", DateTime.Now);
                cmd.Parameters.AddWithValue("@MaxAttempts", MaxFailedAttempts);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ResetFailedLogin(string userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Users
                       SET FailedLoginAttempts = 0,
                           LastFailedLogin = NULL,
                           IsLocked = 0
                       WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        private bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return PasswordHelper.HashPassword(plainPassword) == hashedPassword;
        }
    }
}
