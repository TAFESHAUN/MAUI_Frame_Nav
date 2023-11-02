using MAUI_Frame_Nav.Data;

namespace MAUI_Frame_Nav.Views
{
    public partial class DeleteProduct : ContentPage
    {
        private Repository _repository;

        public DeleteProduct(Products sentProduct)
        {
            InitializeComponent();
            _repository = new Repository();
            ProductIdEntry.Text = sentProduct.Id.ToString();
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
                Navigation.PopToRootAsync();
            }
            else
            {
                // Deletion failed, handle the error.
                DisplayAlert("Delete Failed", "Delete Failed to Delete from Database", "ok");
            }
        }
    }
}
