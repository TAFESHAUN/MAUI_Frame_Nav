using MAUI_Frame_Nav.Data;

namespace MAUI_Frame_Nav.Views
{
    //CHANGE OR ADD CONTENT VIEW ON THIS PAGE
    //IF I didn't want the component/custom UI
    //I can just set the viewmodel now
    public partial class DeleteProduct : ContentPage
    {
        private Repository _repository;

        public DeleteProduct(Products sentProduct)
        {
            InitializeComponent();
            _repository = new Repository();
            ProductId.Text = sentProduct.Id.ToString();
            ProductName.Text = sentProduct.Product.ToString();
            Price.Text = sentProduct.Price.ToString();
            Code.Text = sentProduct.Code.ToString();    
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ProductId.Text);

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
