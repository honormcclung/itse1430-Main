namespace Honor.ContactManager
{
    public class Contact
    {

        /// <summary>Initializes an instance of the <see cref="Contact"/> class.</summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public Contact ( string firstName, string lastName, string email, string notes, bool isFavorite) : base() 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Notes = notes;
            IsFavorite = isFavorite;
        }


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


    }
}