using System.ComponentModel;

namespace WinFormsApp2
{
    public partial class MovieForm : Form
    {
        #region Construction

        public MovieForm ()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>Gets or sets the movie being edited.</summary>
        public Movie SelectedMovie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Do any init just before UI is rendered
            if (SelectedMovie != null)
            {
                //Load UI
                _txtTitle.Text = SelectedMovie.Title;
                _txtDescription.Text = SelectedMovie.Description;
                _cbRating.Text = SelectedMovie.Rating;

                _chkIsClassic.Checked = SelectedMovie.IsClassic;
                _txtRunLength.Text = SelectedMovie.RunLength.ToString();
                _txtReleaseYear.Text = SelectedMovie.ReleaseYear.ToString();
            };

            //Force validation
            ValidateChildren();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //Force validation of children
            if (!ValidateChildren())
                return;

            var btn = sender as Button;

            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;

            movie.IsClassic = _chkIsClassic.Checked;
            movie.RunLength = GetInt32(_txtRunLength);
            movie.ReleaseYear = GetInt32(_txtReleaseYear);

            //var validator = new ObjectValidator();            
            //if (!movie.Validate(out var error))
            //if (!new ObjectValidator().IsValid(movie, out var error))
            if (!ObjectValidator.IsValid(movie, out var error))
            {
                DisplayError(error, "Save");
                return;
            };

            //Get rid of form by
            // setting Form's DialogResult to a reasonable value
            // Call Close()
            SelectedMovie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        #region Private Members

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetInt32 ( TextBox control )
        {
            //String.Compare("A", "B");
            //"A".Compare("B");

            //String.Format("Format string", 1, 2);
            //"Format string".Format(1, 2);

            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }
        #endregion

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //Not valid
                _errors.SetError(control, "Title is required");
                e.Cancel = true;
            } else
            {
                //Valid
                _errors.SetError(control, "");
            };
        }

        private void OnValidateRating ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //Not valid
                _errors.SetError(control, "Rating is required");
                e.Cancel = true;
            } else
            {
                //Valid
                _errors.SetError(control, "");
            };
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetInt32(control);
            if (value < 1900)
            {
                //Not valid
                _errors.SetError(control, "Release Year must be at least 1900");
                e.Cancel = true;
            } else
            {
                //Valid
                _errors.SetError(control, "");
            };
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var value = GetInt32(control);
            if (value < 0)
            {
                //Not valid
                _errors.SetError(control, "Run Length must be >= 0");
                e.Cancel = true;
            } else
            {
                //Valid
                _errors.SetError(control, "");
            };
        }
    }
}
