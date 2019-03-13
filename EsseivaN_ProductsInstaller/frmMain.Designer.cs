namespace EsseivaN_ProductsInstaller
{
    partial class frmMain
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitPublishPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(9, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(782, 417);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.installSelectedToolStripMenuItem,
            this.visitPublishPageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editUrlToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // editUrlToolStripMenuItem
            // 
            this.editUrlToolStripMenuItem.Name = "editUrlToolStripMenuItem";
            this.editUrlToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.editUrlToolStripMenuItem.Text = "Edit url";
            this.editUrlToolStripMenuItem.Click += new System.EventHandler(this.editUrlToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // installSelectedToolStripMenuItem
            // 
            this.installSelectedToolStripMenuItem.Name = "installSelectedToolStripMenuItem";
            this.installSelectedToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.installSelectedToolStripMenuItem.Text = "Install selected";
            this.installSelectedToolStripMenuItem.Click += new System.EventHandler(this.installSelectedToolStripMenuItem_Click);
            // 
            // visitPublishPageToolStripMenuItem
            // 
            this.visitPublishPageToolStripMenuItem.Name = "visitPublishPageToolStripMenuItem";
            this.visitPublishPageToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.visitPublishPageToolStripMenuItem.Text = "Visit publish page";
            this.visitPublishPageToolStripMenuItem.Click += new System.EventHandler(this.visitPublishPageToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(9, 0, 9, 9);
            this.Text = "EsseivaN Installer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitPublishPageToolStripMenuItem;
    }
}

