using System.Windows.Forms;
using System;

namespace FitnessTracker.Forms
{
    partial class GoalForm
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
        private void InitializeComponent()
        {

            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTargetCalories = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveGoal = new System.Windows.Forms.Button();
            this.btnDeleteGoal = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTargetCalories = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dgvGoals = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvGoals.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGoals_CellFormatting);

            ((System.ComponentModel.ISupportInitialize)(this.dgvGoals)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(30, 50);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 26);
            this.txtDescription.TabIndex = 1;
            // 
            // txtTargetCalories
            // 
            this.txtTargetCalories.Location = new System.Drawing.Point(272, 49);
            this.txtTargetCalories.Name = "txtTargetCalories";
            this.txtTargetCalories.Size = new System.Drawing.Size(200, 26);
            this.txtTargetCalories.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(520, 50);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 26);
            this.dtpStartDate.TabIndex = 5;
            // 
            // btnSaveGoal
            // 
            this.btnSaveGoal.Location = new System.Drawing.Point(837, 29);
            this.btnSaveGoal.Name = "btnSaveGoal";
            this.btnSaveGoal.Size = new System.Drawing.Size(116, 48);
            this.btnSaveGoal.TabIndex = 6;
            this.btnSaveGoal.Text = "Save Goal";
            this.btnSaveGoal.Click += new System.EventHandler(this.btnSaveGoal_Click);
            // 
            // btnDeleteGoal
            // 
            this.btnDeleteGoal.Location = new System.Drawing.Point(704, 517);
            this.btnDeleteGoal.Name = "btnDeleteGoal";
            this.btnDeleteGoal.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteGoal.TabIndex = 7;
            this.btnDeleteGoal.Text = "Delete Goal";
            this.btnDeleteGoal.Click += new System.EventHandler(this.btnDeleteGoal_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(30, 20);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 20);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // lblTargetCalories
            // 
            this.lblTargetCalories.Location = new System.Drawing.Point(272, 20);
            this.lblTargetCalories.Name = "lblTargetCalories";
            this.lblTargetCalories.Size = new System.Drawing.Size(100, 17);
            this.lblTargetCalories.TabIndex = 2;
            this.lblTargetCalories.Text = "Target Calories:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(520, 20);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(100, 20);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dgvGoals
            // 
            this.dgvGoals.AllowUserToAddRows = false;
            this.dgvGoals.AllowUserToDeleteRows = false;
            this.dgvGoals.ColumnHeadersHeight = 34;
            this.dgvGoals.Location = new System.Drawing.Point(30, 144);
            this.dgvGoals.Name = "dgvGoals";
            this.dgvGoals.ReadOnly = true;
            this.dgvGoals.RowHeadersWidth = 62;
            this.dgvGoals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoals.Size = new System.Drawing.Size(774, 352);
            this.dgvGoals.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "To Activity";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GoalForm
            // 
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTargetCalories);
            this.Controls.Add(this.txtTargetCalories);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnSaveGoal);
            this.Controls.Add(this.btnDeleteGoal);
            this.Controls.Add(this.dgvGoals);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "GoalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GoalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        #endregion

        private Button button1;
    }
}