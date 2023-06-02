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
            this.dlgSelectChatlog = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectChatlog = new System.Windows.Forms.Button();
            this.btnCopytoClipboard = new System.Windows.Forms.Button();
            this.tbChatlogPath = new System.Windows.Forms.TextBox();
            this.lblChatlogPath = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnResetCounter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectChatlog
            // 
            this.btnSelectChatlog.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSelectChatlog.Location = new System.Drawing.Point(12, 12);
            this.btnSelectChatlog.Name = "btnSelectChatlog";
            this.btnSelectChatlog.Size = new System.Drawing.Size(485, 34);
            this.btnSelectChatlog.TabIndex = 0;
            this.btnSelectChatlog.Text = "Link to Chatlog";
            this.btnSelectChatlog.UseVisualStyleBackColor = false;
            this.btnSelectChatlog.Click += new System.EventHandler(this.btnSelectChatlog_Click);
            // 
            // btnCopytoClipboard
            // 
            this.btnCopytoClipboard.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCopytoClipboard.Location = new System.Drawing.Point(174, 511);
            this.btnCopytoClipboard.Name = "btnCopytoClipboard";
            this.btnCopytoClipboard.Size = new System.Drawing.Size(323, 34);
            this.btnCopytoClipboard.TabIndex = 0;
            this.btnCopytoClipboard.Text = "Copy to Clipboard";
            this.btnCopytoClipboard.UseVisualStyleBackColor = false;
            this.btnCopytoClipboard.Click += new System.EventHandler(this.btnCopytoClipboard_Click);
            // 
            // tbChatlogPath
            // 
            this.tbChatlogPath.Location = new System.Drawing.Point(87, 49);
            this.tbChatlogPath.Name = "tbChatlogPath";
            this.tbChatlogPath.ReadOnly = true;
            this.tbChatlogPath.Size = new System.Drawing.Size(410, 31);
            this.tbChatlogPath.TabIndex = 1;
            // 
            // lblChatlogPath
            // 
            this.lblChatlogPath.AutoSize = true;
            this.lblChatlogPath.Location = new System.Drawing.Point(12, 49);
            this.lblChatlogPath.Name = "lblChatlogPath";
            this.lblChatlogPath.Size = new System.Drawing.Size(78, 25);
            this.lblChatlogPath.TabIndex = 2;
            this.lblChatlogPath.Text = "Chatlog:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 548);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 25);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(82, 545);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(410, 31);
            this.tbStatus.TabIndex = 1;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 119);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(485, 386);
            this.tbOutput.TabIndex = 1;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 91);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(73, 25);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "Output:";
            // 
            // btnResetCounter
            // 
            this.btnResetCounter.BackColor = System.Drawing.Color.LightSalmon;
            this.btnResetCounter.Location = new System.Drawing.Point(12, 511);
            this.btnResetCounter.Name = "btnResetCounter";
            this.btnResetCounter.Size = new System.Drawing.Size(156, 34);
            this.btnResetCounter.TabIndex = 3;
            this.btnResetCounter.Text = "Reset Counter";
            this.btnResetCounter.UseVisualStyleBackColor = false;
            this.btnResetCounter.Click += new System.EventHandler(this.btnResetCounter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 579);
            this.Controls.Add(this.btnResetCounter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblChatlogPath);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbChatlogPath);
            this.Controls.Add(this.btnCopytoClipboard);
            this.Controls.Add(this.btnSelectChatlog);
            this.Name = "Form1";
            this.Text = "Greedy Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog dlgSelectChatlog;
        private Button btnSelectChatlog;
        private Button btnCopytoClipboard;
        private TextBox tbChatlogPath;
        private Label lblChatlogPath;
        private Label lblStatus;
        private TextBox tbStatus;
        private TextBox tbOutput;
        private Label lblOutput;
        private Button btnResetCounter;
    }
}