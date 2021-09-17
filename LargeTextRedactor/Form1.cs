using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LargeTextRedactor
{
	public partial class Form1 : Form
	{
		LTRDLLWrapper FileEditor;

		public Form1()
		{
			InitializeComponent();
			FileEditor = new LTRDLLWrapper();
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private void regUse_Click(object sender, EventArgs e) { }

		private void Form1_Load(object sender, EventArgs e)
		{
			this.folderBrowserDialog.Description =
				"Select the directory with additioal files to add";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			this.openFileDialog.Filter = "Text|*.txt|All|*.*";
			this.openFileDialog.RestoreDirectory = true;
			this.switcher(false);
		}

		private void eventSwitcher()
		{
			int stringsCount = int.Parse(this.stringsCountBox.Text);
			this.splitByStringsButton.Enabled = (stringsCount > 1);
			this.splitByFilesButton.Enabled = (stringsCount > 2);
			this.splitByStringsField.Maximum = stringsCount > 1 ? stringsCount : 1;
			this.splitByStringsField.Enabled = this.splitByStringsButton.Enabled;
			this.splitByFilesField.Maximum = stringsCount > 2 ? stringsCount : 2;
			this.splitByFilesField.Enabled = this.splitByFilesButton.Enabled;
			this.transToASCIIBox.Enabled = (!string.IsNullOrEmpty(this.encodeBox.Text) && (this.encodeBox.Text != "ASCII"));
			this.transformToASCIIButton.Enabled = this.transToASCIIBox.Enabled;
		}

		private void switcher(bool value)
		{
			this.createDuplicateButton.Enabled = value;
			this.rmDupStrButton.Enabled = value;
			this.changeMaskBox.Enabled = value;
			this.replacementField.Enabled = value;
			this.changeByMaskButton.Enabled = value;
			this.removeContainsMaskBox.Enabled = value;
			this.removeContainsStringsButton.Enabled = value;
			this.additionalFiles.Enabled = value;
			this.additionalFilesOptions.Enabled = value;
			this.executeButton.Enabled = value;
			this.removeDontContainsMaskBox.Enabled = value;
			this.removeDontContainsStringsButton.Enabled = value;
			this.eventSwitcher();
		}

		private void init()
		{
			this.stringsCountBox.Text = FileEditor._GetStringsCount().ToString();
			this.encodeBox.Text = FileEditor._getEncode();
			this.lossBox.Text = FileEditor._CountLoss().ToString();
			this.switcher(true);
			this.cleanAdditionalFiles();
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			DialogResult result = this.openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				this.originalFileBox.Text = this.openFileDialog.FileName;
				FileEditor.path = this.openFileDialog.FileName;
				this.init();
			}
		}

		private void splitByStringsButton_Click(object sender, EventArgs e)
		{
			FileEditor._SplitByStrings((int)this.splitByStringsField.Value);
		}

		private void createDuplicateButton_Click(object sender, EventArgs e)
		{
			FileEditor._CreateBackup();
		}

		private void rmDupStrButton_Click(object sender, EventArgs e)
		{
			FileEditor._RemoveDuplicates();
			this.init();
		}

		private void splitByFilesButton_Click(object sender, EventArgs e)
		{
			FileEditor._SplitByFiles((int)this.splitByFilesField.Value);
		}

		private void transformToASCIIButton_Click(object sender, EventArgs e)
		{
			char to = (char)0;
			if (this.transToASCIIBox.Text.Length > 0)
				to = this.transToASCIIBox.Text[0];
			FileEditor._FileToASCII(to);
			this.init();
		}

		private void changeByMaskButton_Click(object sender, EventArgs e)
		{
			string mask = this.changeMaskBox.Text;
			if (string.IsNullOrEmpty(mask))
			{
				MessageBox.Show (
					"Fill the mask box please",
					"ALERT",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return;
			}
			string replacement = this.replacementField.Text;
			FileEditor._ChangeByMask(mask, replacement);
			this.init();
		}

		private void executeButton_Click(object sender, EventArgs e)
		{
			bool getResInASCII = this.additionalFilesOptions.GetItemChecked(0);
			bool removeDuplicates = this.additionalFilesOptions.GetItemChecked(1);
			bool removeAddFiles = this.additionalFilesOptions.GetItemChecked(2);
			FileEditor._ExecuteAdditionalFiles(getResInASCII, removeDuplicates, removeAddFiles);
			this.init();
		}

		private void additionalFiles_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void addAdditionalFiles(string[] files, bool showMessages)
		{
			foreach (string file in files)
			{
				if (file == this.originalFileBox.Text)
				{
					if (showMessages)
					{
						MessageBox.Show(
							"Dont put original file in additional files please",
							"ALERT",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);
					}
					continue;
				}

				if (Path.GetExtension(file) != ".txt")
				{
					if (showMessages)
					{
						MessageBox.Show(
							"Put only txt files in additional files please",
							"ALERT",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);
					}
					continue;
				}

				if (this.additionalFiles.Items.Contains(file))
				{
					if (showMessages)
					{
						MessageBox.Show(
							"File already in additional files",
							"ALERT",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);
					}
					continue;
				}
				this.additionalFiles.Items.Add(file);
				FileEditor.addAdditionalFilePath(file);
			}
		}

		private void cleanAdditionalFiles()
		{
			string[] files = this.additionalFiles.Items.Cast<string>().ToArray();
			foreach (string file in files)
			{
				if (!File.Exists(file))
					this.additionalFiles.Items.Remove(file);
				else if (file == this.originalFileBox.Text)
					this.additionalFiles.Items.Remove(file);
			}
		}

		private void additionalFiles_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			this.addAdditionalFiles(files, true);
		}

		private void additionalFiles_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = this.additionalFiles.IndexFromPoint(e.Location);
			if (index != System.Windows.Forms.ListBox.NoMatches)
			{
				FileEditor.removeAdditionalFilePath(this.additionalFiles.Items[index].ToString());
				this.additionalFiles.Items.RemoveAt(index);
			}
		}

		private void originalFileBox_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void originalFileBox_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (files.Length != 1)
			{
				MessageBox.Show(
					"Put one file please",
					"ALERT",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return;
			}
			string file = files[0];
			if (Path.GetExtension(file) != ".txt")
			{
				MessageBox.Show(
					"Put only txt file as original file please",
					"ALERT",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return;
			}
			this.originalFileBox.Text = file;
			FileEditor.path = file;
			this.init();
		}

		private void addFromFolder_Click(object sender, EventArgs e)
		{
			DialogResult result = this.folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				DirectoryInfo dinfo = new DirectoryInfo(folderBrowserDialog.SelectedPath);
				FileInfo[] files = dinfo.GetFiles("*.txt");
				this.addAdditionalFiles(files.Select(a => a.FullName).ToArray(), false);
			}
		}

		private void removeContainsStringsButton_Click(object sender, EventArgs e)
		{
			string mask = this.removeContainsMaskBox.Text;
			if (string.IsNullOrEmpty(mask))
			{
				MessageBox.Show(
					"Fill the mask box please",
					"ALERT",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return;
			}
			FileEditor._RemoveByMask(mask, true);
			this.init();
		}

		private void removeDontContainsStringsButton_Click(object sender, EventArgs e)
		{
			string mask = this.removeDontContainsMaskBox.Text;
			if (string.IsNullOrEmpty(mask))
			{
				MessageBox.Show(
					"Fill the mask box please",
					"ALERT",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return;
			}
			FileEditor._RemoveByMask(mask, false);
			this.init();
		}
	}
}