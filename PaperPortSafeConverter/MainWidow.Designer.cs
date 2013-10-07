namespace PaperPortSafeConverter
{
	partial class MainWindow
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
			this.grp_Setup = new System.Windows.Forms.GroupBox();
			this.chk_CopyOption = new System.Windows.Forms.CheckBox();
			this.btn_InputLocationBrowse = new System.Windows.Forms.Button();
			this.lbl_FailureLocation = new System.Windows.Forms.Label();
			this.txt_FailureLocation = new System.Windows.Forms.TextBox();
			this.lbl_SuccessLocation = new System.Windows.Forms.Label();
			this.txt_SuccessLocation = new System.Windows.Forms.TextBox();
			this.txt_InputLocation = new System.Windows.Forms.TextBox();
			this.lbl_InputLocation = new System.Windows.Forms.Label();
			this.lbl_ToolLocation = new System.Windows.Forms.Label();
			this.txt_ToolLocation = new System.Windows.Forms.TextBox();
			this.grp_Progress = new System.Windows.Forms.GroupBox();
			this.lbl_CurrentFileValue = new System.Windows.Forms.Label();
			this.lbl_CurrentFile = new System.Windows.Forms.Label();
			this.btn_StartStop = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.grp_Setup.SuspendLayout();
			this.grp_Progress.SuspendLayout();
			this.SuspendLayout();
			// 
			// grp_Setup
			// 
			this.grp_Setup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grp_Setup.Controls.Add(this.chk_CopyOption);
			this.grp_Setup.Controls.Add(this.btn_InputLocationBrowse);
			this.grp_Setup.Controls.Add(this.lbl_FailureLocation);
			this.grp_Setup.Controls.Add(this.txt_FailureLocation);
			this.grp_Setup.Controls.Add(this.lbl_SuccessLocation);
			this.grp_Setup.Controls.Add(this.txt_SuccessLocation);
			this.grp_Setup.Controls.Add(this.txt_InputLocation);
			this.grp_Setup.Controls.Add(this.lbl_InputLocation);
			this.grp_Setup.Controls.Add(this.lbl_ToolLocation);
			this.grp_Setup.Controls.Add(this.txt_ToolLocation);
			this.grp_Setup.Location = new System.Drawing.Point(12, 12);
			this.grp_Setup.Name = "grp_Setup";
			this.grp_Setup.Size = new System.Drawing.Size(649, 152);
			this.grp_Setup.TabIndex = 0;
			this.grp_Setup.TabStop = false;
			this.grp_Setup.Text = "Setup";
			this.grp_Setup.Enter += new System.EventHandler(this.grp_Setup_Enter);
			// 
			// chk_CopyOption
			// 
			this.chk_CopyOption.AutoSize = true;
			this.chk_CopyOption.Checked = true;
			this.chk_CopyOption.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_CopyOption.Enabled = false;
			this.chk_CopyOption.Location = new System.Drawing.Point(172, 127);
			this.chk_CopyOption.Name = "chk_CopyOption";
			this.chk_CopyOption.Size = new System.Drawing.Size(163, 17);
			this.chk_CopyOption.TabIndex = 9;
			this.chk_CopyOption.Text = "Move Files Rather than Copy";
			this.chk_CopyOption.UseVisualStyleBackColor = true;
			// 
			// btn_InputLocationBrowse
			// 
			this.btn_InputLocationBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_InputLocationBrowse.Location = new System.Drawing.Point(557, 44);
			this.btn_InputLocationBrowse.Name = "btn_InputLocationBrowse";
			this.btn_InputLocationBrowse.Size = new System.Drawing.Size(86, 23);
			this.btn_InputLocationBrowse.TabIndex = 8;
			this.btn_InputLocationBrowse.Text = "Browse";
			this.btn_InputLocationBrowse.UseVisualStyleBackColor = true;
			this.btn_InputLocationBrowse.Click += new System.EventHandler(this.btn_InputLocationBrowse_Click);
			// 
			// lbl_FailureLocation
			// 
			this.lbl_FailureLocation.AutoSize = true;
			this.lbl_FailureLocation.Location = new System.Drawing.Point(6, 103);
			this.lbl_FailureLocation.Name = "lbl_FailureLocation";
			this.lbl_FailureLocation.Size = new System.Drawing.Size(117, 13);
			this.lbl_FailureLocation.TabIndex = 7;
			this.lbl_FailureLocation.Text = "Failure Output Location";
			// 
			// txt_FailureLocation
			// 
			this.txt_FailureLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_FailureLocation.Enabled = false;
			this.txt_FailureLocation.Location = new System.Drawing.Point(172, 100);
			this.txt_FailureLocation.Name = "txt_FailureLocation";
			this.txt_FailureLocation.Size = new System.Drawing.Size(379, 20);
			this.txt_FailureLocation.TabIndex = 6;
			// 
			// lbl_SuccessLocation
			// 
			this.lbl_SuccessLocation.AutoSize = true;
			this.lbl_SuccessLocation.Location = new System.Drawing.Point(6, 76);
			this.lbl_SuccessLocation.Name = "lbl_SuccessLocation";
			this.lbl_SuccessLocation.Size = new System.Drawing.Size(127, 13);
			this.lbl_SuccessLocation.TabIndex = 5;
			this.lbl_SuccessLocation.Text = "Success Output Location";
			// 
			// txt_SuccessLocation
			// 
			this.txt_SuccessLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_SuccessLocation.Enabled = false;
			this.txt_SuccessLocation.Location = new System.Drawing.Point(172, 73);
			this.txt_SuccessLocation.Name = "txt_SuccessLocation";
			this.txt_SuccessLocation.Size = new System.Drawing.Size(379, 20);
			this.txt_SuccessLocation.TabIndex = 4;
			// 
			// txt_InputLocation
			// 
			this.txt_InputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_InputLocation.Location = new System.Drawing.Point(172, 46);
			this.txt_InputLocation.Name = "txt_InputLocation";
			this.txt_InputLocation.Size = new System.Drawing.Size(379, 20);
			this.txt_InputLocation.TabIndex = 3;
			// 
			// lbl_InputLocation
			// 
			this.lbl_InputLocation.AutoSize = true;
			this.lbl_InputLocation.Location = new System.Drawing.Point(6, 49);
			this.lbl_InputLocation.Name = "lbl_InputLocation";
			this.lbl_InputLocation.Size = new System.Drawing.Size(75, 13);
			this.lbl_InputLocation.TabIndex = 2;
			this.lbl_InputLocation.Text = "Input Location";
			// 
			// lbl_ToolLocation
			// 
			this.lbl_ToolLocation.AutoSize = true;
			this.lbl_ToolLocation.Location = new System.Drawing.Point(6, 22);
			this.lbl_ToolLocation.Name = "lbl_ToolLocation";
			this.lbl_ToolLocation.Size = new System.Drawing.Size(128, 13);
			this.lbl_ToolLocation.TabIndex = 1;
			this.lbl_ToolLocation.Text = "Conversion Tool Location";
			// 
			// txt_ToolLocation
			// 
			this.txt_ToolLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_ToolLocation.Enabled = false;
			this.txt_ToolLocation.Location = new System.Drawing.Point(172, 19);
			this.txt_ToolLocation.Name = "txt_ToolLocation";
			this.txt_ToolLocation.Size = new System.Drawing.Size(379, 20);
			this.txt_ToolLocation.TabIndex = 0;
			// 
			// grp_Progress
			// 
			this.grp_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grp_Progress.Controls.Add(this.lbl_CurrentFileValue);
			this.grp_Progress.Controls.Add(this.lbl_CurrentFile);
			this.grp_Progress.Controls.Add(this.btn_StartStop);
			this.grp_Progress.Location = new System.Drawing.Point(12, 170);
			this.grp_Progress.Name = "grp_Progress";
			this.grp_Progress.Size = new System.Drawing.Size(649, 180);
			this.grp_Progress.TabIndex = 1;
			this.grp_Progress.TabStop = false;
			this.grp_Progress.Text = "Progress";
			// 
			// lbl_CurrentFileValue
			// 
			this.lbl_CurrentFileValue.Location = new System.Drawing.Point(72, 45);
			this.lbl_CurrentFileValue.Name = "lbl_CurrentFileValue";
			this.lbl_CurrentFileValue.Size = new System.Drawing.Size(570, 51);
			this.lbl_CurrentFileValue.TabIndex = 2;
			// 
			// lbl_CurrentFile
			// 
			this.lbl_CurrentFile.AutoSize = true;
			this.lbl_CurrentFile.Location = new System.Drawing.Point(6, 45);
			this.lbl_CurrentFile.Name = "lbl_CurrentFile";
			this.lbl_CurrentFile.Size = new System.Drawing.Size(60, 13);
			this.lbl_CurrentFile.TabIndex = 1;
			this.lbl_CurrentFile.Text = "Current File";
			// 
			// btn_StartStop
			// 
			this.btn_StartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_StartStop.Location = new System.Drawing.Point(557, 19);
			this.btn_StartStop.Name = "btn_StartStop";
			this.btn_StartStop.Size = new System.Drawing.Size(85, 23);
			this.btn_StartStop.TabIndex = 0;
			this.btn_StartStop.Text = "Start";
			this.btn_StartStop.UseVisualStyleBackColor = true;
			this.btn_StartStop.Click += new System.EventHandler(this.btn_StartStop_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(673, 362);
			this.Controls.Add(this.grp_Progress);
			this.Controls.Add(this.grp_Setup);
			this.Name = "MainWindow";
			this.Text = "PaperPort Safe Converter";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.grp_Setup.ResumeLayout(false);
			this.grp_Setup.PerformLayout();
			this.grp_Progress.ResumeLayout(false);
			this.grp_Progress.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grp_Setup;
		private System.Windows.Forms.TextBox txt_InputLocation;
		private System.Windows.Forms.Label lbl_InputLocation;
		private System.Windows.Forms.Label lbl_ToolLocation;
		private System.Windows.Forms.TextBox txt_ToolLocation;
		private System.Windows.Forms.Button btn_InputLocationBrowse;
		private System.Windows.Forms.Label lbl_FailureLocation;
		private System.Windows.Forms.TextBox txt_FailureLocation;
		private System.Windows.Forms.Label lbl_SuccessLocation;
		private System.Windows.Forms.TextBox txt_SuccessLocation;
		private System.Windows.Forms.GroupBox grp_Progress;
		private System.Windows.Forms.CheckBox chk_CopyOption;
		private System.Windows.Forms.Button btn_StartStop;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label lbl_CurrentFileValue;
		private System.Windows.Forms.Label lbl_CurrentFile;
	}
}

