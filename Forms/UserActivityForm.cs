using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FitnessApp.Models;
using FitnessApp.Services;
using FitnessTracker.Domain;
using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.Forms
{
    public partial class UserActivityForm : Form
    {
        private readonly ActivityService _activityService = new ActivityService();
        private readonly MetricService _metricService = new MetricService();
        private readonly ActivityMetricService _activityMetricService = new ActivityMetricService();

        private readonly string _userId;

        private ComboBox cboActivities;
        private Panel pnlMetrics;
        private Button btnLogActivity;

        public UserActivityForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
            LoadActivities();
        }



        private void LoadActivities()
        {
            var activities = _activityService.GetAllActivities();
            cboActivities.DataSource = activities;
            cboActivities.DisplayMember = "ActivityName";
            cboActivities.ValueMember = "ActivityID";
        }

        private void CboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlMetrics.Controls.Clear();
            string activityId = cboActivities.SelectedValue.ToString();
            var metricLinks = _activityMetricService.GetMetricsForActivity(activityId);

            int top = 10;
            foreach (var link in metricLinks)
            {
                Metric metric = _metricService.GetMetricById(link.MetricID);

                Label lbl = new Label() { Text = metric.MetricName + " (" + metric.Unit + ")", Top = top, Left = 10, Width = 200 };
                TextBox txt = new TextBox() { Name = "txtMetric_" + metric.MetricID, Top = top, Left = 220, Width = 100 };

                pnlMetrics.Controls.Add(lbl);
                pnlMetrics.Controls.Add(txt);
                top += 30;
            }

        }

        private void BtnLogActivity_Click(object sender, EventArgs e)
        {
            string activityId = cboActivities.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(activityId))
            {
                MessageBox.Show("Please select an activity first.");
                return;
            }

            // 1. Collect valid metrics (at least one required)
            Dictionary<string, decimal> metricValues = new Dictionary<string, decimal>();
            bool hasValidInput = false;
            StringBuilder errorMessage = new StringBuilder();

            foreach (Control ctrl in pnlMetrics.Controls)
            {
                if (ctrl is TextBox txt && txt.Name.StartsWith("txtMetric_"))
                {
                    string metricId = txt.Name.Replace("txtMetric_", "");
                    Metric metric = _metricService.GetMetricById(metricId);

                    if (!string.IsNullOrWhiteSpace(txt.Text))
                    {
                        if (decimal.TryParse(txt.Text, out decimal value))
                        {
                            metricValues.Add(metricId, value);
                            hasValidInput = true;
                            txt.BackColor = SystemColors.Window;
                        }
                        else
                        {
                            errorMessage.AppendLine($"• {metric.MetricName}: Must be a valid number");
                            txt.BackColor = Color.LightPink;
                        }
                    }
                    else
                    {
                        txt.BackColor = SystemColors.Window; // Empty is OK now
                    }
                }
            }

            // 2. Validate at least one metric provided
            if (!hasValidInput)
            {
                MessageBox.Show("Please enter at least one metric value.",
                               "Input Required",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // 3. Process the activity
            try
            {
                ActivityBase userActivity = ActivityFactory.Create(activityId);
                decimal calories = userActivity.CalculateCalories(metricValues);

                string userActivityID = Guid.NewGuid().ToString();

                // Save to database
                UserActivityService activityService = new UserActivityService();
                bool success = activityService.AddUserActivity(
                    userActivityID, _userId, activityId, calories);

                if (success)
                {
                    foreach (var metric in metricValues)
                    {
                        activityService.AddUserActivityMetric(userActivityID, metric.Key, metric.Value);
                    }
                    MessageBox.Show($"Logged! Calories: {calories:n0}", "Success");

                    // Optional: check and update goal progress
                    GoalService goalService = new GoalService();    
                    var goals = goalService.GetGoalsByUser(_userId);

                    foreach (System.Data.DataRow row in goals.Rows)
                    {
                        if (row["Status"].ToString() != "Completed" && decimal.TryParse(row["TargetCalories"].ToString(), out decimal targetCalories))
                        {
                            if (calories >= targetCalories)
                            {
                                string goalId = row["GoalID"].ToString();
                                goalService.MarkGoalCompleted(goalId);  // You’ll add this method
                                MessageBox.Show($"🎯 The Goal: \n'{row["Description"]}' Achieved!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    // Refresh the dashboard
                    UserActivityDashboardForm userActivityDashboardForm = new UserActivityDashboardForm(_userId);
                    userActivityDashboardForm.LoadUserActivities();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Failed to save activity.", "Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Error: {ex.Message}", "Calculation Failed");
            }
        }

        

        private void UserActivityForm_Load(object sender, EventArgs e)
        {

        }
    }
}
