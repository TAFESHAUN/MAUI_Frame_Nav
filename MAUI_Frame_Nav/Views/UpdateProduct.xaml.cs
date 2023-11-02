using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;

namespace MAUI_Frame_Nav.Views
{
    public partial class UpdateProduct : ContentPage
    {
        private Repository _repository;

        public UpdateProduct(Products sentProduct)
        {
            InitializeComponent();
            _repository = new Repository();
            ProductIdEntry.Text = sentProduct.Id.ToString();
            ProductNameEntry.Text = sentProduct.Product;
            PriceEntry.Text = sentProduct?.Price.ToString();
            CodeEntry.Text = sentProduct?.Code.ToString();
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ProductIdEntry.Text);
            string productName = ProductNameEntry.Text;
            double price = Convert.ToDouble(PriceEntry.Text);
            string code = CodeEntry.Text;

            Products updatedProduct = new Products
            {
                Id = productId,
                Product = productName,
                Price = price,
                Code = code
            };

            int result = _repository.UpdateProduct(updatedProduct);

            if (result > 0)
            {
                // Update successful, you can show a success message or update the product list.
                Navigation.PopToRootAsync();
            }
            else
            {
                // Update failed, handle the error.
                DisplayAlert("Update Failed", "Update Failed to Update Database", "ok");
            }
        }
    }
}
