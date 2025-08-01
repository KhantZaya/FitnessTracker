using System.Drawing;
using System.Windows.Forms;

namespace FitnessTracker.Forms
{
    partial class UserActivityDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // UserActivityDashboardForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(278, 244);
        //    this.Name = "UserActivityDashboardForm";
        //    this.Load += new System.EventHandler(this.UserActivityDashboardForm_Load_1);
        //    this.ResumeLayout(false);

        //}
        private void InitializeComponent()
        {
            this.btnAddActivity = new System.Windows.Forms.Button();
            this.dgvUserActivities = new System.Windows.Forms.DataGridView();
            this.btnBackToGoals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddActivity
            // 
            this.btnAddActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddActivity.Location = new System.Drawing.Point(703, 455);
            this.btnAddActivity.Name = "btnAddActivity";
            this.btnAddActivity.Size = new System.Drawing.Size(142, 41);
            this.btnAddActivity.TabIndex = 0;
            this.btnAddActivity.Text = "Add Activity";
            this.btnAddActivity.UseVisualStyleBackColor = true;
            this.btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);
            // 
            // dgvUserActivities
            // 
            this.dgvUserActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserActivities.ColumnHeadersHeight = 34;
            this.dgvUserActivities.Location = new System.Drawing.Point(20, 20);
            this.dgvUserActivities.Name = "dgvUserActivities";
            this.dgvUserActivities.ReadOnly = true;
            this.dgvUserActivities.RowHeadersWidth = 62;
            this.dgvUserActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserActivities.Size = new System.Drawing.Size(780, 400);
            this.dgvUserActivities.TabIndex = 1;
            // 
            // btnBackToGoals
            // 
            this.btnBackToGoals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackToGoals.Location = new System.Drawing.Point(17, 455);
            this.btnBackToGoals.Name = "btnBackToGoals";
            this.btnBackToGoals.Size = new System.Drawing.Size(142, 41);
            this.btnBackToGoals.TabIndex = 2;
            this.btnBackToGoals.Text = "Back to Goals";
            this.btnBackToGoals.UseVisualStyleBackColor = true;
            this.btnBackToGoals.Click += new System.EventHandler(this.btnBackToGoals_Click);
            // 
            // UserActivityDashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(974, 584);
            this.Controls.Add(this.btnBackToGoals);
            this.Controls.Add(this.btnAddActivity);
            this.Controls.Add(this.dgvUserActivities);
            this.Name = "UserActivityDashboardForm";
            this.Load += new System.EventHandler(this.UserActivityDashboardForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserActivities)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private Button btnAddActivity;
        private Button btnBackToGoals;
    }
}