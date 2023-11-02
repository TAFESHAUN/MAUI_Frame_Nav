using System;
using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;
using MAUI_Frame_Nav.Model;

namespace MAUI_Frame_Nav.Views
{
    public partial class ProductsDetails : ContentPage
    {
        public ProductsDetails(Products product)
        {
            InitializeComponent();
            BindingContext = new ProductDetailViewModel(product);
        }
    }

    public class ProductDetailViewModel
    {
        public Products Product { get; }

        public ProductDetailViewModel(Products product)
        {
            Product = product;
        }
    }
}
