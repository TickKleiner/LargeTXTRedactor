
namespace LargeTextRedactor
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
			this.additionalFiles = new System.Windows.Forms.ListBox();
			this.originalFileBox = new System.Windows.Forms.TextBox();
			this.additionalFilesOptions = new System.Windows.Forms.CheckedListBox();
			this.changeByMaskButton = new System.Windows.Forms.Button();
			this.changeMaskBox = new System.Windows.Forms.TextBox();
			this.replacementField = new System.Windows.Forms.TextBox();
			this.splitByStringsField = new System.Windows.Forms.NumericUpDown();
			this.splitByStringsButton = new System.Windows.Forms.Button();
			this.splitByFilesField = new System.Windows.Forms.NumericUpDown();
			this.splitByFilesButton = new System.Windows.Forms.Button();
			this.transformToASCIIButton = new System.Windows.Forms.Button();
			this.encodeBox = new System.Windows.Forms.TextBox();
			this.lossBox = new System.Windows.Forms.TextBox();
			this.stringsCountBox = new System.Windows.Forms.TextBox();
			this.stringsLabel = new System.Windows.Forms.Label();
			this.transToASCIIBox = new System.Windows.Forms.TextBox();
			this.encodeLabel = new System.Windows.Forms.Label();
			this.additionalLabel = new System.Windows.Forms.Label();
			this.originalLabel = new System.Windows.Forms.Label();
			this.executeButton = new System.Windows.Forms.Button();
			this.createDuplicateButton = new System.Windows.Forms.Button();
			this.rmDupStrButton = new System.Windows.Forms.Button();
			this.removeContainsMaskBox = new System.Windows.Forms.TextBox();
			this.removeContainsStringsButton = new System.Windows.Forms.Button();
			this.executeLabel = new System.Windows.Forms.Label();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.addFromFolder = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.removeDontContainsMaskBox = new System.Windows.Forms.TextBox();
			this.removeDontContainsStringsButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitByStringsField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitByFilesField)).BeginInit();
			this.SuspendLayout();
			// 
			// additionalFiles
			// 
			this.additionalFiles.AllowDrop = true;
			this.additionalFiles.FormattingEnabled = true;
			this.additionalFiles.ItemHeight = 15;
			this.additionalFiles.Location = new System.Drawing.Point(411, 52);
			this.additionalFiles.Name = "additionalFiles";
			this.additionalFiles.Size = new System.Drawing.Size(377, 79);
			this.additionalFiles.TabIndex = 0;
			this.additionalFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.additionalFiles_DragDrop);
			this.additionalFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.additionalFiles_DragEnter);
			this.additionalFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.additionalFiles_MouseDoubleClick);
			// 
			// originalFileBox
			// 
			this.originalFileBox.AllowDrop = true;
			this.originalFileBox.Location = new System.Drawing.Point(12, 52);
			this.originalFileBox.Name = "originalFileBox";
			this.originalFileBox.ReadOnly = true;
			this.originalFileBox.Size = new System.Drawing.Size(249, 23);
			this.originalFileBox.TabIndex = 1;
			this.originalFileBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.originalFileBox_DragDrop);
			this.originalFileBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.originalFileBox_DragEnter);
			// 
			// additionalFilesOptions
			// 
			this.additionalFilesOptions.CausesValidation = false;
			this.additionalFilesOptions.FormattingEnabled = true;
			this.additionalFilesOptions.Items.AddRange(new object[] {
            "получить результат в ASCII (возможны потери)",
            "удалить дубликаты из исходного файла по окончании",
            "удалить вспомогательные файлы по окончании"});
			this.additionalFilesOptions.Location = new System.Drawing.Point(411, 188);
			this.additionalFilesOptions.Name = "additionalFilesOptions";
			this.additionalFilesOptions.Size = new System.Drawing.Size(377, 58);
			this.additionalFilesOptions.TabIndex = 2;
			// 
			// changeByMaskButton
			// 
			this.changeByMaskButton.Location = new System.Drawing.Point(224, 253);
			this.changeByMaskButton.Name = "changeByMaskButton";
			this.changeByMaskButton.Size = new System.Drawing.Size(143, 23);
			this.changeByMaskButton.TabIndex = 6;
			this.changeByMaskButton.Text = "заменить по маске";
			this.changeByMaskButton.UseVisualStyleBackColor = true;
			this.changeByMaskButton.Click += new System.EventHandler(this.changeByMaskButton_Click);
			// 
			// changeMaskBox
			// 
			this.changeMaskBox.AcceptsReturn = true;
			this.changeMaskBox.Location = new System.Drawing.Point(12, 253);
			this.changeMaskBox.Name = "changeMaskBox";
			this.changeMaskBox.PlaceholderText = "маска";
			this.changeMaskBox.Size = new System.Drawing.Size(100, 23);
			this.changeMaskBox.TabIndex = 5;
			// 
			// replacementField
			// 
			this.replacementField.Location = new System.Drawing.Point(118, 253);
			this.replacementField.Name = "replacementField";
			this.replacementField.PlaceholderText = "заменить на";
			this.replacementField.Size = new System.Drawing.Size(100, 23);
			this.replacementField.TabIndex = 7;
			// 
			// splitByStringsField
			// 
			this.splitByStringsField.Location = new System.Drawing.Point(12, 168);
			this.splitByStringsField.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
			this.splitByStringsField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.splitByStringsField.Name = "splitByStringsField";
			this.splitByStringsField.Size = new System.Drawing.Size(100, 23);
			this.splitByStringsField.TabIndex = 8;
			this.splitByStringsField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// splitByStringsButton
			// 
			this.splitByStringsButton.Location = new System.Drawing.Point(118, 168);
			this.splitByStringsButton.Name = "splitByStringsButton";
			this.splitByStringsButton.Size = new System.Drawing.Size(249, 23);
			this.splitByStringsButton.TabIndex = 9;
			this.splitByStringsButton.Text = "разбить по строкам";
			this.splitByStringsButton.UseVisualStyleBackColor = true;
			this.splitByStringsButton.Click += new System.EventHandler(this.splitByStringsButton_Click);
			// 
			// splitByFilesField
			// 
			this.splitByFilesField.Location = new System.Drawing.Point(13, 197);
			this.splitByFilesField.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
			this.splitByFilesField.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.splitByFilesField.Name = "splitByFilesField";
			this.splitByFilesField.Size = new System.Drawing.Size(99, 23);
			this.splitByFilesField.TabIndex = 10;
			this.splitByFilesField.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// splitByFilesButton
			// 
			this.splitByFilesButton.Location = new System.Drawing.Point(118, 195);
			this.splitByFilesButton.Name = "splitByFilesButton";
			this.splitByFilesButton.Size = new System.Drawing.Size(249, 23);
			this.splitByFilesButton.TabIndex = 11;
			this.splitByFilesButton.Text = "разбить на количество файлов";
			this.splitByFilesButton.UseVisualStyleBackColor = true;
			this.splitByFilesButton.Click += new System.EventHandler(this.splitByFilesButton_Click);
			// 
			// transformToASCIIButton
			// 
			this.transformToASCIIButton.Location = new System.Drawing.Point(224, 224);
			this.transformToASCIIButton.Name = "transformToASCIIButton";
			this.transformToASCIIButton.Size = new System.Drawing.Size(143, 23);
			this.transformToASCIIButton.TabIndex = 12;
			this.transformToASCIIButton.Text = "преобразовать в ASCII";
			this.transformToASCIIButton.UseVisualStyleBackColor = true;
			this.transformToASCIIButton.Click += new System.EventHandler(this.transformToASCIIButton_Click);
			// 
			// encodeBox
			// 
			this.encodeBox.Location = new System.Drawing.Point(224, 96);
			this.encodeBox.Name = "encodeBox";
			this.encodeBox.ReadOnly = true;
			this.encodeBox.Size = new System.Drawing.Size(143, 23);
			this.encodeBox.TabIndex = 13;
			// 
			// lossBox
			// 
			this.lossBox.Location = new System.Drawing.Point(12, 226);
			this.lossBox.Name = "lossBox";
			this.lossBox.PlaceholderText = "потери";
			this.lossBox.ReadOnly = true;
			this.lossBox.Size = new System.Drawing.Size(100, 23);
			this.lossBox.TabIndex = 14;
			// 
			// stringsCountBox
			// 
			this.stringsCountBox.Location = new System.Drawing.Point(12, 96);
			this.stringsCountBox.Name = "stringsCountBox";
			this.stringsCountBox.ReadOnly = true;
			this.stringsCountBox.Size = new System.Drawing.Size(205, 23);
			this.stringsCountBox.TabIndex = 18;
			this.stringsCountBox.Text = "0";
			// 
			// stringsLabel
			// 
			this.stringsLabel.AutoSize = true;
			this.stringsLabel.Location = new System.Drawing.Point(13, 78);
			this.stringsLabel.Name = "stringsLabel";
			this.stringsLabel.Size = new System.Drawing.Size(41, 15);
			this.stringsLabel.TabIndex = 19;
			this.stringsLabel.Text = "строк:";
			// 
			// transToASCIIBox
			// 
			this.transToASCIIBox.Location = new System.Drawing.Point(118, 226);
			this.transToASCIIBox.MaxLength = 1;
			this.transToASCIIBox.Name = "transToASCIIBox";
			this.transToASCIIBox.PlaceholderText = "заменить на";
			this.transToASCIIBox.Size = new System.Drawing.Size(100, 23);
			this.transToASCIIBox.TabIndex = 20;
			// 
			// encodeLabel
			// 
			this.encodeLabel.AutoSize = true;
			this.encodeLabel.Location = new System.Drawing.Point(224, 78);
			this.encodeLabel.Name = "encodeLabel";
			this.encodeLabel.Size = new System.Drawing.Size(65, 15);
			this.encodeLabel.TabIndex = 21;
			this.encodeLabel.Text = "кодировка";
			// 
			// additionalLabel
			// 
			this.additionalLabel.AutoSize = true;
			this.additionalLabel.Location = new System.Drawing.Point(411, 31);
			this.additionalLabel.Name = "additionalLabel";
			this.additionalLabel.Size = new System.Drawing.Size(148, 15);
			this.additionalLabel.TabIndex = 22;
			this.additionalLabel.Text = "Вспомогательные файлы";
			// 
			// originalLabel
			// 
			this.originalLabel.AutoSize = true;
			this.originalLabel.Location = new System.Drawing.Point(12, 31);
			this.originalLabel.Name = "originalLabel";
			this.originalLabel.Size = new System.Drawing.Size(96, 15);
			this.originalLabel.TabIndex = 23;
			this.originalLabel.Text = "Исходный файл";
			// 
			// executeButton
			// 
			this.executeButton.Location = new System.Drawing.Point(411, 252);
			this.executeButton.Name = "executeButton";
			this.executeButton.Size = new System.Drawing.Size(377, 23);
			this.executeButton.TabIndex = 24;
			this.executeButton.Text = "объединить с исходным";
			this.executeButton.UseVisualStyleBackColor = true;
			this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
			// 
			// createDuplicateButton
			// 
			this.createDuplicateButton.Location = new System.Drawing.Point(12, 139);
			this.createDuplicateButton.Name = "createDuplicateButton";
			this.createDuplicateButton.Size = new System.Drawing.Size(205, 23);
			this.createDuplicateButton.TabIndex = 25;
			this.createDuplicateButton.Text = "создать копию(бекап)";
			this.createDuplicateButton.UseVisualStyleBackColor = true;
			this.createDuplicateButton.Click += new System.EventHandler(this.createDuplicateButton_Click);
			// 
			// rmDupStrButton
			// 
			this.rmDupStrButton.Location = new System.Drawing.Point(224, 139);
			this.rmDupStrButton.Name = "rmDupStrButton";
			this.rmDupStrButton.Size = new System.Drawing.Size(143, 23);
			this.rmDupStrButton.TabIndex = 26;
			this.rmDupStrButton.Text = "удалить дубликаты";
			this.rmDupStrButton.UseVisualStyleBackColor = true;
			this.rmDupStrButton.Click += new System.EventHandler(this.rmDupStrButton_Click);
			// 
			// removeContainsMaskBox
			// 
			this.removeContainsMaskBox.Location = new System.Drawing.Point(12, 282);
			this.removeContainsMaskBox.Name = "removeContainsMaskBox";
			this.removeContainsMaskBox.PlaceholderText = "строки содержащие";
			this.removeContainsMaskBox.Size = new System.Drawing.Size(206, 23);
			this.removeContainsMaskBox.TabIndex = 27;
			// 
			// removeContainsStringsButton
			// 
			this.removeContainsStringsButton.Location = new System.Drawing.Point(224, 281);
			this.removeContainsStringsButton.Name = "removeContainsStringsButton";
			this.removeContainsStringsButton.Size = new System.Drawing.Size(143, 24);
			this.removeContainsStringsButton.TabIndex = 28;
			this.removeContainsStringsButton.Text = "удалить";
			this.removeContainsStringsButton.UseVisualStyleBackColor = true;
			this.removeContainsStringsButton.Click += new System.EventHandler(this.removeContainsStringsButton_Click);
			// 
			// executeLabel
			// 
			this.executeLabel.AutoSize = true;
			this.executeLabel.Location = new System.Drawing.Point(411, 168);
			this.executeLabel.Name = "executeLabel";
			this.executeLabel.Size = new System.Drawing.Size(189, 15);
			this.executeLabel.TabIndex = 29;
			this.executeLabel.Text = "объединить с исходным файлом";
			// 
			// BrowseButton
			// 
			this.BrowseButton.Location = new System.Drawing.Point(267, 52);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(100, 23);
			this.BrowseButton.TabIndex = 30;
			this.BrowseButton.Text = "выбрать файл";
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// addFromFolder
			// 
			this.addFromFolder.Location = new System.Drawing.Point(411, 139);
			this.addFromFolder.Name = "addFromFolder";
			this.addFromFolder.Size = new System.Drawing.Size(377, 23);
			this.addFromFolder.TabIndex = 31;
			this.addFromFolder.Text = "добавить файлы из папки";
			this.addFromFolder.UseVisualStyleBackColor = true;
			this.addFromFolder.Click += new System.EventHandler(this.addFromFolder_Click);
			// 
			// removeDontContainsMaskBox
			// 
			this.removeDontContainsMaskBox.Location = new System.Drawing.Point(12, 311);
			this.removeDontContainsMaskBox.Name = "removeDontContainsMaskBox";
			this.removeDontContainsMaskBox.PlaceholderText = "строки не содержащие";
			this.removeDontContainsMaskBox.Size = new System.Drawing.Size(206, 23);
			this.removeDontContainsMaskBox.TabIndex = 32;
			// 
			// removeDontContainsStringsButton
			// 
			this.removeDontContainsStringsButton.Location = new System.Drawing.Point(224, 311);
			this.removeDontContainsStringsButton.Name = "removeDontContainsStringsButton";
			this.removeDontContainsStringsButton.Size = new System.Drawing.Size(143, 24);
			this.removeDontContainsStringsButton.TabIndex = 33;
			this.removeDontContainsStringsButton.Text = "удалить";
			this.removeDontContainsStringsButton.UseVisualStyleBackColor = true;
			this.removeDontContainsStringsButton.Click += new System.EventHandler(this.removeDontContainsStringsButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 361);
			this.Controls.Add(this.removeDontContainsStringsButton);
			this.Controls.Add(this.removeDontContainsMaskBox);
			this.Controls.Add(this.addFromFolder);
			this.Controls.Add(this.BrowseButton);
			this.Controls.Add(this.executeLabel);
			this.Controls.Add(this.removeContainsStringsButton);
			this.Controls.Add(this.removeContainsMaskBox);
			this.Controls.Add(this.rmDupStrButton);
			this.Controls.Add(this.createDuplicateButton);
			this.Controls.Add(this.executeButton);
			this.Controls.Add(this.originalLabel);
			this.Controls.Add(this.additionalLabel);
			this.Controls.Add(this.encodeLabel);
			this.Controls.Add(this.transToASCIIBox);
			this.Controls.Add(this.stringsLabel);
			this.Controls.Add(this.stringsCountBox);
			this.Controls.Add(this.lossBox);
			this.Controls.Add(this.encodeBox);
			this.Controls.Add(this.transformToASCIIButton);
			this.Controls.Add(this.splitByFilesButton);
			this.Controls.Add(this.splitByFilesField);
			this.Controls.Add(this.splitByStringsButton);
			this.Controls.Add(this.splitByStringsField);
			this.Controls.Add(this.replacementField);
			this.Controls.Add(this.changeByMaskButton);
			this.Controls.Add(this.changeMaskBox);
			this.Controls.Add(this.additionalFilesOptions);
			this.Controls.Add(this.originalFileBox);
			this.Controls.Add(this.additionalFiles);
			this.Name = "Form1";
			this.Text = "Large Files Redactor";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.splitByStringsField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitByFilesField)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox additionalFiles;
		private System.Windows.Forms.TextBox originalFileBox;
		private System.Windows.Forms.CheckedListBox additionalFilesOptions;
		private System.Windows.Forms.Button changeByMaskButton;
		private System.Windows.Forms.TextBox changeMaskBox;
		private System.Windows.Forms.TextBox replacementField;
		private System.Windows.Forms.NumericUpDown splitByStringsField;
		private System.Windows.Forms.Button splitByStringsButton;
		private System.Windows.Forms.NumericUpDown splitByFilesField;
		private System.Windows.Forms.Button splitByFilesButton;
		private System.Windows.Forms.Button transformToASCIIButton;
		private System.Windows.Forms.TextBox encodeBox;
		private System.Windows.Forms.TextBox lossBox;
		private System.Windows.Forms.TextBox stringsCountBox;
		private System.Windows.Forms.Label stringsLabel;
		private System.Windows.Forms.TextBox transToASCIIBox;
		private System.Windows.Forms.Label encodeLabel;
		private System.Windows.Forms.Label additionalLabel;
		private System.Windows.Forms.Label originalLabel;
		private System.Windows.Forms.Button executeButton;
		private System.Windows.Forms.Button createDuplicateButton;
		private System.Windows.Forms.Button rmDupStrButton;
		private System.Windows.Forms.TextBox removeContainsMaskBox;
		private System.Windows.Forms.Button removeContainsStringsButton;
		private System.Windows.Forms.Label executeLabel;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button addFromFolder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox removeDontContainsMaskBox;
		private System.Windows.Forms.Button removeDontContainsStringsButton;
	}
}

