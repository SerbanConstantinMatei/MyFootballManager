﻿namespace MyFootballManagerForms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dgMatches = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homeTeamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awayTeamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnLeaderboard = new System.Windows.Forms.Button();
            this.btnWinner = new System.Windows.Forms.Button();
            this.matchListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Loser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMatches
            // 
            this.dgMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMatches.Location = new System.Drawing.Point(12, 34);
            this.dgMatches.Name = "dgMatches";
            this.dgMatches.Size = new System.Drawing.Size(591, 150);
            this.dgMatches.TabIndex = 0;
            //this.dgMatches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMatches_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // homeTeamDataGridViewTextBoxColumn
            // 
            this.homeTeamDataGridViewTextBoxColumn.DataPropertyName = "HomeTeam";
            this.homeTeamDataGridViewTextBoxColumn.HeaderText = "HomeTeam";
            this.homeTeamDataGridViewTextBoxColumn.Name = "homeTeamDataGridViewTextBoxColumn";
            // 
            // awayTeamDataGridViewTextBoxColumn
            // 
            this.awayTeamDataGridViewTextBoxColumn.DataPropertyName = "AwayTeam";
            this.awayTeamDataGridViewTextBoxColumn.HeaderText = "AwayTeam";
            this.awayTeamDataGridViewTextBoxColumn.Name = "awayTeamDataGridViewTextBoxColumn";
            // 
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "Result";
            this.resultDataGridViewTextBoxColumn.HeaderText = "Result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            // 
            // BtnLeaderboard
            // 
            this.BtnLeaderboard.Location = new System.Drawing.Point(84, 213);
            this.BtnLeaderboard.Name = "BtnLeaderboard";
            this.BtnLeaderboard.Size = new System.Drawing.Size(75, 23);
            this.BtnLeaderboard.TabIndex = 1;
            this.BtnLeaderboard.Text = "Leaderboard";
            this.BtnLeaderboard.UseVisualStyleBackColor = true;
            this.BtnLeaderboard.Click += new System.EventHandler(this.BtnLeaderboard_Click);
            // 
            // btnWinner
            // 
            this.btnWinner.Location = new System.Drawing.Point(268, 213);
            this.btnWinner.Name = "btnWinner";
            this.btnWinner.Size = new System.Drawing.Size(75, 23);
            this.btnWinner.TabIndex = 2;
            this.btnWinner.Text = "Winner";
            this.btnWinner.UseVisualStyleBackColor = true;
            this.btnWinner.Click += new System.EventHandler(this.btnWinner_Click);
            // 
            // matchListBindingSource
            // 
            this.matchListBindingSource.DataSource = typeof(MyFootballManagerObjects.MatchList);
            // 
            // Loser
            // 
            this.Loser.Location = new System.Drawing.Point(490, 213);
            this.Loser.Name = "Loser";
            this.Loser.Size = new System.Drawing.Size(75, 23);
            this.Loser.TabIndex = 3;
            this.Loser.Text = "Loser";
            this.Loser.UseVisualStyleBackColor = true;
            this.Loser.Click += new System.EventHandler(this.Loser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 261);
            this.Controls.Add(this.Loser);
            this.Controls.Add(this.btnWinner);
            this.Controls.Add(this.BtnLeaderboard);
            this.Controls.Add(this.dgMatches);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeTeamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn awayTeamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource matchListBindingSource;
        private System.Windows.Forms.Button BtnLeaderboard;
        private System.Windows.Forms.Button btnWinner;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Loser;
    }
}

