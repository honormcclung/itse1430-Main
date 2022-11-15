using Honor.ContactManager;

namespace Honor.ContactManager;

/// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
public abstract class ContactDatabase : IContactDatabase
{
    /// <inheritdoc />
    public Contact Add ( Contact contact )
    {
        //Validate movie
        if (contact == null)
            throw new ArgumentNullException(nameof(contact));

        //Use IValidatableObject Luke...
        ObjectValidator.Validate(contact);

        //Must be unique
        var existing = FindByTitle(contact.LastName);
        if (existing != null)
            throw new InvalidOperationException("Movie title must be unique.");

        //Add
        contact = AddCore(contact);
        return contact;
    }

    /// <inheritdoc />        
    public Contact Get ( int id )
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

        return GetCore(id);
    }

    /// <inheritdoc />                
    public IEnumerable<Contact> GetAll ()
    {
        return GetAllCore();
    }

    /// <inheritdoc />        
    public void Remove ( int id )
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

        RemoveCore(id);
    }

    /// <inheritdoc />        
    public void Update ( int id, Contact contact )
    {
        //Validate movie
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

        if (contact == null)
            throw new ArgumentNullException(nameof(contact));
        ObjectValidator.Validate(contact);

        //Movie must already exist
        var oldMovie = GetCore(id);
        if (oldMovie == null)
            throw new ArgumentException("Movie does not exist", nameof(contact));

        //Must be unique
        var existing = FindByTitle(contact.LastName);
        if (existing != null && existing.Id != id)
            throw new InvalidOperationException("Movie title must be unique.");

        try
        {
            UpdateCore(id, contact);
        } catch (Exception e)
        {
            throw new Exception("Update failed", e);
        };
    }

    /// <summary>Adds a movie to the database.</summary>
    /// <param name="movie">The movie to add.</param>
    /// <returns>The new movie.</returns>
    protected abstract Contact AddCore ( Contact contact );

    /// <summary>Gets a movie by ID.</summary>
    /// <param name="id">The ID of the movie.</param>
    /// <returns>The movie, if any.</returns>
    protected abstract Contact GetCore ( int id );

    /// <summary>Gets all movies.</summary>
    /// <returns>The list of movies.</returns>
    protected abstract IEnumerable<Contact> GetAllCore ();

    /// <summary>Removes a movie given its ID.</summary>
    /// <param name="id">The movie ID.</param>
    protected abstract void RemoveCore ( int id );

    /// <summary>Updates an existing movie.</summary>
    /// <param name="id">The movie ID.</param>
    /// <param name="movie">The movie details.</param>
    protected abstract void UpdateCore ( int id, Contact contact );

    /// <summary>Finds a movie by its title.</summary>
    /// <param name="title">The movie title.</param>
    /// <returns>The movie, if any.</returns>
    protected abstract Contact FindByTitle ( string title );
}
