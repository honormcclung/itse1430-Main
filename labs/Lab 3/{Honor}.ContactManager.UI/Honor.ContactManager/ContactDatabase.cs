using Honor.ContactManager;

using MongoDB.Bson;

namespace Honor.ContactManager
{
    /// <summary>Manages a list of contacts.</summary>
    public abstract class ContactDatabase : IContactDatabase
    {
        /*
       public List<Contact> ContactDatabase: IContactDatabase ()
        {
            public static List<Contact> _contacts = new List<Contact> ();
        }
        */

        //public ContactDatabase ()
        //{
        //    List<Contact> _contacts = new List<Contact>();
        //}

        //public static List<Contact> _contacts;
        //= new List<Contact>();

        //public List<Contact> contacts { set { _contacts = value; } get { return _contacts; } }

        /// <inheritdoc />
        public Contact Add ( Contact contact, out string errorMessage )
        {
            //Validate contact
            //if (contact == null)
            //    throw new ArgumentNullException(nameof(contact));

            //Use IValidatableObject Luke...
            //ObjectValidator.Validate(contact);

            //Validate movie
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return null;
            };

            if (!ObjectValidator.TryValidate(contact, out var error))
            {
                errorMessage = error;
                return null;
            }

            //Must be unique
            //var existing = Get(contact.Id);
            //if (existing != null)
            //   throw new InvalidOperationException("Contact name must be unique.");

            //Must be unique
            var existing = FindByLastName(contact.LastName);
            if (existing != null)
            {
                errorMessage = "Contact already exists.";
                return null;
            };

            //Add
            contact = AddCore(contact);
            //_contacts.Add(contact);

            errorMessage = null;

            return contact;
        }

        /// <inheritdoc />        
        public Contact Get ( int id )
        {
            //Contact newContact = new Contact();
            //bool contactExists = false;

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID name must be > 0.");
            }
            /*
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                {
                    //newContact = contact;
                    //contactExists = true;
                    return contact;
                    break;
                }
            }
            */

            return GetCore(id);
            //return null;
            //return newContact;
        }

        /// <inheritdoc />                
        public IEnumerable<Contact> GetAll ()
        {
            //return _contacts;
            return GetAllCore() ?? Enumerable.Empty<Contact>();
        }

        /// <inheritdoc />        
        public void Remove ( int id )
        {

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
            /*
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                {
                    //contactExists = true;
                    _contacts.Remove(contact);

                }
            }
            */



        }

        /// <inheritdoc />        
        public bool Update ( int id, Contact contact, out string errorMessage )
        {
            //Validate contact
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return false;
                //return errorMessage;
            };

            if (!ObjectValidator.TryValidate(contact, out var error))
            {
                errorMessage = error;
                return false;
            }; ;

            //Contact must already exist
            var oldContact = GetCore(id);
            if (oldContact == null)
            {
                errorMessage = "Contact does not exist.";
                return false;
                //return errorMessage;
            };

            //Must be unique
            //var existing = Get(newContact.Id);
            var existing = FindByLastName(contact.LastName);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Contact already exists with the given name.";
                return false;
                //return errorMessage;
            };
            /*
            try
            {
                foreach (var contact in _contacts)
                {
                    if (contact.Id == id)
                    {
                        //contactExists = true;
                        _contacts.Remove(contact);

                    }
                }
                _contacts.Add(newContact);
                //UpdateCore(id, contact);
            } catch (Exception)
            {
                errorMessage = "Update failed";
            };
            */

            UpdateCore(id, contact);

            errorMessage = null;

            //return errorMessage;
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


