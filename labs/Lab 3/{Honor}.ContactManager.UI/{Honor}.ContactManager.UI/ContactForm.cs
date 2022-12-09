﻿using System.ComponentModel;
using System.Net.Mail;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

using Honor.ContactManager;

namespace _Honor_.ContactManager.UI
{
    public partial class ContactForm : Form
    {
        List<string> errorList = new List<string>();

        #region Construction
        public ContactForm ( /*IEnumerable<Contact> contacts*/ )
        {
            InitializeComponent();
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            //IEnumerable<Contact> contactsList = contacts;
        }

        #endregion

        /// <summary>Gets or sets the movie being edited.</summary>
        public Contact SelectedContact { get; set; }

        #region Protected Members
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (SelectedContact != null)
            {
                _txtFirstName.Text = SelectedContact.FirstName;
                _txtLastName.Text = SelectedContact.LastName;
                _txtEmail.Text = SelectedContact.Email;

                _txtNotes.Text = SelectedContact.Notes;
                _chkIsFavorite.Checked = SelectedContact.IsFavorite;
            };
        }

        #endregion

        private void onSave ( object sender, EventArgs e )
        {
            //Force validation of children
            if (!ValidateChildren())
                return;
            var btn = sender as Button;

            var contact = new Contact();
            contact.LastName = _txtLastName.Text;
            contact.FirstName = _txtFirstName.Text;
            contact.Email = _txtEmail.Text;
            contact.IsFavorite = _chkIsFavorite.Checked;
            contact.Notes = _txtNotes.Text;
            //contact.Id = contact.GenerateNewId();

            if (!ObjectValidator.TryValidate(contact, out var error))
            {
                DisplayError(error, "Save");
                ///
                foreach (var errorMsg in errorList)
                {
                    DisplayError(errorMsg, "Save");
                }
                ///
                return;
            };

            //Get rid of form by
            // setting Form's DialogResult to a reasonable value
            // Call Close()
            SelectedContact = contact;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void onCancel ( object sender, EventArgs e )
        {
            //DialogResult = DialogResult.OK;
            //Close();
            DialogResult = DialogResult.Cancel;
        }

        private void onValidateEmail ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            bool IsValidEmail ( string source )
            {
                return MailAddress.TryCreate(source, out var address);
            }

            if (IsValidEmail(control.Text) == false)
            {
                //e.Cancel = true;
                //control.Focus();
                _errors.SetError(control, "Email is not valid");
                errorList.Add("Email is not valid");
                e.Cancel = true;
            } else
            {
                //Valid
                //e.Cancel = true;
                _errors.SetError(control, "");
                //e.Cancel = true;
            }
        }

        private void onLastNameValidating ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //Not valid
                //e.Cancel = true;
                //control.Focus();
                _errors.SetError(control, "Last name is required");
                errorList.Add("Last name is required");
                e.Cancel = true;
                //e.Cancel = true;
            } /*else if ( == null)
            {
                //Valid
                //e.Cancel = true;
                _errors.SetError(control, "Last name must be unique");
                errorList.Add("Last name muyst be unique");
                //e.Cancel = true;
            } */else
            {
                _errors.SetError(control, "");
            }
        }
    }
}
