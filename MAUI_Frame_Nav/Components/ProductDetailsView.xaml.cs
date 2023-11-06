using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;
using MAUI_Frame_Nav.Views;

namespace MAUI_Frame_Nav.Components
{
    public partial class ProductDetailsView : ContentView
    {
        //private Repository _repository;
        private static Products l_Prod;
        public ProductDetailsView()
        {
            InitializeComponent();
            //_repository = new Repository();

        }

        public static readonly BindableProperty ProductProperty =
            BindableProperty.Create(nameof(Product), typeof(Products), typeof(ProductDetailsView), null, propertyChanged: OnProductChanged);

        public Products Product
        {
            get { return (Products)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        private static void OnProductChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue is Products product)
            {
                var view = (ProductDetailsView)bindable;
                l_Prod = view.Product;
                // Update the labels with the product details
                view.ProductIdLabel.Text = product.Id.ToString();
                view.ProductNameLabel.Text = product.Product;
                view.ProductPriceLabel.Text = $"Price: {product.Price:C}";
                view.ProductCodeLabel.Text = product.Code;
            }
        }

        private void Button_Clicked_Update(object sender, EventArgs e)
        {
            var productUpdatePage = new UpdateProduct(l_Prod);
            Navigation.PushAsync(productUpdatePage);
        }

        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            //App.Current.MainPage.DisplayAlert($"Delete {l_Prod.Id}", $"Deleting {l_Prod.Product}", "OK");
            //int result = _repository.DeleteProduct(l_Prod);

            //if (result > 0)
            //{
            //    // Deletion successful, you can show a success message or update the product list.
            //    Navigation.PopToRootAsync();
            //}
            //else
            //{
            //    // Deletion failed, handle the error.
            //    App.Current.MainPage.DisplayAlert("Delete Failed", "Delete Failed to Delete from Database", "ok");
            //}
            var productDeletePage = new DeleteProduct(l_Prod);
            Navigation.PushAsync(productDeletePage);
        }
    }
}
