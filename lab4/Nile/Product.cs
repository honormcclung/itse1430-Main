/*
 * Honor McClung
 * Lab 4
 * ISTE 1430 - Fall 2022 
 * 12/9/2022
 */

using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    public class Product : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            /*
            var errors = new List<ValidationResult>();

            if (Id < 0)
                errors.Add(new ValidationResult("Id must be greater than or equal to zero.", new[] { nameof(Id) }));
            if (Price < 0)
                errors.Add(new ValidationResult("Price must be greater than or equal to zero.", new[] { nameof(Id) }));
            if (string.IsNullOrEmpty(Name))
                errors.Add(new ValidationResult("LastName is required.", new[] { nameof(Name) }));

            return errors;
            */
          

            if (Id < 0)
                yield return new ValidationResult("Id must be greater than or equal to zero.", new[] { nameof(Id) });
            if (Price < 0)
                yield return new ValidationResult("Price must be greater than or equal to zero.", new[] { nameof(Id) });
            if (string.IsNullOrEmpty(Name))
                yield return new ValidationResult("LastName is required.", new[] { nameof(Name) });
            
        }

        #region Private Members

        private string _name;
        private string _description;
        #endregion
    }
}
