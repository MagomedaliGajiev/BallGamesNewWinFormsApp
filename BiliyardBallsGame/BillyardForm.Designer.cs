namespace BiliyardBallsGame
{
    partial class BillyardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            redBallLeftLabel = new Label();
            redBallRightLabel = new Label();
            redBallBottomLabel = new Label();
            redBallTopLabel = new Label();
            blueBallLeftLabel = new Label();
            blueBallTopLabel = new Label();
            blueBallRightLabel = new Label();
            blueBallBottomLabel = new Label();
            SuspendLayout();
            // 
            // redBallLeftLabel
            // 
            redBallLeftLabel.AutoSize = true;
            redBallLeftLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            redBallLeftLabel.ForeColor = Color.Red;
            redBallLeftLabel.Location = new Point(12, 177);
            redBallLeftLabel.Name = "redBallLeftLabel";
            redBallLeftLabel.Size = new Size(15, 17);
            redBallLeftLabel.TabIndex = 0;
            redBallLeftLabel.Text = "0";
            // 
            // redBallRightLabel
            // 
            redBallRightLabel.AutoSize = true;
            redBallRightLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            redBallRightLabel.ForeColor = Color.Red;
            redBallRightLabel.Location = new Point(773, 177);
            redBallRightLabel.Name = "redBallRightLabel";
            redBallRightLabel.Size = new Size(15, 17);
            redBallRightLabel.TabIndex = 1;
            redBallRightLabel.Text = "0";
            // 
            // redBallBottomLabel
            // 
            redBallBottomLabel.AutoSize = true;
            redBallBottomLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            redBallBottomLabel.ForeColor = Color.Red;
            redBallBottomLabel.Location = new Point(365, 424);
            redBallBottomLabel.Name = "redBallBottomLabel";
            redBallBottomLabel.Size = new Size(15, 17);
            redBallBottomLabel.TabIndex = 2;
            redBallBottomLabel.Text = "0";
            // 
            // redBallTopLabel
            // 
            redBallTopLabel.AutoSize = true;
            redBallTopLabel.BackColor = SystemColors.Control;
            redBallTopLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            redBallTopLabel.ForeColor = Color.Red;
            redBallTopLabel.Location = new Point(365, 9);
            redBallTopLabel.Name = "redBallTopLabel";
            redBallTopLabel.Size = new Size(15, 17);
            redBallTopLabel.TabIndex = 3;
            redBallTopLabel.Text = "0";
            // 
            // blueBallLeftLabel
            // 
            blueBallLeftLabel.AutoSize = true;
            blueBallLeftLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            blueBallLeftLabel.ForeColor = Color.Blue;
            blueBallLeftLabel.Location = new Point(12, 248);
            blueBallLeftLabel.Name = "blueBallLeftLabel";
            blueBallLeftLabel.Size = new Size(15, 17);
            blueBallLeftLabel.TabIndex = 4;
            blueBallLeftLabel.Text = "0";
            // 
            // blueBallTopLabel
            // 
            blueBallTopLabel.AutoSize = true;
            blueBallTopLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            blueBallTopLabel.ForeColor = Color.Blue;
            blueBallTopLabel.Location = new Point(435, 9);
            blueBallTopLabel.Name = "blueBallTopLabel";
            blueBallTopLabel.Size = new Size(15, 17);
            blueBallTopLabel.TabIndex = 5;
            blueBallTopLabel.Text = "0";
            // 
            // blueBallRightLabel
            // 
            blueBallRightLabel.AutoSize = true;
            blueBallRightLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            blueBallRightLabel.ForeColor = Color.Blue;
            blueBallRightLabel.Location = new Point(773, 248);
            blueBallRightLabel.Name = "blueBallRightLabel";
            blueBallRightLabel.Size = new Size(15, 17);
            blueBallRightLabel.TabIndex = 6;
            blueBallRightLabel.Text = "0";
            // 
            // blueBallBottomLabel
            // 
            blueBallBottomLabel.AutoSize = true;
            blueBallBottomLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            blueBallBottomLabel.ForeColor = Color.Blue;
            blueBallBottomLabel.Location = new Point(435, 424);
            blueBallBottomLabel.Name = "blueBallBottomLabel";
            blueBallBottomLabel.Size = new Size(15, 17);
            blueBallBottomLabel.TabIndex = 7;
            blueBallBottomLabel.Text = "0";
            // 
            // BillyardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(blueBallBottomLabel);
            Controls.Add(blueBallRightLabel);
            Controls.Add(blueBallTopLabel);
            Controls.Add(blueBallLeftLabel);
            Controls.Add(redBallTopLabel);
            Controls.Add(redBallBottomLabel);
            Controls.Add(redBallRightLabel);
            Controls.Add(redBallLeftLabel);
            Name = "BillyardForm";
            Text = "BillyardGame";
            Load += BilliardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label redBallLeftLabel;
        private Label redBallRightLabel;
        private Label redBallBottomLabel;
        private Label redBallTopLabel;
        private Label blueBallLeftLabel;
        private Label blueBallTopLabel;
        private Label blueBallRightLabel;
        private Label blueBallBottomLabel;
    }
}
