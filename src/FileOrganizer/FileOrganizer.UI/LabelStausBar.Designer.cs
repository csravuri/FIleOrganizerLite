namespace FileOrganizer.UI
{
	partial class LabelStausBar
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			progressBar1 = new ProgressBar();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 0;
			label1.Text = "label1";
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(0, 18);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(478, 23);
			progressBar1.TabIndex = 1;
			// 
			// LabelStausBar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(progressBar1);
			Controls.Add(label1);
			Name = "LabelStausBar";
			Size = new Size(478, 44);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ProgressBar progressBar1;
	}
}
