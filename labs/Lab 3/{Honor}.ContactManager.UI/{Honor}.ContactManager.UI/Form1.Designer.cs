namespace _Honor_.ContactManager.UI
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
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onContactsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this._lstContacts = new System.Windows.Forms.ListView();
            this.ListViewLastName = new System.Windows.Forms.ColumnHeader();
            this.ListViewFirstName = new System.Windows.Forms.ColumnHeader();
            this.ListViewEmail = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.contactsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // onHelpAbout
            // 
            this.onHelpAbout.Name = "onHelpAbout";
            this.onHelpAbout.Size = new System.Drawing.Size(164, 34);
            this.onHelpAbout.Text = "About";
            this.onHelpAbout.Click += new System.EventHandler(this.onHelpAbout_Click);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onContactsAdd});
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.contactsToolStripMenuItem.Text = "Contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // onContactsAdd
            // 
            this.onContactsAdd.Name = "onContactsAdd";
            this.onContactsAdd.Size = new System.Drawing.Size(148, 34);
            this.onContactsAdd.Text = "Add";
            this.onContactsAdd.Click += new System.EventHandler(this.onContactsAdd_Click);
            // 
            // _lstContacts
            // 
            this._lstContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListViewLastName,
            this.ListViewFirstName,
            this.ListViewEmail});
            this._lstContacts.Location = new System.Drawing.Point(32, 69);
            this._lstContacts.Name = "_lstContacts";
            this._lstContacts.Size = new System.Drawing.Size(717, 348);
            this._lstContacts.TabIndex = 1;
            this._lstContacts.UseCompatibleStateImageBehavior = false;
            this._lstContacts.View = System.Windows.Forms.View.Details;
            // 
            // ListViewLastName
            // 
            this.ListViewLastName.Text = "Last Name";
            this.ListViewLastName.Width = 220;
            // 
            // ListViewFirstName
            // 
            this.ListViewFirstName.Text = "FirstName";
            this.ListViewFirstName.Width = 200;
            // 
            // ListViewEmail
            // 
            this.ListViewEmail.Text = "ListViewEmail";
            this.ListViewEmail.Width = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._lstContacts);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HonorsContactManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem onHelpAbout;
        private ToolStripMenuItem contactsToolStripMenuItem;
        private ToolStripMenuItem onContactsAdd;
        private ListView _lstContacts;
        private ColumnHeader ListViewLastName;
        private ColumnHeader ListViewFirstName;
        private ColumnHeader ListViewEmail;
    }
}