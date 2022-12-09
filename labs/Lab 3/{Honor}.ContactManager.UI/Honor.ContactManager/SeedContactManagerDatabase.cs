/*
 * Honor McClung
 * Lab 3
 * ISTE 1430 - Fall 2022 
 * 12/1/2022
 */

namespace Honor.ContactManager
{
    public static class ContactDatabaseExtensions
    {
        /// <summary>Validates an object.</summary>
        /// <typeparam name="IContactDatabase">The type being validated.</typeparam>
        /// <param name="errorMessage">The error message.</param>
        /// <returns><see langword="true"/> if valid or <see langword="false"/> otherwise.</returns>
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
