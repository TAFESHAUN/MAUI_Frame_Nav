using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;

namespace MAUI_Frame_Nav.Components
{
    public partial class DeleteProductView : ContentView
    {
        private Repository _repository;

        public DeleteProductView()
        {
            InitializeComponent();
            _repository = new Repository();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ProductIdEntry.Text);

            Products productToDelete = new Products
            {
                Id = productId
            };

            int result = _repository.DeleteProduct(productToDelete);

            if (result > 0)
            {
                // Deletion successful, you can show a success message or update the product list.
            }
            else
            {
                // Deletion failed, handle the error.
            }
        }
    }
}
