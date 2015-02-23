namespace PortWizard
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ProcessListView = new System.Windows.Forms.ListView();
            this._processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._portnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.endProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadingImage = new System.Windows.Forms.PictureBox();
            this.LoadingTextLabel = new System.Windows.Forms.Label();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).BeginInit();
            this.LoadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessListView
            // 
            this.ProcessListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._processName,
            this._portnum});
            this.ProcessListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessListView.Location = new System.Drawing.Point(0, 0);
            this.ProcessListView.Name = "ProcessListView";
            this.ProcessListView.Size = new System.Drawing.Size(739, 164);
            this.ProcessListView.TabIndex = 0;
            this.ProcessListView.UseCompatibleStateImageBehavior = false;
            this.ProcessListView.View = System.Windows.Forms.View.Details;
            this.ProcessListView.SelectedIndexChanged += new System.EventHandler(this.ProcessListView_SelectedIndexChanged);
            this.ProcessListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProcessListView_MouseClick);
            // 
            // _processName
            // 
            this._processName.Text = "Process Name";
            this._processName.Width = 93;
            // 
            // _portnum
            // 
            this._portnum.Text = "Port Number Used";
            this._portnum.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endProcessToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 26);
            // 
            // endProcessToolStripMenuItem
            // 
            this.endProcessToolStripMenuItem.Name = "endProcessToolStripMenuItem";
            this.endProcessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.endProcessToolStripMenuItem.Text = "End Process";
            this.endProcessToolStripMenuItem.Click += new System.EventHandler(this.endProcessToolStripMenuItem_Click);
            // 
            // LoadingImage
            // 
            this.LoadingImage.Image = global::PortWizard.Properties.Resources.loading;
            this.LoadingImage.Location = new System.Drawing.Point(40, 18);
            this.LoadingImage.Name = "LoadingImage";
            this.LoadingImage.Size = new System.Drawing.Size(49, 50);
            this.LoadingImage.TabIndex = 2;
            this.LoadingImage.TabStop = false;
            // 
            // LoadingTextLabel
            // 
            this.LoadingTextLabel.AutoSize = true;
            this.LoadingTextLabel.Location = new System.Drawing.Point(6, 77);
            this.LoadingTextLabel.Name = "LoadingTextLabel";
            this.LoadingTextLabel.Size = new System.Drawing.Size(126, 13);
            this.LoadingTextLabel.TabIndex = 3;
            this.LoadingTextLabel.Text = "Now scanning processes";
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.Controls.Add(this.LoadingImage);
            this.LoadingPanel.Controls.Add(this.LoadingTextLabel);
            this.LoadingPanel.Location = new System.Drawing.Point(589, 64);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(138, 100);
            this.LoadingPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 164);
            this.Controls.Add(this.ProcessListView);
            this.Controls.Add(this.LoadingPanel);
            this.Name = "Form1";
            this.Text = "PortWizard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).EndInit();
            this.LoadingPanel.ResumeLayout(false);
            this.LoadingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ProcessListView;
        private System.Windows.Forms.ColumnHeader _processName;
        private System.Windows.Forms.ColumnHeader _portnum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem endProcessToolStripMenuItem;
        private System.Windows.Forms.PictureBox LoadingImage;
        private System.Windows.Forms.Label LoadingTextLabel;
        private System.Windows.Forms.Panel LoadingPanel;
    }
}

