namespace MovieLibrary
{
    /// <summary>Provides a database of movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>The new movie.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>
        Movie Add ( Movie movie, out string errorMessage );

        /// <summary>Gets a movie.</summary>
        /// <param name="id">ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Id is less than 1
        /// </remarks>
        Movie Get ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>        
        IEnumerable<Movie> GetAll ();

        /// <summary>Remove a movie.</summary>
        /// <param name="id">ID of the movie to remove.</param>
        /// <remarks>
        /// Fails if:
        /// - Id <= 0
        /// </remarks>
        void Remove ( int id );

        /// <summary>Updates a movie in the database.</summary>
        /// <param name="movie">The new movie information.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>true if successful or false otherwise.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Id is <= 0
        ///   - Movie does not already exist
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>
        bool Update ( int id, Movie movie, out string errorMessage );
    }
}