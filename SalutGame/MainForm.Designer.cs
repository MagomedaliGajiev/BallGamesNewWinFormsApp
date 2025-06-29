namespace SalutGame
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
            launchRocketButton = new Button();
            SuspendLayout();
            // 
            // launchRocketButton
            // 
            launchRocketButton.Location = new Point(12, 12);
            launchRocketButton.Name = "launchRocketButton";
            launchRocketButton.Size = new Size(114, 25);
            launchRocketButton.TabIndex = 0;
            launchRocketButton.Text = "Запустить рокету";
            launchRocketButton.UseVisualStyleBackColor = true;
            launchRocketButton.Click += launchRocketButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(launchRocketButton);
            Name = "MainForm";
            Text = "Salut";
            Load += MainForm_Load;
            MouseDown += MainForm_MouseDown;
            ResumeLayout(false);
        }

        #endregion

        private Button launchRocketButton;
    }
}
