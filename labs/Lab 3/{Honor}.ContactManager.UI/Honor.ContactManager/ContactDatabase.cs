using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honor.ContactManager
{
    /// <summary>Provides a base implementation of <see cref="IContactDatabase"/>.</summary>
    public abstract class ContactDatabase : IContactDatabase
    {

        public Contact Add ( Contact contact, out string errorMessage )
        {
            //Validate movie
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return null;
            };

            //Use IValidatableObject Luke...
            if (!ObjectValidator.IsValid(contact, out errorMessage))
                return null;

            //Must be unique
            var existing = FindByLastName(contact.LastName);
            if (existing != null)
            {
                errorMessage = "Movie must be unique";
                return null;
            };

            //Add
            contact = AddCore(contact);

            errorMessage = null;
            return contact;
        }

        /// <inheritdoc />        
        public Contact Get ( int id )
        {
            //TODO: Error
            if (id <= 0)
                return null;

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
                return;

            RemoveCore(id);
        }

        /// <inheritdoc />        
        public bool Update ( int id, Contact contact, out string errorMessage )
        {
            //Validate movie
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return false;
            };

            if (!ObjectValidator.IsValid(contact, out errorMessage))
                return false;

            //Movie must already exist
            var oldMovie = GetCore(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist";
                return false;
            };

            //Must be unique
            var existing = FindByLastName(contact.LastName);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };

            UpdateCore(id, contact);

            errorMessage = null;
            return true;
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        protected abstract Contact AddCore ( Contact contact );

        /// <summary>Gets a contact by last name.</summary>
        /// <param name="lastName">The last name of the contact.</param>
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
        protected abstract Contact FindByLastName ( string lastName );

        public Contact Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Get(string lastName)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
