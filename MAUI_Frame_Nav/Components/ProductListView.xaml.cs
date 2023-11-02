using System;
using System.Collections.Generic;
using System.ComponentModel;
using MAUI_Frame_Nav.Data;
using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Views;
using System.Windows.Input;

namespace MAUI_Frame_Nav.Components
{
    public partial class ProductListView : ContentView, INotifyPropertyChanged
    {
        private Repository _repository;

        public ProductListView()
        {
            InitializeComponent();
            _repository = new Repository();
            BindingContext = this;
            LoadProducts(); // Load products when the view is created.
            RefreshCommand = new Command(Refresh);
        }

        public ICommand RefreshCommand { get; private set; }

        public void Refresh()
        {
            // Call the repository to refresh the product list
            var updatedProducts = _repository.GetProduct();
            // Update the Products collection with the refreshed data
            Products = updatedProducts;
        }



        private IEnumerable<Products> _products;
        public IEnumerable<Products> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private void LoadProducts()
        {
            Products = _repository.GetProduct();
        }

        private void OnViewDetailsClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Products product)
            {
                // Handle the click event, and you can navigate to a new page to display product details.
                var productDetailPage = new ProductsDetails(product);
                Navigation.PushAsync(productDetailPage);
            }
        }
    }
}
