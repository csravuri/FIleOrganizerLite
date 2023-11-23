namespace FileOrganizer.UI
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
			tabControl1 = new TabControl();
			tabFileMover = new TabPage();
			btnCopy = new Button();
			btnMove = new Button();
			txtDestinationFolder = new TextBox();
			lblDestination = new Label();
			lblGroupFolder = new Label();
			flowLayoutPanel1 = new FlowLayoutPanel();
			lblGroups = new Label();
			btnAnalyse = new Button();
			btnGroup = new Button();
			txtGroupFolder = new TextBox();
			chkExtentionList = new CheckedListBox();
			lblFileTypes = new Label();
			lblSourceFolder = new Label();
			txtSourceFolder = new TextBox();
			tabDeleter = new TabPage();
			tabControl1.SuspendLayout();
			tabFileMover.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabFileMover);
			tabControl1.Controls.Add(tabDeleter);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(548, 439);
			tabControl1.TabIndex = 0;
			// 
			// tabFileMover
			// 
			tabFileMover.Controls.Add(btnCopy);
			tabFileMover.Controls.Add(btnMove);
			tabFileMover.Controls.Add(txtDestinationFolder);
			tabFileMover.Controls.Add(lblDestination);
			tabFileMover.Controls.Add(lblGroupFolder);
			tabFileMover.Controls.Add(flowLayoutPanel1);
			tabFileMover.Controls.Add(lblGroups);
			tabFileMover.Controls.Add(btnAnalyse);
			tabFileMover.Controls.Add(btnGroup);
			tabFileMover.Controls.Add(txtGroupFolder);
			tabFileMover.Controls.Add(chkExtentionList);
			tabFileMover.Controls.Add(lblFileTypes);
			tabFileMover.Controls.Add(lblSourceFolder);
			tabFileMover.Controls.Add(txtSourceFolder);
			tabFileMover.Location = new Point(4, 24);
			tabFileMover.Name = "tabFileMover";
			tabFileMover.Padding = new Padding(3);
			tabFileMover.Size = new Size(540, 411);
			tabFileMover.TabIndex = 0;
			tabFileMover.Text = "File Mover";
			tabFileMover.UseVisualStyleBackColor = true;
			// 
			// btnCopy
			// 
			btnCopy.Location = new Point(445, 375);
			btnCopy.Name = "btnCopy";
			btnCopy.Size = new Size(57, 23);
			btnCopy.TabIndex = 13;
			btnCopy.Text = "Copy";
			btnCopy.UseVisualStyleBackColor = true;
			// 
			// btnMove
			// 
			btnMove.Location = new Point(372, 375);
			btnMove.Name = "btnMove";
			btnMove.Size = new Size(65, 23);
			btnMove.TabIndex = 12;
			btnMove.Text = "Move";
			btnMove.UseVisualStyleBackColor = true;
			// 
			// txtDestinationFolder
			// 
			txtDestinationFolder.Location = new Point(23, 375);
			txtDestinationFolder.Name = "txtDestinationFolder";
			txtDestinationFolder.Size = new Size(343, 23);
			txtDestinationFolder.TabIndex = 11;
			// 
			// lblDestination
			// 
			lblDestination.AutoSize = true;
			lblDestination.Location = new Point(23, 357);
			lblDestination.Name = "lblDestination";
			lblDestination.Size = new Size(103, 15);
			lblDestination.TabIndex = 10;
			lblDestination.Text = "Destination Folder";
			// 
			// lblGroupFolder
			// 
			lblGroupFolder.AutoSize = true;
			lblGroupFolder.Location = new Point(149, 86);
			lblGroupFolder.Name = "lblGroupFolder";
			lblGroupFolder.Size = new Size(76, 15);
			lblGroupFolder.TabIndex = 9;
			lblGroupFolder.Text = "Group Folder";
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Location = new Point(302, 104);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(200, 238);
			flowLayoutPanel1.TabIndex = 8;
			// 
			// lblGroups
			// 
			lblGroups.AutoSize = true;
			lblGroups.Location = new Point(302, 86);
			lblGroups.Name = "lblGroups";
			lblGroups.Size = new Size(45, 15);
			lblGroups.TabIndex = 7;
			lblGroups.Text = "Groups";
			// 
			// btnAnalyse
			// 
			btnAnalyse.Location = new Point(23, 55);
			btnAnalyse.Name = "btnAnalyse";
			btnAnalyse.Size = new Size(75, 23);
			btnAnalyse.TabIndex = 6;
			btnAnalyse.Text = "Analyze";
			btnAnalyse.UseVisualStyleBackColor = true;
			btnAnalyse.Click += btnAnalyse_Click;
			// 
			// btnGroup
			// 
			btnGroup.Location = new Point(150, 133);
			btnGroup.Name = "btnGroup";
			btnGroup.Size = new Size(75, 23);
			btnGroup.TabIndex = 5;
			btnGroup.Text = "Group";
			btnGroup.UseVisualStyleBackColor = true;
			// 
			// txtGroupFolder
			// 
			txtGroupFolder.Location = new Point(149, 104);
			txtGroupFolder.Name = "txtGroupFolder";
			txtGroupFolder.Size = new Size(100, 23);
			txtGroupFolder.TabIndex = 4;
			// 
			// chkExtentionList
			// 
			chkExtentionList.CheckOnClick = true;
			chkExtentionList.FormattingEnabled = true;
			chkExtentionList.Location = new Point(23, 104);
			chkExtentionList.Name = "chkExtentionList";
			chkExtentionList.Size = new Size(120, 238);
			chkExtentionList.TabIndex = 3;
			// 
			// lblFileTypes
			// 
			lblFileTypes.AutoSize = true;
			lblFileTypes.Location = new Point(23, 86);
			lblFileTypes.Name = "lblFileTypes";
			lblFileTypes.Size = new Size(57, 15);
			lblFileTypes.TabIndex = 2;
			lblFileTypes.Text = "File Types";
			// 
			// lblSourceFolder
			// 
			lblSourceFolder.AutoSize = true;
			lblSourceFolder.Location = new Point(25, 6);
			lblSourceFolder.Name = "lblSourceFolder";
			lblSourceFolder.Size = new Size(77, 15);
			lblSourceFolder.TabIndex = 1;
			lblSourceFolder.Text = "Source folder";
			// 
			// txtSourceFolder
			// 
			txtSourceFolder.Location = new Point(23, 26);
			txtSourceFolder.Name = "txtSourceFolder";
			txtSourceFolder.Size = new Size(479, 23);
			txtSourceFolder.TabIndex = 0;
			// 
			// tabDeleter
			// 
			tabDeleter.Location = new Point(4, 24);
			tabDeleter.Name = "tabDeleter";
			tabDeleter.Padding = new Padding(3);
			tabDeleter.Size = new Size(540, 411);
			tabDeleter.TabIndex = 1;
			tabDeleter.Text = "File Deleter";
			tabDeleter.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(548, 439);
			Controls.Add(tabControl1);
			MinimumSize = new Size(564, 478);
			Name = "MainForm";
			Text = "File Organizer";
			tabControl1.ResumeLayout(false);
			tabFileMover.ResumeLayout(false);
			tabFileMover.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabFileMover;
		private TabPage tabDeleter;
		private FlowLayoutPanel flowLayoutPanel1;
		private Label lblGroups;
		private Button btnAnalyse;
		private Button btnGroup;
		private TextBox txtGroupFolder;
		private CheckedListBox chkExtentionList;
		private Label lblFileTypes;
		private Label lblSourceFolder;
		private TextBox txtSourceFolder;
		private Label lblGroupFolder;
		private Button btnCopy;
		private Button btnMove;
		private TextBox txtDestinationFolder;
		private Label lblDestination;
	}
}