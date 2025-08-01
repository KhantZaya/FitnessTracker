using FitnessTracker.Services;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace FitnessTracker.Forms
{
    public partial class UserActivityDashboardForm : Form
    {
        private readonly string _userId;
        private readonly UserActivityService _userActivityService = new UserActivityService();

        private DataGridView dgvUserActivities;

        public UserActivityDashboardForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
            this.Load += UserActivityDashboardForm_Load_1; // Moved load to here!
        }

        


        public void LoadUserActivities()
        {
            DataTable dt = _userActivityService.GetUserActivitiesByUser(_userId);
            dgvUserActivities.DataSource = dt;
        }

        private void UserActivityDashboardForm_Load_1(object sender, EventArgs e)
        {
            LoadUserActivities();
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            UserActivityForm form = new UserActivityForm(_userId);
            form.Show();
        }

        private void btnBackToGoals_Click(object sender, EventArgs e)
        {
            GoalForm form = new GoalForm(_userId);
            form.Show();
            this.Hide();
        }
    }
}
