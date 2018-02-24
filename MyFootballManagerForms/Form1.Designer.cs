namespace MyFootballManagerForms
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
            this.matchListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homeTeamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awayTeamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMatches
            // 
            this.dgMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMatches.AutoGenerateColumns = true;
           
            this.dgMatches.Location = new System.Drawing.Point(12, 34);
            this.dgMatches.Name = "dgMatches";
            this.dgMatches.Size = new System.Drawing.Size(591, 150);
            this.dgMatches.TabIndex = 0;
            // 
            // matchListBindingSource
            // 
            this.matchListBindingSource.DataSource = typeof(MyFootballManagerObjects.MatchList);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 261);
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
    }
}

