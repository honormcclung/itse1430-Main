/*
 * ITSE 1430
 */
namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        {
            //TODO: Check arguments

            //TODO: Validate product
            //var errors = product.Validate();

            //Validate movie
            if (product.Name == null)
                throw new ArgumentNullException(nameof(product));

            //Use IValidatableObject Luke...
            ObjectValidator.Validate(product);

            
            //Must be unique
            var existing = GetAll().FirstOrDefault(
                        x => String.Equals(x.Name, product.Name, StringComparison.OrdinalIgnoreCase));
            
            if (existing != null && existing.Id != product.Id)
                throw new InvalidOperationException("Product name must be unique.");
            

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
        }

        /// <inheritdoc />
        public Product Update ( Product product )
        {
            //TODO: Check arguments

            //TODO: Validate product
            if (product.Id < 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "Id must be > 0.");

            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product does not exist.");

            //Must be unique
            var productExists = GetAll().FirstOrDefault(
                        x => String.Equals(x.Name, product.Name, StringComparison.OrdinalIgnoreCase));

            if (productExists != null && productExists.Id != product.Id)
                throw new InvalidOperationException("Product name must be unique.");

            ObjectValidator.Validate(product);

            //Get existing product
            var existing = GetCore(product.Id);

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}
