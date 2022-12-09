using System;

using Honor.ContactManager;

using Microsoft.VisualBasic.Devices;

namespace _Honor_.ContactManager.UI
{
    public partial class MainForm : Form
    {
        #region Construction

        ////////
        ///////////
        //public ContactDatabase _contacts = new Honor.ContactManager.MemoryContactDatabase();
        ///////////////
        /////////////
        ///

        public MainForm ( )
        {
            InitializeComponent();
        }

        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }

        #region Event Handlers

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void onHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutContactManager();

            about.ShowDialog();
        }

        private void onContactsAdd ( object sender, EventArgs e )
        {
            var child = new ContactForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(child.SelectedContact, out var error) != null)
                {
                    break;
                };

                DisplayError(error, "Add Failed");
            } while (true);

            UpdateUI();
        }

        private void OnContactEdit ( object sender, EventArgs e )
        {
            EditContact();
        }
 
        private void OnContactDelete ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete '{contact.FullName}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _contacts.Remove(contact.Id);
            UpdateUI();
        }

        private void OnContactDoubleClick ( object sender, MouseEventArgs e )
        {
            EditContact();
        }

        #endregion

        #region Private Members
        
        private void UpdateUI ()
        {
            UpdateUI(false);
        }
        

        private void UpdateUI ( bool initialLoad )
        {
            var contacts = _contacts.GetAll();
           
            if (initialLoad == true)
            {
                if (Confirm("Do you want to seed some movies?", "Database Empty"))
                {
                    _contacts.Seed();
                    contacts = _contacts.GetAll();
                };
            };

            _lstContacts.Items.Clear();

            var items = contacts.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);

            _lstContacts.Items.AddRange(contacts.ToArray());
        }

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private Contact GetSelectedContact ()
        {
            return _lstContacts.SelectedItem as Contact;
        }
        

        private void EditContact ()
        {
            
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            var form = new ContactForm() { SelectedContact = contact };
            while (true)
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Update(contact.Id, form.SelectedContact, out var error))
                    break;

                DisplayError("Updated Failed", error);
            };

            UpdateUI();
            
        }

        private readonly IContactDatabase _contacts = new Honor.ContactManager.MemoryContactDatabase();

        #endregion

        private void _lstContacts_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }

    }
}