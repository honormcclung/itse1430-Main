/*
 * Honor McClung
 * Lab 3
 * ISTE 1430 - Fall 2022 
 * 12/1/2022
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Runtime.Serialization;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Honor.ContactManager
{
    public class Contact : IValidatableObject
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Contact"/> class.</summary>
        public Contact () : this("", "", false)
        {
        }

        /// <summary>Initializes an instance of the <see cref="Contact"/> class.</summary>
        /// <param name="lastName'">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="isFavorite">If the customer is a favorite.</param>
        public Contact (string lastName, string email, bool isFavorite ) : base()
        {
            LastName = lastName;
            Email = email;
            IsFavorite = isFavorite;
        }

        /// <summary>Initializes an instance of the <see cref="Contact"/> class.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName'">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="isFavorite">If the customer is a favorite.</param>
        public Contact ( string firstName, string lastName, string email, bool isFavorite ) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsFavorite = isFavorite;
        }

        /// <summary>Initializes an instance of the <see cref="Contact"/> class.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName'">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="isFavorite">If the customer is a favorite.</param>
        public Contact ( string firstName, string lastName, string email, string notes, bool isFavorite ) : base() 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Notes = notes;
            IsFavorite = isFavorite;
        }

        #endregion

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        public string FirstName
        {
            get => _firstName ?? "";                    
            set => _firstName = value?.Trim() ?? ""; 
        }
        private string _firstName;

        /// <summary>Gets or sets the last name.</summary>
        public string LastName
        {
            get => _lastName ?? "";                    
            set => _lastName = value?.Trim() ?? ""; 
        }
        private string _lastName;

        /// <summary>Gets the full name of the contact.</summary>
        public string FullName
        {
            get { return String.Join(" ", FirstName, LastName); }
        }

        /// <summary>Gets or sets the email.</summary>
        public string Email
        {
            get => _email ?? "";                   
            set => _email = value?.Trim() ?? ""; 
        }
        private string _email;

        /// <summary>Gets or sets the contact notes.</summary>
        public string Notes
        {
            get => _notes ?? "";                    
            set => _notes = value?.Trim() ?? ""; 
        }
        private string _notes;


        /// <summary>Determines if the contact is a favorite.</summary>
        public bool IsFavorite { get; set; }

        /// <summary>Converts the contact information to a string.</summary>
        /// <returns>A string of comtact information.</returns>
        public override string ToString ()
        {
                return $"{LastName},{FirstName} ({Email})";
        }

        /// <summary>Clones the existing contact.</summary>
        /// <returns>A copy of the contact.</returns>
        public Contact Clone ()
        {
            var contact = new Contact();
            CopyTo(contact);

            return contact;
        }

        /// <summary>Copy the contact to another instance.</summary>
        /// <param name="contact">Contact to copy into.</param>
        public void CopyTo ( Contact contact )
        {
            contact.Id = Id;
            contact.LastName = LastName;
            contact.Notes = Notes;
            contact.FirstName = FirstName;
            contact.Email = Email;
            contact.IsFavorite = IsFavorite;
        }

        /// <summary>Checks if email is valid.</summary>
        /// <param name="source">Email address.</param>
        /// <returns>Boolean on whether contact is valid.</returns>
        public bool IsValidEmail ( string source )
        {
            return MailAddress.TryCreate(source, out var address);
        }

        /// <summary>Validates the object.</summary>
        /// <param name="validationContext">The context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if(string.IsNullOrEmpty(LastName))
            yield return new ValidationResult("LastName is required.", new[] { nameof(LastName) });

            if (string.IsNullOrEmpty(Email))
                yield return new ValidationResult("Email is required.", new[] { nameof(Email) });
            else if (IsValidEmail(Email) == false)
                yield return new ValidationResult("Email is not properly formatted.", new[] { nameof(Email) });
        }
    }
}