namespace BallGamesNewWinFormsApp
{
    partial class MainForm
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
            randomPointDrawingButton = new Button();
            stopButton = new Button();
            CreateBallsButton = new Button();
            SuspendLayout();
            // 
            // randomPointDrawingButton
            // 
            randomPointDrawingButton.Location = new Point(438, 12);
            randomPointDrawingButton.Name = "randomPointDrawingButton";
            randomPointDrawingButton.Size = new Size(179, 42);
            randomPointDrawingButton.TabIndex = 1;
            randomPointDrawingButton.Text = "Рисовать случайный шарик";
            randomPointDrawingButton.UseVisualStyleBackColor = true;
            randomPointDrawingButton.Click += randomPointDrawingButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(623, 42);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(155, 42);
            stopButton.TabIndex = 2;
            stopButton.Text = "Остановить все шарики";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // CreateBallsButton
            // 
            CreateBallsButton.Location = new Point(438, 71);
            CreateBallsButton.Name = "CreateBallsButton";
            CreateBallsButton.Size = new Size(179, 42);
            CreateBallsButton.TabIndex = 3;
            CreateBallsButton.Text = "Много шариков";
            CreateBallsButton.UseVisualStyleBackColor = true;
            CreateBallsButton.Click += createBallsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateBallsButton);
            Controls.Add(stopButton);
            Controls.Add(randomPointDrawingButton);
            Name = "MainForm";
            Text = "Мячики";
            MouseDown += MainForm_MouseDown;
            ResumeLayout(false);
        }

        #endregion
        private Button randomPointDrawingButton;
        private Button stopButton;
        private Button CreateBallsButton;
    }
}
