/*
 * Name
 * Lab
 * Fall 2022
 */
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie : IValidatableObject
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        public Movie () : this("", "")
        {
        }

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        /// <param name="title">The title.</param>
        public Movie ( string title ) : this(title, "")
        {
        }

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public Movie ( string title, string description ) : base() // Object.ctor()
        {
            Title = title;
            Description = description;
        }
        #endregion

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            //Expression body            
            get => _title ?? "";                 //{ return _title ?? ""; }   
            set => _title = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private string _title;

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get => _description ?? "";                  //{ return _description ?? ""; }
            set => _description = value?.Trim() ?? "";  //{ _description = value?.Trim() ?? ""; }
        }
        private string _description;

        /// <summary>Gets or sets the run length in minutes.</summary>
        public int RunLength { get; set; }

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Gets or sets the MPAA rating.</summary>
        public string Rating
        {
            get => _rating ?? "";                   //{ return _rating ?? ""; }
            set => _rating = value?.Trim() ?? "";   //{ _rating = value?.Trim() ?? ""; }
        }
        private string _rating;

        /// <summary>Determines if the movie is a classic.</summary>
        public bool IsClassic { get; set; }

        /// <summary>Determines if the movie is black and white.</summary>
        //public bool IsBlackAndWhite () { return _releaseYear < 1939; }
        public bool IsBlackAndWhite => ReleaseYear < YearColorWasIntroduced;
        //{
        //    //get { return ReleaseYear < YearColorWasIntroduced; }
        //    get => ReleaseYear < YearColorWasIntroduced;
        //}

        //Public fields are allowed when they are constants
        public const int YearColorWasIntroduced = 1939;

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Clone ()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;
        }

        /// <summary>Copy the movie to another instance.</summary>
        /// <param name="movie">Movie to copy into.</param>
        public void CopyTo ( Movie movie )
        {
            movie.Id = Id;
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }

        /// <inheritdoc />
        public override string ToString () => Title; //{ return Title; }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            if (Title.Length == 0)
                errors.Add(new ValidationResult("Title is required", new[] { nameof(Title) }));

            if (Rating.Length == 0)
                errors.Add(new ValidationResult("Rating is required", new[] { nameof(Rating) }));

            if (RunLength <= 0)
                errors.Add(new ValidationResult("Run Length must be > 0", new[] { nameof(RunLength) }));

            if (ReleaseYear < 1900)
                errors.Add(new ValidationResult("Release Year must be >= 1900", new[] { nameof(ReleaseYear) }));

            return errors;
        }
    }
}