namespace _Honor_.ContactManager.UI
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtLastName = new System.Windows.Forms.TextBox();
            this._txtFirstName = new System.Windows.Forms.TextBox();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._chkIsFavorite = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txtNotes = new System.Windows.Forms.TextBox();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name (optional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email ";
            // 
            // _txtLastName
            // 
            this._txtLastName.Location = new System.Drawing.Point(282, 54);
            this._txtLastName.Name = "_txtLastName";
            this._txtLastName.Size = new System.Drawing.Size(224, 31);
            this._txtLastName.TabIndex = 5;
            // 
            // _txtFirstName
            // 
            this._txtFirstName.Location = new System.Drawing.Point(282, 114);
            this._txtFirstName.Name = "_txtFirstName";
            this._txtFirstName.Size = new System.Drawing.Size(224, 31);
            this._txtFirstName.TabIndex = 6;
            // 
            // _txtEmail
            // 
            this._txtEmail.Location = new System.Drawing.Point(282, 173);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(224, 31);
            this._txtEmail.TabIndex = 7;
            this._txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.onValidateEmail);
            // 
            // _chkIsFavorite
            // 
            this._chkIsFavorite.AutoSize = true;
            this._chkIsFavorite.Location = new System.Drawing.Point(282, 229);
            this._chkIsFavorite.Name = "_chkIsFavorite";
            this._chkIsFavorite.Size = new System.Drawing.Size(22, 21);
            this._chkIsFavorite.TabIndex = 8;
            this._chkIsFavorite.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Is Favorite";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Notes";
            // 
            // _txtNotes
            // 
            this._txtNotes.AcceptsReturn = true;
            this._txtNotes.AcceptsTab = true;
            this._txtNotes.Location = new System.Drawing.Point(282, 281);
            this._txtNotes.Multiline = true;
            this._txtNotes.Name = "_txtNotes";
            this._txtNotes.Size = new System.Drawing.Size(428, 116);
            this._txtNotes.TabIndex = 11;
            // 
            // _errors
            // 
            this._errors.ContainerControl = this;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(572, 448);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(112, 34);
            this._btnSave.TabIndex = 12;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.onSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(690, 448);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(112, 34);
            this._btnCancel.TabIndex = 13;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.onCancel);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 494);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtNotes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._chkIsFavorite);
            this.Controls.Add(this._txtEmail);
            this.Controls.Add(this._txtFirstName);
            this.Controls.Add(this._txtLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ContactForm";
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox _txtLastName;
        private TextBox _txtFirstName;
        private TextBox _txtEmail;
        private CheckBox _chkIsFavorite;
        private Label label4;
        private Label label5;
        private TextBox _txtNotes;
        private ErrorProvider _errors;
        private Button _btnCancel;
        private Button _btnSave;
    }
}