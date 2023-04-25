namespace GreedyCounter
{
    partial class Form1
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
            dlgSelectChatlog = new OpenFileDialog();
            btnSelectChatlog = new Button();
            SuspendLayout();
            // 
            // btnSelectChatlog
            // 
            btnSelectChatlog.BackColor = Color.LightSalmon;
            btnSelectChatlog.Location = new Point(12, 12);
            btnSelectChatlog.Name = "btnSelectChatlog";
            btnSelectChatlog.Size = new Size(485, 34);
            btnSelectChatlog.TabIndex = 0;
            btnSelectChatlog.Text = "Link to Chatlog";
            btnSelectChatlog.UseVisualStyleBackColor = false;
            btnSelectChatlog.Click += btnSelectChatlog_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 579);
            Controls.Add(btnSelectChatlog);
            Name = "Form1";
            Text = "Greedy Counter";
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog dlgSelectChatlog;
        private Button btnSelectChatlog;
    }
}