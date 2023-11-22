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
			tabDeleter = new TabPage();
			tabControl1.SuspendLayout();
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
			tabControl1.Size = new Size(800, 450);
			tabControl1.TabIndex = 0;
			// 
			// tabFileMover
			// 
			tabFileMover.Location = new Point(4, 24);
			tabFileMover.Name = "tabFileMover";
			tabFileMover.Padding = new Padding(3);
			tabFileMover.Size = new Size(792, 422);
			tabFileMover.TabIndex = 0;
			tabFileMover.Text = "File Mover";
			tabFileMover.UseVisualStyleBackColor = true;
			// 
			// tabDeleter
			// 
			tabDeleter.Location = new Point(4, 24);
			tabDeleter.Name = "tabDeleter";
			tabDeleter.Padding = new Padding(3);
			tabDeleter.Size = new Size(792, 422);
			tabDeleter.TabIndex = 1;
			tabDeleter.Text = "File Deleter";
			tabDeleter.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(tabControl1);
			Name = "MainForm";
			Text = "File Organizer";
			tabControl1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabFileMover;
		private TabPage tabDeleter;
	}
}