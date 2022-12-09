/*
 * Honor McClung
 * Lab 3
 * ISTE 1430 - Fall 2022 
 * 12/1/2022
 */

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Honor.ContactManager
{
    public static class ObjectValidator
    {
        /// <summary>Validates an object.</summary>
        /// <typeparam name="T">The type being validated.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns><see langword="true"/> if valid or <see langword="false"/> otherwise.</returns>
        public static bool TryValidate<T> ( T value, out string errorMessage )
        {
            var results = Validate(value);
            if (results?.Any() ?? false)
            {
                errorMessage = results.FirstOrDefault().ErrorMessage;
                return false;
            };

            errorMessage = null;
            return true;
        }

        /// <summary>Validates an object.</summary>
        /// <typeparam name="T">The type being validated.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The errors, if any.</returns>
        public static IEnumerable<ValidationResult> Validate<T> ( T value )
        {
            if (value == null)
                yield return null;

            var results = new Collection<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), results, true);
            foreach (var result in results)
                yield return result;
        }

    }
}
