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
            //_contacts.Add(contact);

            //return contact;

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
                    //newContact = contact;
                    //contactExists = true;
                    return contact;
                    break;
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
                    //newContact = contact;
                    //contactExists = true;
                    //return contact;
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
                    //newContact = contact;
                    //contactExists = true;
                    //return contact;
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
                    //newContact = contact;
                    //contactExists = true;
                    return contact;
                    break;
                }
            }

            return null;
        }

        #region Private Members

        //Action -> Method with no return type
        // Action<T> -> parameter of T
        // Action<T1..T16> -> parameters of T1 to T16
        //Func<R> -> Method with a return type of R
        // Func<T, R> -> parameter of T
        // Func<T1..T16, R> -> parameters of T1 to T16
        private Contact FindById ( int id )
        {
            // Where takes a IEnumerable<T> and returns all items that match the predicate
            // defined by Func<Movie, bool>
            //return _movies.Where(FilterById)
            //              .FirstOrDefault();
            // If you need extra data then a nested class with the data would be needed
            // return _movies.FirstOrDefault(new MyHiddenClass(id).FilterById);
            //return _movies.FirstOrDefault(FilterById);

            //lambda - anonymous method/function
            //  foo ( Movie x ) { return x.Id == id; }
            return _contacts.FirstOrDefault(x => x.Id == id);

            //foreach (var movie in _movies)
            //    if (movie.Id == id)
            //        return movie;

            //return null;
        }
        //private bool FilterById ( Movie movie )
        //{
        //    return true;
        //}

        private int _id = 1;

        //private Movie[] _movies = new Movie[100];
        private List<Contact> _contacts = new List<Contact>();
        #endregion
    }
}
