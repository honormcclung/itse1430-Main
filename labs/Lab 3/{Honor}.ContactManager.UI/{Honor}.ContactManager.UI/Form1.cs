using Honor.ContactManager;

using Microsoft.VisualBasic.Devices;

namespace _Honor_.ContactManager.UI
{
    public partial class Form1 : Form
    {
        #region Construction
        ContactDatabase _contacts = new ContactDatabase();

        //List<Contact> contacts = _contacts.GetAll();
        //_contacts

        //ContactList _contacts = new Honor.ContactManager.ContactList();


        public Form1 ( )
        {
            InitializeComponent();
        }

        #endregion
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

            //_lstMovies.Items.Clear();

            //Order movies by title, then by release year
            //Chain calls together
            //          movies.OrderBy(OrderByTitle());
            //  foreach item in source
            //      sortValue = func(item)
            //      compare sortValue to other values
            //var items = movies.OrderBy(OrderByTitle)
            //               .ThenBy(OrderByReleaseYear)
            var items = contacts.OrderBy(x => x.LastName)
                              .ThenBy(x => x.FirstName)
                              .ToList();
            //movies = movies.ThenBy();

            //Use Enumerable 
            //_lstMovies.Items.AddRange(Enumerable.ToArray(movies));

            //_lstMovies.Items.AddRange(items);
            //_contacts.AddRange(items);

            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);
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

        //private Contact _contacts;
        //private IMovieDatabase _movies = new Memory<Movie>.MemoryMovieDatabase();
        //private IContactDatabase _contacts = new Memory<ContactDatabase>.();
        //List<Contact> _contacts = new ContactDatabase();
    }
}