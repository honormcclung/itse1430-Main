namespace Honor.ContactManager
{
    public static class ContactDatabaseExtensions
    {
        // Extension method requirements
        //  1. public/internal static class
        //  2. public/internal static method
        //  3. First parameter must be the extended type
        //  4. First parameter must be proceeded by this
        public static void Seed ( this IContactDatabase database )
        {
            List<Contact> contactList = new List<Contact> {
                new Contact {
                    FirstName = "Braxton",
                    LastName = "Roberts",
                    Email = "slimeypenguin@hotmail.com",
                    Notes = "test",
                    IsFavorite = true
                },
                new Contact {
                    FirstName = "Neomi",
                    LastName = "Lamar",
                    Email = "neomi.castro@gmail.com",
                    Notes = "test2",
                    IsFavorite = false
                },
                new Contact {
                    FirstName = "Kendrick",
                    LastName = "King",
                    Email = "kk@gmail.com",
                    Notes = "test3",
                    IsFavorite = false
                },
                new Contact {
                    FirstName = "michael",
                    LastName = "myers",
                    Email = "mm@portfoliopatterns.com",
                }
            };
            foreach (var contact in contactList)
                database.Add(contact, out var error);
        }
    }
}
