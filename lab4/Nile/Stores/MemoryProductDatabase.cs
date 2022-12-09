/*
 * ITSE 1430
 */
namespace Nile.Stores
{
    /// <summary>Provides an implementation of <see cref="IProductDatabase"/> using an in-memory collection.</summary>
    public class MemoryProductDatabase : ProductDatabase
    {
        /// <inheritdoc />
        protected override Product AddCore ( Product product )
        {
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            if (newProduct.Id <= 0)
                newProduct.Id = _nextId++;
            else if (newProduct.Id >= _nextId)
                _nextId = newProduct.Id + 1;

            return CopyProduct(newProduct);
        }

        /// <inheritdoc />
        protected override Product GetCore ( int id )
        {
            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : null;
        }

        /// <inheritdoc />
        protected override IEnumerable<Product> GetAllCore ()
        {
            foreach (var product in _products)
                yield return CopyProduct(product);
        }

        /// <inheritdoc />
        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);
        }

        /// <inheritdoc />
        protected override Product UpdateCore ( Product existing, Product product )
        {
            //Replace 
            existing = FindProduct(product.Id);
            _products.Remove(existing);
            
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            return CopyProduct(newProduct);
        }

        #region Private Members

        private Product CopyProduct ( Product product )
        {
            var newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        //Find a product by ID
        private Product FindProduct ( int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
        #endregion
    }
}
