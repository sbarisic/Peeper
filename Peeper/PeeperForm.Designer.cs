namespace Peeper {
	partial class PeeperForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.RecordContainer = new System.Windows.Forms.Panel();
			this.RecordPanel = new Peeper.RecordPanel();
			this.RecButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.FpsUpDown = new System.Windows.Forms.NumericUpDown();
			this.WebmCheckBox = new System.Windows.Forms.CheckBox();
			this.RecordContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// RecordContainer
			// 
			this.RecordContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RecordContainer.BackColor = System.Drawing.Color.Black;
			this.RecordContainer.Controls.Add(this.RecordPanel);
			this.RecordContainer.Location = new System.Drawing.Point(12, 12);
			this.RecordContainer.Name = "RecordContainer";
			this.RecordContainer.Size = new System.Drawing.Size(193, 177);
			this.RecordContainer.TabIndex = 0;
			// 
			// RecordPanel
			// 
			this.RecordPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RecordPanel.AutoSize = true;
			this.RecordPanel.BackColor = System.Drawing.Color.Fuchsia;
			this.RecordPanel.ForeColor = System.Drawing.Color.Transparent;
			this.RecordPanel.Location = new System.Drawing.Point(1, 1);
			this.RecordPanel.Name = "RecordPanel";
			this.RecordPanel.Size = new System.Drawing.Size(191, 175);
			this.RecordPanel.TabIndex = 0;
			// 
			// RecButton
			// 
			this.RecButton.Location = new System.Drawing.Point(268, 12);
			this.RecButton.Margin = new System.Windows.Forms.Padding(0);
			this.RecButton.Name = "RecButton";
			this.RecButton.Size = new System.Drawing.Size(75, 23);
			this.RecButton.TabIndex = 1;
			this.RecButton.Text = "Rec";
			this.RecButton.UseVisualStyleBackColor = true;
			this.RecButton.Click += new System.EventHandler(this.RecButton_Click);
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(248, 50);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(75, 23);
			this.ExitButton.TabIndex = 2;
			this.ExitButton.Text = "Exit";
			this.ExitButton.UseVisualStyleBackColor = true;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// FpsUpDown
			// 
			this.FpsUpDown.Location = new System.Drawing.Point(268, 100);
			this.FpsUpDown.Name = "FpsUpDown";
			this.FpsUpDown.Size = new System.Drawing.Size(56, 20);
			this.FpsUpDown.TabIndex = 3;
			this.FpsUpDown.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
			// 
			// WebmCheckBox
			// 
			this.WebmCheckBox.AutoSize = true;
			this.WebmCheckBox.Location = new System.Drawing.Point(234, 143);
			this.WebmCheckBox.Name = "WebmCheckBox";
			this.WebmCheckBox.Size = new System.Drawing.Size(54, 17);
			this.WebmCheckBox.TabIndex = 4;
			this.WebmCheckBox.Text = "webm";
			this.WebmCheckBox.UseVisualStyleBackColor = true;
			// 
			// PeeperForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 226);
			this.Controls.Add(this.WebmCheckBox);
			this.Controls.Add(this.FpsUpDown);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.RecButton);
			this.Controls.Add(this.RecordContainer);
			this.Name = "PeeperForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Peeper";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.Load += new System.EventHandler(this.PeeperForm_Load);
			this.RecordContainer.ResumeLayout(false);
			this.RecordContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel RecordContainer;
		private System.Windows.Forms.Button RecButton;
		private RecordPanel RecordPanel;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.NumericUpDown FpsUpDown;
		private System.Windows.Forms.CheckBox WebmCheckBox;


	}
}