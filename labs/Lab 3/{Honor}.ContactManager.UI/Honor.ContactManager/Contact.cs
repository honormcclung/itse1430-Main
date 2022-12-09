/*
 * Honor McClung
 * Lab 3
 * ISTE 1430 - Fall 2022 
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
            //Id = id;
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
            //Id = id;
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
            //Id = id;
        }

        #endregion

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }
        /*
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        */

        /// <summary>Gets or sets the first name.</summary>
        public string FirstName
        {
            //Expression body            
            get => _firstName ?? "";                 //{ return _title ?? ""; }   
            set => _firstName = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private string _firstName;

        /// <summary>Gets or sets the last name.</summary>
        public string LastName
        {
            //Expression body            
            get => _lastName ?? "";                 //{ return _title ?? ""; }   
            set => _lastName = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private string _lastName;

        /// <summary>Gets the full name of the contact.</summary>
        public string FullName
        {
            get { return String.Join(" ", FirstName, LastName); }
        }
        //private String _fullName;

        /// <summary>Gets or sets the email.</summary>
        public string Email
        {
            //Expression body            
            get => _email ?? "";                 //{ return _title ?? ""; }   
            set => _email = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private string _email;

        /// <summary>Gets or sets the contact notes.</summary>
        public string Notes
        {
            //Expression body            
            get => _notes ?? "";                 //{ return _title ?? ""; }   
            set => _notes = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private string _notes;


        /// <summary>Determines if the contact is a favorite.</summary>
        public bool IsFavorite { get; set; }

        public override string ToString ()
        {
            return $"{LastName}, {FirstName} ({Email})";
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

        public bool IsValidEmail ( string source )
        {
            return MailAddress.TryCreate(source, out var address);
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            /*
            var errors = new List<ValidationResult>();

            bool IsValidEmail ( string source )
            {
                return MailAddress.TryCreate(source, out var address);
            }

            if (LastName.Length == 0)
                errors.Add(new ValidationResult("Title is required", new[] { nameof(LastName) }));

            if (Email.Length == 0)
                errors.Add(new ValidationResult("Email is required", new[] { nameof(Email) }));

            if (IsValidEmail(Email) == false)
                errors.Add(new ValidationResult("Email is not valid", new[] { nameof(Email) }));
            
            if (IsFavorite != true && IsFavorite != false)
                errors.Add(new ValidationResult("If contact is favorite is required", new[] { nameof(IsFavorite) }));

            return errors;
            */

            if(String.IsNullOrEmpty(LastName))
            yield return new ValidationResult("LastName is required.", new[] { nameof(LastName) });

            if (String.IsNullOrEmpty(Email))
                yield return new ValidationResult("Email is required.", new[] { nameof(Email) });
            else if (IsValidEmail(Email) == false)
                yield return new ValidationResult("Email is not properly formatted.", new[] { nameof(Email) });
        }
        


    }
}