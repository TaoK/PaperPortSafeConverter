using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PaperPortSafeConverter
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			if (!Properties.Settings.Default.UpgradeCompleted)
			{
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.UpgradeCompleted = true;
				Properties.Settings.Default.Save();
			}

			txt_ToolLocation.Text = Properties.Settings.Default.ConverterLocation;
			txt_InputLocation.Text = Properties.Settings.Default.LastInputLocation;
		 	txt_SuccessLocation.Text = Properties.Settings.Default.LastSuccessLocation;
			txt_FailureLocation.Text = Properties.Settings.Default.LastFailureLocation;
			chk_CopyOption.Checked = Properties.Settings.Default.LastCopyOption;
		}

		private void grp_Setup_Enter(object sender, EventArgs e)
		{

		}

		private void btn_InputLocationBrowse_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_InputLocation.Text))
				folderBrowserDialog1.SelectedPath = txt_InputLocation.Text;

			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				SaveInputPath(folderBrowserDialog1.SelectedPath);
			}

		}

		private void SaveInputPath(string inputPath)
		{
			txt_InputLocation.Text = inputPath;
			var inputDirectory = new System.IO.DirectoryInfo(txt_InputLocation.Text);
			var parentFolder = inputDirectory.Parent.FullName;
			var inputName = inputDirectory.Name;
			txt_SuccessLocation.Text = System.IO.Path.Combine(parentFolder, inputName + "_" + "ConversionSuccess");
			txt_FailureLocation.Text = System.IO.Path.Combine(parentFolder, inputName + "_" + "ConversionFailure");

			Properties.Settings.Default.ConverterLocation = txt_ToolLocation.Text;
			Properties.Settings.Default.LastInputLocation = txt_InputLocation.Text;
			Properties.Settings.Default.LastSuccessLocation = txt_SuccessLocation.Text;
			Properties.Settings.Default.LastFailureLocation = txt_FailureLocation.Text;
			Properties.Settings.Default.Save();
		}

		private void btn_StartStop_Click(object sender, EventArgs e)
		{
			grp_Setup.Enabled = false;
			btn_StartStop.Enabled = false;

			if (!string.IsNullOrEmpty(txt_InputLocation.Text) && System.IO.Directory.Exists(txt_InputLocation.Text))
			{
				using (new ErrorModeContext(ErrorModeContext.ErrorModes.FailCriticalErrors | ErrorModeContext.ErrorModes.NoGpFaultErrorBox))
				{
					var logFilePath = System.IO.Path.Combine(txt_FailureLocation.Text, string.Format("MaxConversion_{0:yyyy-MM-dd hh.mm.ss}.log", DateTime.Now));
					FileIterator(txt_InputLocation.Text, txt_SuccessLocation.Text, txt_FailureLocation.Text, txt_ToolLocation.Text, "", logFilePath);
				}
			}
			else
				MessageBox.Show("Invalid input folder specified!", "Invalid input folder", MessageBoxButtons.OK, MessageBoxIcon.Error);

			lbl_CurrentFileValue.Text = "";
			grp_Setup.Enabled = true;
			btn_StartStop.Enabled = true;
		}

		private void FileIterator(string inputFolder, string successFolder, string failureFolder, string toolPath, string subPath, string logPath)
		{
			var thisDirectory = new System.IO.DirectoryInfo(System.IO.Path.Combine(inputFolder, subPath));
			var inputPath = System.IO.Path.Combine(inputFolder, subPath);
			var successPath = System.IO.Path.Combine(successFolder, subPath);
			var failurePath = ViolentlySanitizeUnicodedPath(System.IO.Path.Combine(failureFolder, subPath));
			CreateDirectoryIfNecessary(successPath);
			CreateDirectoryIfNecessary(failurePath);

			foreach (var file in thisDirectory.GetFiles())
			{
				if (file.Extension.ToLowerInvariant() == ".max")
				{
					UpdateProgress(file.FullName);

					var failureFilePath = System.IO.Path.Combine(failurePath, ViolentlySanitizeUnicodedPath(file.Name));
					var failureFilePdfPath = failureFilePath + ".pdf";
					var successFilePdfPath = System.IO.Path.Combine(successPath, file.Name) + ".pdf";

					file.CopyTo(failureFilePath, true);

					var procInfo = new ProcessStartInfo(toolPath, "-o2 \"" + failureFilePath + "\"");
					//var procInfo = new ProcessStartInfo(toolPath, "\"" + failureFilePath + "\"");
					procInfo.RedirectStandardOutput = true;
					procInfo.RedirectStandardError = true;
					procInfo.UseShellExecute = false;
					procInfo.WindowStyle = ProcessWindowStyle.Hidden;
					procInfo.CreateNoWindow = true;

					bool killed = false;
					var conversionAttempt = Process.Start(procInfo);
					conversionAttempt.WaitForExit(300000); //time out at 5 mins
					if (!conversionAttempt.HasExited)
					{
						conversionAttempt.Kill();
						killed = true;
					}
					var output = conversionAttempt.StandardOutput.ReadToEnd();
					var error = conversionAttempt.StandardError.ReadToEnd();

					System.IO.File.AppendAllText(logPath, string.Format(@"---
File: {0}
Ended: {1}
Killed: {2}
Result: {3}
StdError: {4}
StdOutput: {5}
", file.FullName, DateTime.Now, killed, conversionAttempt.ExitCode, error, output), Encoding.UTF8);

					//System.Diagnostics.Debugger.Break();

					bool allGood = false;
					if (System.IO.File.Exists(failureFilePdfPath))
					{
						var targetPDFFile = new	System.IO.FileInfo(failureFilePdfPath);
						if (targetPDFFile.Length > 0)
						{
							//if success, delete this and move the PDF to its destination
							System.IO.File.Copy(failureFilePdfPath, successFilePdfPath, true);
							System.IO.File.SetCreationTimeUtc(successFilePdfPath, file.CreationTimeUtc);
							System.IO.File.SetLastWriteTimeUtc(successFilePdfPath, file.LastWriteTimeUtc);
							System.IO.File.Delete(failureFilePath);
							System.IO.File.Delete(failureFilePdfPath);
							allGood = true;
						}
					}

					if (!allGood)
					{
						//if failure, re-copy in case the process messed up the file
						file.CopyTo(failureFilePath, true);
					}

				}
				else
				{
					file.CopyTo(System.IO.Path.Combine(successPath, file.Name), true);
				}

			}
			foreach (var directory in thisDirectory.GetDirectories())
			{
				FileIterator(inputFolder, successFolder, failureFolder, toolPath, System.IO.Path.Combine(subPath, directory.Name), logPath);
			}
		}

		private void UpdateProgress(string currentFile)
		{
			lbl_CurrentFile.Text = currentFile;
		}

		private string ViolentlySanitizeUnicodedPath(string unicodeString)
		{
			var deaccented = unicodeString
				.Replace('\x0300', '`')
				.Replace('\x0301', '´')
				.Replace('\x0302', '^')
				.Replace('\x0327', ',')
				;
			return Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(deaccented)).Replace("?", "");
		}

		private static void CreateDirectoryIfNecessary(string path)
		{
			if (!System.IO.Directory.Exists(path))
				System.IO.Directory.CreateDirectory(path);
		}
	}

	public class ErrorModeContext : IDisposable
	{
		private readonly int _oldMode;

		public ErrorModeContext(ErrorModes mode)
		{
			_oldMode = SetErrorMode((int)mode);
		}

		~ErrorModeContext()
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			SetErrorMode(_oldMode);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		[DllImport("kernel32.dll")]
		private static extern int SetErrorMode(int newMode);

		[Flags]
		public enum ErrorModes
		{
			Default = 0x0,
			FailCriticalErrors = 0x1,
			NoGpFaultErrorBox = 0x2, // &lt;- this is the one we need
			NoAlignmentFaultExcept = 0x4,
			NoOpenFileErrorBox = 0x8000,
		}
	}
}
