using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;
using System;

namespace MAUI_Frame_Nav.Views
{
    //CHANGE OR ADD CONTENT VIEW ON THIS PAGE
    public partial class UpdateProduct : ContentPage
    {
        private Repository _repository;

        public UpdateProduct(Products sentProduct)
        {
            InitializeComponent();
            _repository = new Repository();
            ProductIdLabel.Text = sentProduct.Id.ToString();
            ProductNameEntry.Text = sentProduct.Product;
            PriceEntry.Text = sentProduct?.Price.ToString();
            CodeEntry.Text = sentProduct?.Code.ToString();

            // Set event handlers for focused events to set cursor to end of text & trimIt
            ProductNameEntry.Focused += Entry_Focused;
            PriceEntry.Focused += Entry_Focused;
            CodeEntry.Focused += Entry_Focused;
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            var entry = (Entry)sender;
            entry.Text = entry.Text.Trim(); // Trim white space
            entry.CursorPosition = entry.Text.Length; // Set cursor to end of text
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ProductIdLabel.Text);
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
