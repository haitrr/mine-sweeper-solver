namespace MineSweeperSolver
{
    partial class MainForm
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
            this.solveButton = new System.Windows.Forms.Button();
            this.inputRankTextBox = new System.Windows.Forms.TextBox();
            this.inputColumnTextBox = new System.Windows.Forms.TextBox();
            this.rankLable = new System.Windows.Forms.Label();
            this.columnLable = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.mapPanel = new MineSweeperSolver.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(645, 12);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(68, 23);
            this.solveButton.TabIndex = 0;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.onSolveButtonClick);
            // 
            // inputRankTextBox
            // 
            this.inputRankTextBox.Location = new System.Drawing.Point(642, 121);
            this.inputRankTextBox.Name = "inputRankTextBox";
            this.inputRankTextBox.Size = new System.Drawing.Size(71, 20);
            this.inputRankTextBox.TabIndex = 2;
            this.inputRankTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputRankTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onInputRankTextBoxKeyPress);
            // 
            // inputColumnTextBox
            // 
            this.inputColumnTextBox.Location = new System.Drawing.Point(642, 181);
            this.inputColumnTextBox.Name = "inputColumnTextBox";
            this.inputColumnTextBox.Size = new System.Drawing.Size(68, 20);
            this.inputColumnTextBox.TabIndex = 3;
            this.inputColumnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputColumnTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onInputColumnTextBoxKeyPress);
            // 
            // rankLable
            // 
            this.rankLable.AutoSize = true;
            this.rankLable.Location = new System.Drawing.Point(656, 105);
            this.rankLable.Name = "rankLable";
            this.rankLable.Size = new System.Drawing.Size(33, 13);
            this.rankLable.TabIndex = 4;
            this.rankLable.Text = "Rank";
            this.rankLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnLable
            // 
            this.columnLable.AutoSize = true;
            this.columnLable.Location = new System.Drawing.Point(656, 165);
            this.columnLable.Name = "columnLable";
            this.columnLable.Size = new System.Drawing.Size(42, 13);
            this.columnLable.TabIndex = 5;
            this.columnLable.Text = "Column";
            this.columnLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(642, 220);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(68, 23);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.onApplyButtonClick);
            // 
            // mapPanel
            // 
            this.mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mapPanel.Location = new System.Drawing.Point(10, 10);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(625, 625);
            this.mapPanel.TabIndex = 1;
            this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.onMapPanelPaint);
            this.mapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onMapPanelClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 647);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.columnLable);
            this.Controls.Add(this.rankLable);
            this.Controls.Add(this.inputColumnTextBox);
            this.Controls.Add(this.inputRankTextBox);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.solveButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mine Sweeper Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button solveButton;
        private DoubleBufferedPanel mapPanel;
        private System.Windows.Forms.TextBox inputRankTextBox;
        private System.Windows.Forms.TextBox inputColumnTextBox;
        private System.Windows.Forms.Label rankLable;
        private System.Windows.Forms.Label columnLable;
        private System.Windows.Forms.Button applyButton;
    }
}

