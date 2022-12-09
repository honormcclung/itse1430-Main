using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Honor.ContactManager
{
    public static class ObjectValidator
    {
        public static bool IsValid ( IValidatableObject instance, out string errorMessage )
        {
            //var used = _unused;
            //var that = this;

            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
            {
                errorMessage = results[0].ErrorMessage;
                return false;
            };

            errorMessage = null;
            return true;
        }

        public static void Validate ( IValidatableObject instance )
        {
            Validator.ValidateObject(instance, new ValidationContext(instance), true);
        }
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
