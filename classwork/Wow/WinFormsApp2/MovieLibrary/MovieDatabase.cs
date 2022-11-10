namespace MovieLibrary
{
    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <inheritdoc />
        public Movie Add ( Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return null;
            };

            //Use IValidatableObject Luke...
            if (!ObjectValidator.IsValid(movie, out errorMessage))
                return null;

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                errorMessage = "Movie must be unique";
                return null;
            };

            //Add
            movie = AddCore(movie);

            errorMessage = null;
            return movie;
        }

        /// <inheritdoc />        
        public Movie Get ( int id )
        {
            //TODO: Error
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        /// <inheritdoc />                
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />        
        public void Remove ( int id )
        {
            if (id <= 0)
                return;

            RemoveCore(id);
        }

        /// <inheritdoc />        
        public bool Update ( int id, Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };

            if (!ObjectValidator.IsValid(movie, out errorMessage))
                return false;

            //Movie must already exist
            var oldMovie = GetCore(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist";
                return false;
            };

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };

            UpdateCore(id, movie);

            errorMessage = null;
            return true;
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Gets a movie by ID.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all movies.</summary>
        /// <returns>The list of movies.</returns>
        protected abstract IEnumerable<Movie> GetAllCore ();

        /// <summary>Removes a movie given its ID.</summary>
        /// <param name="id">The movie ID.</param>
        protected abstract void RemoveCore ( int id );

        /// <summary>Updates an existing movie.</summary>
        /// <param name="id">The movie ID.</param>
        /// <param name="movie">The movie details.</param>
        protected abstract void UpdateCore ( int id, Movie movie );

        /// <summary>Finds a movie by its title.</summary>
        /// <param name="title">The movie title.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie FindByTitle ( string title );
    }
}
