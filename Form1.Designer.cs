namespace MultipleKeySender
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lstWindows = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label4 = new System.Windows.Forms.Label();
			this.edtInput = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.edtDetails = new System.Windows.Forms.TextBox();
			this.btnFindWindow = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lstWindows);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 2, 4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.edtInput);
			this.splitContainer1.Panel2.Controls.Add(this.label6);
			this.splitContainer1.Panel2.Controls.Add(this.btnRemove);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.edtDetails);
			this.splitContainer1.Panel2.Controls.Add(this.btnFindWindow);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2, 4, 4, 4);
			this.splitContainer1.Size = new System.Drawing.Size(676, 380);
			this.splitContainer1.SplitterDistance = 422;
			this.splitContainer1.TabIndex = 18;
			// 
			// lstWindows
			// 
			this.lstWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lstWindows.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstWindows.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lstWindows.FullRowSelect = true;
			this.lstWindows.Location = new System.Drawing.Point(4, 24);
			this.lstWindows.Name = "lstWindows";
			this.lstWindows.Size = new System.Drawing.Size(416, 352);
			this.lstWindows.TabIndex = 18;
			this.lstWindows.UseCompatibleStateImageBehavior = false;
			this.lstWindows.View = System.Windows.Forms.View.Details;
			this.lstWindows.SelectedIndexChanged += new System.EventHandler(this.lstWindows_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "HWND";
			this.columnHeader1.Width = 89;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Class";
			this.columnHeader2.Width = 88;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Text";
			this.columnHeader3.Width = 78;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "EXE";
			this.columnHeader4.Width = 137;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(4, 4);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(4);
			this.label4.Size = new System.Drawing.Size(93, 20);
			this.label4.TabIndex = 17;
			this.label4.Text = "Target windows";
			// 
			// edtInput
			// 
			this.edtInput.AcceptsReturn = true;
			this.edtInput.AcceptsTab = true;
			this.edtInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.edtInput.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.edtInput.Location = new System.Drawing.Point(2, 236);
			this.edtInput.Multiline = true;
			this.edtInput.Name = "edtInput";
			this.edtInput.Size = new System.Drawing.Size(244, 48);
			this.edtInput.TabIndex = 40;
			this.edtInput.Text = "Focus this, and input keys!";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(2, 210);
			this.label6.Name = "label6";
			this.label6.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
			this.label6.Size = new System.Drawing.Size(197, 26);
			this.label6.TabIndex = 39;
			this.label6.Text = "Send key strokes to target windows";
			// 
			// btnRemove
			// 
			this.btnRemove.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnRemove.Location = new System.Drawing.Point(2, 178);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(244, 32);
			this.btnRemove.TabIndex = 38;
			this.btnRemove.Text = "Remove selected window.";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(2, 152);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
			this.label2.Size = new System.Drawing.Size(129, 26);
			this.label2.TabIndex = 37;
			this.label2.Text = "Remove target window";
			// 
			// edtDetails
			// 
			this.edtDetails.AcceptsReturn = true;
			this.edtDetails.AcceptsTab = true;
			this.edtDetails.Dock = System.Windows.Forms.DockStyle.Top;
			this.edtDetails.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.edtDetails.Location = new System.Drawing.Point(2, 56);
			this.edtDetails.Multiline = true;
			this.edtDetails.Name = "edtDetails";
			this.edtDetails.ReadOnly = true;
			this.edtDetails.Size = new System.Drawing.Size(244, 96);
			this.edtDetails.TabIndex = 36;
			// 
			// btnFindWindow
			// 
			this.btnFindWindow.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnFindWindow.Location = new System.Drawing.Point(2, 24);
			this.btnFindWindow.Name = "btnFindWindow";
			this.btnFindWindow.Size = new System.Drawing.Size(244, 32);
			this.btnFindWindow.TabIndex = 26;
			this.btnFindWindow.Text = "Drag this and drop on the target window!";
			this.btnFindWindow.UseVisualStyleBackColor = true;
			this.btnFindWindow.Click += new System.EventHandler(this.btnFindWindow_Click);
			this.btnFindWindow.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btnFindWindow_GiveFeedback);
			this.btnFindWindow.MouseCaptureChanged += new System.EventHandler(this.btnFindWindow_MouseCaptureChanged);
			this.btnFindWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnFindWindow_MouseDown);
			this.btnFindWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFindWindow_MouseMove);
			this.btnFindWindow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFindWindow_MouseUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(2, 4);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(4);
			this.label1.Size = new System.Drawing.Size(108, 20);
			this.label1.TabIndex = 25;
			this.label1.Text = "Add target window";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 380);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "MultipleKeySender";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView lstWindows;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnFindWindow;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edtInput;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtDetails;
		private System.Windows.Forms.Timer timer1;

	}
}

