/*
 * Honor McClung
 * Lab 4
 * ISTE 1430 - Fall 2022 
 * 12/9/2022
 */
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.VisualBasic.Devices;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = true;

            var connString = Program.GetConnectionString("ProductDatabase");
            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");

            //TODO: Handle errors
            //Save product
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                try
                {
                    _database.Add(child.Product);
                    UpdateList();
                    return;
                } catch (InvalidOperationException ex)
                {
                    DisplayError("Products must be unique.", "Add Failed");
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Add Failed");
                };

            } while (true);
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();

            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();

            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //TODO: Handle errors
            //Delete product
            if (product == null)
                throw new InvalidOperationException("Product does not exist.");

            try
            {
                _database.Remove(product.Id);
                UpdateList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed");
            };

            //_database.Remove(product.Id);
            //UpdateList();
        }

        private void EditProduct ( Product product )
        {
            if (product == null)
                throw new InvalidOperationException("Product does not exist.");

            var child = new ProductDetailForm("Product Details");
            child.Product = product;


            //TODO: Handle errors
            //Save product
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    Cursor = Cursors.WaitCursor;
                    _database.Update(child.Product);
                    System.Threading.Thread.Sleep(1000);
                    UpdateList();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Update Failed");
                } finally
                {
                    Cursor = Cursors.Default;
                };
            } while (true);

            //_database.Update(child.Product);
            //UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            //TODO: Handle errors
            try
            {
                //_database
                _bsProducts.DataSource = _database.GetAll().OrderBy(x => x.Name);
                return;
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Update List Failed.");
            }

            //_bsProducts.DataSource = _database.GetAll();
        }       

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private readonly IProductDatabase _database = new Nile.Stores.MemoryProductDatabase();

        #endregion

    }
}
