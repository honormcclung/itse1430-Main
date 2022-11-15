using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Honor.ContactManager
{
    public class Contact : IValidatableObject
    {
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
        public Contact ( string firstName, string lastName, string email, string notes, bool isFavorite) : base() 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Notes = notes;
            IsFavorite = isFavorite;
        }

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        public string FirstName
        {
            //Expression body            
            get => _firstName ?? "";                 //{ return _title ?? ""; }   
            set => _firstName = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private String _firstName;

        /// <summary>Gets or sets the last name.</summary>
        public string LastName
        {
            //Expression body            
            get => _lastName ?? "";                 //{ return _title ?? ""; }   
            set => _lastName = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private String _lastName;

        /// <summary>Gets or sets the email.</summary>
        public string Email
        {
            //Expression body            
            get => _email ?? "";                 //{ return _title ?? ""; }   
            set => _email = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private String _email;

        /// <summary>Gets or sets the contact notes.</summary>
        public string Notes
        {
            //Expression body            
            get => _notes ?? "";                 //{ return _title ?? ""; }   
            set => _notes = value?.Trim() ?? ""; //{ _title = value?.Trim() ?? ""; }
        }
        private String _notes;


        /// <summary>Determines if the contact is a favorite.</summary>
        public bool IsFavorite { get; set; }

        public override string ToString () => LastName; //{ return Title; }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
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
        }


    }
}