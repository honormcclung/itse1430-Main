﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honor.ContactManager
{
    /// <summary>Provides a database of contacts.</summary>
    internal interface IContactDatabase
    {
        /// <summary>Adds a contact to the database.</summary>
        /// <param name="contact">The comtact to add.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>The new contact.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Contact is null
        ///   - Contact is not valid
        ///   - Contact title already exists
        /// </remarks>
        Contact Add ( Contact contact);

        /// <summary>Gets a contact.</summary>
        /// <param name="lastName">Last name of the contact.</param>
        /// <returns>The contact, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Last name is null
        ///    - Last name is not valid
        /// </remarks>
        Contact Get ( string lastName );

        /// <summary>Gets all the contacts.</summary>
        /// <returns>The contacts.</returns>        
        IEnumerable<Contact> GetAll ();

        /// <summary>Remove a contact.</summary>
        /// <param name="id">ID of the contact to remove.</param>
        /// <remarks>
        /// Fails if:
        /// - Id <= 0
        /// </remarks>
        void Remove ( int id );

        /// <summary>Updates a contact in the database.</summary>
        /// <param name="contact">The new contact information.</param>
        /// <param name="id">ID of the contact to remove.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>true if successful or false otherwise.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Id is <= 0
        ///   - Contact does not already exist
        ///   - Contact is null
        ///   - Contact is not valid
        ///   - Contact title already exists
        /// </remarks>
        void Update ( int id, Contact contact );
    }
}
