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
            #region Comment
            //Array/collection initializer syntax
            //var movies = new Movie[3];

            //Object initializer syntax
            //new Movie("Jaws", "PG");
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1977;
            //movie.Description = "Shark eats people";
            //movie.IsClassic = true;
            //movies[0] = new Movie() {
            //    Title = "Jaws",
            //    Rating = "PG",
            //    RunLength = 210,
            //    ReleaseYear = 1977,
            //    Description = "Shark eats people",
            //    IsClassic = true,
            //};            
            //movies[1] = new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG-13",
            //    RunLength = 220,
            //    ReleaseYear = 1979,
            //    Description = "Shark eats people...again"                
            //};
            //movies[2] = new Movie() {
            //            Title = "Dune",
            //            Rating = "PG-13",
            //            RunLength = 320,
            //            ReleaseYear = 1985,
            //            Description = "Based on book",
            //        };
            #endregion
            List<Contact> contactList = new List<Contact> {
                new Contact {
                    FirstName = "Honor",
                    LastName = "McClung",
                    Email = "honor.mae.mcclung@gmail.com",
                    Notes = "test",
                    IsFavorite = true
                },
                new Contact {
                    FirstName = "Neomi",
                    LastName = "Castro",
                    Email = "neomi.castro@gmail.com",
                    Notes = "test2",
                    IsFavorite = false
                }
            };
            foreach (var contact in contactList)
                database.Add(contact, out var error);
        }
    }
}
