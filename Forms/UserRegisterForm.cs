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

    public partial class UserRegisterForm : Form
    {
        private readonly UserService _userService = new UserService();

        public UserRegisterForm()
        {
            InitializeComponent();
            this.Text = "Fitness App - Register";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Username must contain only letters and numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username must contain only letters and numbers.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password must be exactly 12 characters
            if (password.Length != 12)
            {
                MessageBox.Show("Password must be exactly 12 characters long.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password must contain at least one uppercase
            if (!password.Any(char.IsUpper))
            {
                MessageBox.Show("Password must contain at least one uppercase letter.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password must contain at least one lowercase
            if (!password.Any(char.IsLower))
            {
                MessageBox.Show("Password must contain at least one lowercase letter.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // height/weight formatting
            decimal? height = null;
            decimal hTemp;
            if (decimal.TryParse(txtHeight.Text, out hTemp))
                height = hTemp;

            decimal? weight = null;
            decimal wTemp;
            if (decimal.TryParse(txtWeight.Text, out wTemp))
                weight = wTemp;

            // Registration
            User newUser = new User
            {
                Name = txtName.Text.Trim(),
                UserName = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Phone = txtPhone.Text.Trim(),
                Gender = cmbGender.SelectedItem?.ToString(),
                Dob = dtpDob.Value,
                Height = height,
                Weight = weight,
                Remark = txtRemark.Text.Trim()
            };

            bool success = _userService.RegisterUser(newUser);
            if (success)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private TextBox txtName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtPhone;
        private ComboBox cmbGender;
        private DateTimePicker dtpDob;
        private TextBox txtHeight;
        private TextBox txtWeight;
        private TextBox txtRemark;
        private Button btnRegister;

        private Label lblName;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblPhone;
        private Label lblGender;
        private Label lblDob;
        private Label lblHeight;
        private Label lblWeight;
        private Label lblRemark;

        private void UserRegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void UserRegisterForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
