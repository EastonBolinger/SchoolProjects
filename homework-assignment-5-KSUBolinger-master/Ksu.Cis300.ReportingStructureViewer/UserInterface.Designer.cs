namespace Ksu.Cis300.ReportingStructureViewer
{
    partial class UserInterface
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
            this.uxOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxLookup = new System.Windows.Forms.Button();
            this.uxListBox = new System.Windows.Forms.ListBox();
            this.uxGenerateReport = new System.Windows.Forms.Button();
            this.uxUpDown = new System.Windows.Forms.NumericUpDown();
            this.uxDepthLabel = new System.Windows.Forms.Label();
            this.uxWebBrowser = new System.Windows.Forms.WebBrowser();
            this.uxSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uxUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uxOpenFile
            // 
            this.uxOpenFile.Title = "Open Organization File";
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(16, 15);
            this.uxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.Size = new System.Drawing.Size(134, 22);
            this.uxTextBox.TabIndex = 0;
            this.uxTextBox.TextChanged += new System.EventHandler(this.uxTextBox_TextChanged_1);
            // 
            // uxLookup
            // 
            this.uxLookup.Enabled = false;
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uxLookup.Location = new System.Drawing.Point(161, 15);
            this.uxLookup.Margin = new System.Windows.Forms.Padding(4);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(100, 24);
            this.uxLookup.TabIndex = 1;
            this.uxLookup.Text = "Lookup";
            this.uxLookup.UseVisualStyleBackColor = true;
            this.uxLookup.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxListBox
            // 
            this.uxListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxListBox.FormattingEnabled = true;
            this.uxListBox.ItemHeight = 16;
            this.uxListBox.Location = new System.Drawing.Point(16, 44);
            this.uxListBox.Name = "uxListBox";
            this.uxListBox.Size = new System.Drawing.Size(245, 308);
            this.uxListBox.TabIndex = 2;
            this.uxListBox.SelectedIndexChanged += new System.EventHandler(this.uxListBox_SelectedIndexChanged);
            // 
            // uxGenerateReport
            // 
            this.uxGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxGenerateReport.Enabled = false;
            this.uxGenerateReport.Location = new System.Drawing.Point(130, 358);
            this.uxGenerateReport.Name = "uxGenerateReport";
            this.uxGenerateReport.Size = new System.Drawing.Size(131, 23);
            this.uxGenerateReport.TabIndex = 3;
            this.uxGenerateReport.Text = "Generate Report";
            this.uxGenerateReport.UseVisualStyleBackColor = true;
            this.uxGenerateReport.Click += new System.EventHandler(this.uxGenerateReport_Click);
            // 
            // uxUpDown
            // 
            this.uxUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxUpDown.Location = new System.Drawing.Point(73, 359);
            this.uxUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.uxUpDown.Name = "uxUpDown";
            this.uxUpDown.Size = new System.Drawing.Size(51, 22);
            this.uxUpDown.TabIndex = 4;
            this.uxUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // uxDepthLabel
            // 
            this.uxDepthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxDepthLabel.AutoSize = true;
            this.uxDepthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxDepthLabel.Location = new System.Drawing.Point(22, 361);
            this.uxDepthLabel.Name = "uxDepthLabel";
            this.uxDepthLabel.Size = new System.Drawing.Size(46, 17);
            this.uxDepthLabel.TabIndex = 5;
            this.uxDepthLabel.Text = "Depth";
            // 
            // uxWebBrowser
            // 
            this.uxWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxWebBrowser.Location = new System.Drawing.Point(267, 15);
            this.uxWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uxWebBrowser.Name = "uxWebBrowser";
            this.uxWebBrowser.Size = new System.Drawing.Size(455, 337);
            this.uxWebBrowser.TabIndex = 6;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 412);
            this.Controls.Add(this.uxWebBrowser);
            this.Controls.Add(this.uxDepthLabel);
            this.Controls.Add(this.uxUpDown);
            this.Controls.Add(this.uxGenerateReport);
            this.Controls.Add(this.uxListBox);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserInterface";
            this.Text = "Team Lookup";
            this.Load += new System.EventHandler(this.UserInterface_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.uxUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog uxOpenFile;
        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.Button uxLookup;
        private System.Windows.Forms.ListBox uxListBox;
        private System.Windows.Forms.Button uxGenerateReport;
        private System.Windows.Forms.NumericUpDown uxUpDown;
        private System.Windows.Forms.Label uxDepthLabel;
        private System.Windows.Forms.WebBrowser uxWebBrowser;
        private System.Windows.Forms.SaveFileDialog uxSaveFileDialog;
    }
}

