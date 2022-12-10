/*
 * Honor McClung
 * Lab 4
 * ISTE 1430 - Fall 2022 
 * 12/9/2022
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

            if (product.Name == null)
                throw new ArgumentNullException(nameof(product));

            ObjectValidator.Validate(product);

            var existing = GetAll().FirstOrDefault(
                        x => String.Equals(x.Name, product.Name, StringComparison.OrdinalIgnoreCase));
            
            if (existing != null && existing.Id != product.Id)
                throw new InvalidOperationException("Product name must be unique.");
            
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

            var productExists = GetAll().FirstOrDefault(
                        x => String.Equals(x.Name, product.Name, StringComparison.OrdinalIgnoreCase));

            if (productExists != null && productExists.Id != product.Id)
                throw new InvalidOperationException("Product name must be unique.");

            ObjectValidator.Validate(product);

            var existing = GetCore(product.Id);

            return UpdateCore(existing, product);
        }

        #region Protected Members

        /// <summary>Gets a product by ID.</summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product, if any.</returns>
        protected abstract Product GetCore( int id );

        /// <summary>Gets all products.</summary>
        /// <returns>The list of products.</returns>
        protected abstract IEnumerable<Product> GetAllCore();

        /// <summary>Removes a product given its ID.</summary>
        /// <param name="id">The product ID.</param>
        protected abstract void RemoveCore( int id );

        /// <summary>Updates an existing product.</summary>
        /// <param name="id">The product ID.</param>
        /// <param name="contact">The product details.</param>
        protected abstract Product UpdateCore( Product existing, Product newItem );

        /// <summary>Adds a product to the database.</summary>
        /// <param name="id">The product to add.</param>
        /// <returns>The new product.</returns>
        protected abstract Product AddCore( Product product );
        #endregion
    }
}
