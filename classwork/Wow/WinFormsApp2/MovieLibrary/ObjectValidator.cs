using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    public static class ObjectValidator
    {
        //private ObjectValidator() { }

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

        //private int _unused;
    }
}
