namespace MvcArchitecture.Views
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
            TestButton = new Button();
            TestTextBox = new TextBox();
            SuspendLayout();
            // 
            // TestButton
            // 
            TestButton.Location = new Point(19, 19);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(75, 23);
            TestButton.TabIndex = 0;
            TestButton.Text = "Click";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // TestTextBox
            // 
            TestTextBox.Location = new Point(18, 67);
            TestTextBox.Name = "TestTextBox";
            TestTextBox.Size = new Size(100, 23);
            TestTextBox.TabIndex = 1;
            TestTextBox.Text = "Default";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(203, 137);
            Controls.Add(TestTextBox);
            Controls.Add(TestButton);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TestButton;
        private TextBox TestTextBox;
    }
}