using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnessApp.Models;
using FitnessApp.Services;

namespace FitnessTracker.Forms
{
    public partial class UserLoginForm : Form
    {
        private readonly UserService _userService = new UserService();

        public UserLoginForm()
        {
            InitializeComponent();
            this.Text = "Fitness App - Login";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValid = _userService.ValidateLogin(username, password);
            User user = _userService.GetUserByUserName(username);

            if (isValid)
            {
                MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to Goal dashboard
                GoalForm goalForm = new GoalForm(user.UserID);
                goalForm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel linkRegister;


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new FitnessTracker.Forms.UserRegisterForm();
            registerForm.ShowDialog(); // modal
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

