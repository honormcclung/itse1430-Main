using System;

using Honor.ContactManager;

using Microsoft.VisualBasic.Devices;

namespace _Honor_.ContactManager.UI
{
    public partial class MainForm : Form
    {
        #region Construction
        //public ContactDatabase _contacts = new ContactDatabase();

        ////////
        ///////////
        //public ContactDatabase _contacts = new Honor.ContactManager.MemoryContactDatabase();
        ///////////////
        /////////////
        ///

        //List<Contact> contacts = _contacts.GetAll();
        //_contacts

        //ContactList _contacts = new Honor.ContactManager.ContactList();


        public MainForm ( )
        {
            InitializeComponent();
        }

        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI();
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
                //Showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(child.SelectedContact, out var error) != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError("Error", "Add Failed");
            } while (true);
        }

        private void OnContactsEdit ( object sender, EventArgs e )
        {

        }

        private void OnContactsDelete ( object sender, EventArgs e )
        {

        }
        /*
        private void exitToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Close();
        }

        private void onHelpAbout_Click ( object sender, EventArgs e )
        {
            var about = new AboutContactManager();

            about.ShowDialog();
        }

        private void onContactsAdd_Click ( object sender, EventArgs e )
        {
            //var contacts = _contacts.GetAll()

            var child = new ContactForm();

            //var movie = GetSelectedMovie();
            //if (movie == null)
                //return;

            //var child = new MovieForm();
            //child.SelectedMovie = movie;

            do
            {
                //Showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(child.SelectedContact, out var error) != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError("Error", "Add Failed");
            } while (true);
        }

        private void contactsToolStripMenuItem_Click ( object sender, EventArgs e )
        {

        }
        */

        #endregion

        #region Private Members

        private void UpdateUI ()
        {
            UpdateUI(false);
        }

        private void UpdateUI ( bool initialLoad )
        {
            //Get movies
            var contacts = _contacts.GetAll();

            //Extension methods - static methods on static classes
            // 1. Expose a static method as an instance method for discoverability
            // 2. Called like instance methods (on an instance)
            // 3. Compiler rewrites code to call static method on static class
            //Enumerable.Count(movies) == movies.Count()            
            if (initialLoad &&
                    //movies.Count() == 0)
                    //movies.FirstOrDefault() == null)            
                    contacts.Any())
            {
                if (Confirm("Do you want to seed some movies?", "Database Empty"))
                {
                    //SeedMovieDatabase.Seed(_movies);
                    _contacts.Seed();
                    contacts = _contacts.GetAll();
                };
            };

            _lstContacts.Items.Clear();

            var items = contacts.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);

            //foreach (var contact in contacts)
            //    _lstContacts.Items.Add(new ListViewItem(new string[] {contact.LastName, contact.FirstName, contact.Email}));
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

        //private Contact _contacts;
        //private IMovieDatabase _movies = new Memory<Movie>.MemoryMovieDatabase();
        //private IContactDatabase _contacts = new Memory<ContactDatabase>.();
        //List<Contact> _contacts = new ContactDatabase();

        #endregion

        private void _lstContacts_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }
    }
}