using System;
using System.Collections.Generic;
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


    }
}
