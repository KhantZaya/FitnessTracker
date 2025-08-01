using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace FitnessTracker.Forms
{
    partial class UserActivityForm
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
        //    this.lblActivity = new System.Windows.Forms.Label();
        //    this.cboActivities = new System.Windows.Forms.ComboBox();
        //    this.pnlMetrics = new System.Windows.Forms.Panel();
        //    this.btnLogActivity = new System.Windows.Forms.Button();
        //    this.SuspendLayout();
        //    // 
        //    // lblActivity
        //    // 
        //    this.lblActivity.Location = new System.Drawing.Point(0, 0);
        //    this.lblActivity.Name = "lblActivity";
        //    this.lblActivity.Size = new System.Drawing.Size(100, 23);
        //    this.lblActivity.TabIndex = 0;
        //    // 
        //    // cboActivities
        //    // 
        //    this.cboActivities.Location = new System.Drawing.Point(0, 0);
        //    this.cboActivities.Name = "cboActivities";
        //    this.cboActivities.Size = new System.Drawing.Size(121, 28);
        //    this.cboActivities.TabIndex = 1;
        //    this.cboActivities.SelectedIndexChanged += new System.EventHandler(this.CboActivities_SelectedIndexChanged);
        //    // 
        //    // pnlMetrics
        //    // 
        //    this.pnlMetrics.Location = new System.Drawing.Point(0, 0);
        //    this.pnlMetrics.Name = "pnlMetrics";
        //    this.pnlMetrics.Size = new System.Drawing.Size(200, 100);
        //    this.pnlMetrics.TabIndex = 2;
        //    // 
        //    // btnLogActivity
        //    // 
        //    this.btnLogActivity.Location = new System.Drawing.Point(0, 0);
        //    this.btnLogActivity.Name = "btnLogActivity";
        //    this.btnLogActivity.Size = new System.Drawing.Size(75, 23);
        //    this.btnLogActivity.TabIndex = 3;
        //    // 
        //    // UserActivityForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(578, 444);
        //    this.Controls.Add(this.lblActivity);
        //    this.Controls.Add(this.cboActivities);
        //    this.Controls.Add(this.pnlMetrics);
        //    this.Controls.Add(this.btnLogActivity);
        //    this.Name = "UserActivityForm";
        //    this.Text = "Log User Activity";
        //    this.Load += new System.EventHandler(this.UserActivityForm_Load);
        //    this.ResumeLayout(false);

        //}

        private void InitializeComponent()
        {
            this.lblActivity = new System.Windows.Forms.Label();
            this.cboActivities = new System.Windows.Forms.ComboBox();
            this.pnlMetrics = new System.Windows.Forms.Panel();
            this.btnLogActivity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.Location = new System.Drawing.Point(20, 20);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(111, 20);
            this.lblActivity.TabIndex = 0;
            this.lblActivity.Text = "Select Activity:";
            // 
            // cboActivities
            // 
            this.cboActivities.Location = new System.Drawing.Point(180, 20);
            this.cboActivities.Name = "cboActivities";
            this.cboActivities.Size = new System.Drawing.Size(300, 28);
            this.cboActivities.TabIndex = 0;
            this.cboActivities.SelectedIndexChanged += new System.EventHandler(this.CboActivities_SelectedIndexChanged);
            // 
            // pnlMetrics
            // 
            this.pnlMetrics.AutoScroll = true;
            this.pnlMetrics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMetrics.Location = new System.Drawing.Point(20, 70);
            this.pnlMetrics.Name = "pnlMetrics";
            this.pnlMetrics.Size = new System.Drawing.Size(500, 300);
            this.pnlMetrics.TabIndex = 1;
            // 
            // btnLogActivity
            // 
            this.btnLogActivity.Location = new System.Drawing.Point(20, 380);
            this.btnLogActivity.Name = "btnLogActivity";
            this.btnLogActivity.Size = new System.Drawing.Size(150, 40);
            this.btnLogActivity.TabIndex = 2;
            this.btnLogActivity.Text = "Add Activity";
            this.btnLogActivity.Click += new System.EventHandler(this.BtnLogActivity_Click);
            // 
            // UserActivityForm
            // 
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.lblActivity);
            this.Controls.Add(this.cboActivities);
            this.Controls.Add(this.pnlMetrics);
            this.Controls.Add(this.btnLogActivity);
            this.Name = "UserActivityForm";
            this.Text = "Log User Activity";
            this.Load += new System.EventHandler(this.UserActivityForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActivity;
    }
}