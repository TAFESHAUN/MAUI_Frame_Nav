using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;
using MAUI_Frame_Nav.Views;

namespace MAUI_Frame_Nav.Components
{
    public partial class ProductDetailsView : ContentView
    {
        private static Products l_Prod;
        public ProductDetailsView()
        {
            InitializeComponent();

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
            var productDeletePage = new DeleteProduct(l_Prod);
            Navigation.PushAsync(productDeletePage);
        }
    }
}
