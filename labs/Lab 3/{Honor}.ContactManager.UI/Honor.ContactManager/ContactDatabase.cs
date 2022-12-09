using Honor.ContactManager;

using MongoDB.Bson;

namespace Honor.ContactManager
{
    /// <summary>Manages a list of contacts.</summary>
    public abstract class ContactDatabase : IContactDatabase
    {
        /// <inheritdoc />
        public Contact Add ( Contact contact, out string errorMessage )
        {

            if (!ObjectValidator.TryValidate(contact, out var error))
            {
                errorMessage = error;
                return null;
            }

            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return null;
            };

            if (contact.LastName == null || contact.LastName == "")
            {
                errorMessage = "Contact cannot be null";
                return null;
            };

            var existing = FindByLastName(contact.LastName);
            if (existing != null)
            {
                errorMessage = "Contact already exists.";
                return null;
            };

            contact = AddCore(contact);

            errorMessage = null;

            return contact;
        }

        /// <inheritdoc />        
        public Contact Get ( int id )
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID name must be > 0.");
            }

            return GetCore(id);
        }

        /// <inheritdoc />                
        public IEnumerable<Contact> GetAll ()
        {
            return GetAllCore() ?? Enumerable.Empty<Contact>();
        }

        /// <inheritdoc />        
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
        }

        /// <inheritdoc />        
        public bool Update ( int id, Contact contact, out string errorMessage )
        {
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return false;
            };

            if (!ObjectValidator.TryValidate(contact, out var error))
            {
                errorMessage = error;
                return false;
            }; 

            var oldContact = GetCore(id);
            if (oldContact == null)
            {
                errorMessage = "Contact does not exist.";
                return false;
            };

            var existing = FindByLastName(contact.LastName);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Contact already exists with the given name.";
                return false;
            };

            UpdateCore(id, contact);

            errorMessage = null;

            return true;
        }

        #region Protected Memebers

        /// <summary>Adds a contact to the database.</summary>
        /// <param name="contact">The contact to add.</param>
        /// <returns>The new contact.</returns>
        protected abstract Contact AddCore ( Contact contact );


        /// <summary>Gets a contact by ID.</summary>
        /// <param name="id">The ID of the contact.</param>
        /// <returns>The contact, if any.</returns>
        protected abstract Contact GetCore ( int id );

        /// <summary>Gets all contacts.</summary>
        /// <returns>The list of contacts.</returns>
        protected abstract IEnumerable<Contact> GetAllCore ();

        /// <summary>Removes a contact given its ID.</summary>
        /// <param name="id">The contact ID.</param>
        protected abstract void RemoveCore ( int id );

        /// <summary>Updates an existing contact.</summary>
        /// <param name="id">The contact ID.</param>
        /// <param name="contact">The contact details.</param>
        protected abstract void UpdateCore ( int id, Contact contact );

        /// <summary>Finds a contact by its title.</summary>
        /// <param name="lastName">The contact last name.</param>
        /// <returns>The contact, if any.</returns>
        protected abstract Contact FindByLastName ( string lastName );

        #endregion
    }
}


