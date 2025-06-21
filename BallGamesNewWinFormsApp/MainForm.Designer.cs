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
            drawingButton = new Button();
            randomPointDrawingButton = new Button();
            SuspendLayout();
            // 
            // drawingButton
            // 
            drawingButton.Location = new Point(652, 28);
            drawingButton.Name = "drawingButton";
            drawingButton.Size = new Size(127, 42);
            drawingButton.TabIndex = 0;
            drawingButton.Text = "Рисовать шарик";
            drawingButton.UseVisualStyleBackColor = true;
            drawingButton.Click += drawingButton_Click;
            // 
            // randomPointDrawingButton
            // 
            randomPointDrawingButton.Location = new Point(467, 28);
            randomPointDrawingButton.Name = "randomPointDrawingButton";
            randomPointDrawingButton.Size = new Size(179, 42);
            randomPointDrawingButton.TabIndex = 1;
            randomPointDrawingButton.Text = "Рисовать случайный шарик";
            randomPointDrawingButton.UseVisualStyleBackColor = true;
            randomPointDrawingButton.Click += randomPointDrawingButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(randomPointDrawingButton);
            Controls.Add(drawingButton);
            Name = "MainForm";
            Text = "Мячики";
            ResumeLayout(false);
        }

        #endregion

        private Button drawingButton;
        private Button randomPointDrawingButton;
    }
}
