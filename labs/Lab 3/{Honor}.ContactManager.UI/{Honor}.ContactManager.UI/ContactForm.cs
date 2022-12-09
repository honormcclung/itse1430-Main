using System.ComponentModel;
using System.Net.Mail;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

using Honor.ContactManager;

/*
 * Honor McClung
 * Lab 3
 * ISTE 1430 - Fall 2022 
 * 12/1/2022
 */

namespace _Honor_.ContactManager.UI
{
    public partial class ContactForm : Form
    {
        List<string> _errorList = new List<string>();

        #region Construction
        public ContactForm ()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.EnableAllowFocusChange;
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
            if (!ValidateChildren())
                return;
            var btn = sender as Button;

            var contact = new Contact();
            contact.LastName = _txtLastName.Text;
            contact.FirstName = _txtFirstName.Text;
            contact.Email = _txtEmail.Text;
            contact.IsFavorite = _chkIsFavorite.Checked;
            contact.Notes = _txtNotes.Text;

            if (!ObjectValidator.TryValidate(contact, out var error))
            {
                DisplayError(error, "Save");
                ////////////////////////////////////////////////////////////////////////////////////
                foreach (var errorMsg in _errorList)
                {
                    DisplayError(errorMsg, "Save");
                }
                /////////////////////////////////////////////////////////////////////////////////////////
                return;
            };

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
                _errors.SetError(control, "Email is not valid");
                _errorList.Add("Email is not valid");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }

        private void onLastNameValidating ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Last name is required");
                _errorList.Add("Last name is required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }
    }
}
