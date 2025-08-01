using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Forms
{
    public partial class GoalForm : Form
    {
        private readonly GoalService _goalService = new GoalService();
        private readonly string _userId;

        public GoalForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
            this.Text = "Set Goal";
            LoadUserGoals();
        }

        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            decimal targetCalories;
            if (!decimal.TryParse(txtTargetCalories.Text, out targetCalories))
            {
                MessageBox.Show("Please enter a valid calorie value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Goal newGoal = new Goal
            {
                GoalID = Guid.NewGuid().ToString(),
                UserID = _userId,
                Description = txtDescription.Text.Trim(),
                TargetCalories = targetCalories,
                StartDate = dtpStartDate.Value
            };

            bool success = _goalService.AddGoal(newGoal);
            if (success)
            {
                MessageBox.Show("Goal saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserGoals();
                txtDescription.Text = "";
                txtTargetCalories.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to save goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteGoal_Click(object sender, EventArgs e)
        {
            if (dgvGoals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a goal to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string goalId = dgvGoals.SelectedRows[0].Cells["GoalID"].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this goal?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = _goalService.DeleteGoal(goalId);
                if (success)
                {
                    MessageBox.Show("Goal deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserGoals();
                }
                else
                {
                    MessageBox.Show("Failed to delete goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadUserGoals()
        {
            DataTable dt = _goalService.GetGoalsByUser(_userId);
            dgvGoals.DataSource = dt;
        }

        

        private TextBox txtDescription;
        private TextBox txtTargetCalories;
        private DateTimePicker dtpStartDate;
        private Button btnSaveGoal;
        private Button btnDeleteGoal;
        private Label lblDescription;
        private Label lblTargetCalories;
        private Label lblStartDate;
        private DataGridView dgvGoals;

        private void GoalForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserActivityDashboardForm form = new UserActivityDashboardForm(_userId); 
            form.Show();
            this.Hide();

        }

        private void dgvGoals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvGoals.Columns[e.ColumnIndex] == null)
                return;

            if (dgvGoals.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                DataGridViewRow row = dgvGoals.Rows[e.RowIndex];

                switch (status)
                {
                    case "Completed":
                        row.DefaultCellStyle.BackColor = Color.Green;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "Active":
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Failed":
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        break;
                }
            }
        }


    }
}

