using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Honor.ContactManager
{
    public class MemoryContactDatabase: ContactDatabase
    {
        /// <summary>Adds a contact to the database.</summary>
        /// <param name="contact">The contact to add.</param>
        /// <returns>The new contact.</returns>
        protected override Contact AddCore ( Contact contact )
        {
            //Add
            contact.Id = _id++;
            _contacts.Add(contact.Clone());

            return contact;
        }


        /// <summary>Gets a contact by ID.</summary>
        /// <param name="id">The ID of the contact.</param>
        /// <returns>The contact, if any.</returns>
        protected override Contact GetCore ( int id )
        {
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                {
                    return contact;
                }
            }

            return null;
        }

        /// <summary>Gets all contacts.</summary>
        /// <returns>The list of contacts.</returns>
        protected override IEnumerable<Contact> GetAllCore ()
        {
            return _contacts;
        }

        /// <summary>Removes a contact given its ID.</summary>
        /// <param name="id">The contact ID.</param>
        protected override void RemoveCore ( int id )
        {
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                {
                    _contacts.Remove(contact);
                    break;
                }
            }
        }

        /// <summary>Updates an existing contact.</summary>
        /// <param name="id">The contact ID.</param>
        /// <param name="contact">The contact details.</param>
        protected override void UpdateCore ( int id, Contact newContact )
        {
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                {
                    contact.FirstName = newContact.FirstName;
                    contact.LastName = newContact.LastName;
                    contact.Email = newContact.Email;
                    contact.Notes = newContact.Notes;
                    contact.IsFavorite = newContact.IsFavorite;
                    break;
                }
            }
        }

        /// <summary>Finds a contact by its title.</summary>
        /// <param name="lastName">The contact last name.</param>
        /// <returns>The contact, if any.</returns>
        protected override Contact FindByLastName ( string lastName )
        {
            foreach (var contact in _contacts)
            {
                if (contact.LastName == lastName)
                {
                    return contact;
                    //break;
                }
            }

            return null;
        }

        #region Private Members
        private Contact FindById ( int id )
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        private int _id = 1;

        private List<Contact> _contacts = new List<Contact>();
        #endregion
    }
}
