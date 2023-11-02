using System;
using System.Collections.Generic;
using System.ComponentModel;
using MAUI_Frame_Nav.Data;
using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Views;
using System.Windows.Input;
using MAUI_Frame_Nav.Model;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

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
            LoadProducts(); // Load Products when the view is created.
            RefreshCommand = new Command(Refresh);
        }

        public ICommand RefreshCommand { get; private set; }

        public void Refresh()
        {
            // Call the repository to refresh the product list
            //Iterate over MY RAW data set -> Products
            //ADD the VALUES of the RAW data set into my Products
            var updatedProducts = _repository.GetProduct();//Fix this From Explicit for better memory usage
            //Update the Products collection with the refreshed data
            ProductsList = updatedProducts;


        }

        private IEnumerable<Products> _ProductsList;
        public IEnumerable<Products> ProductsList
        {
            get { return _ProductsList; }
            set
            {
                _ProductsList = value;
                OnPropertyChanged(nameof(ProductsList));
            }
        }

        private void LoadProducts()
        {
            ProductsList = _repository.GetProduct();

            //List<Products> rawProdcuts = (List<Products>)_repository.GetProduct();
            //List of Promotional RAW table date => Products
            //List of Return Customer Codes => Code to Our customer => Products
            //List<Products> products = new List<Products>();


            //for(int i = 0; i < rawProdcuts.Count; i++)
            //{
            //    Products tempProdModel = new Products();
            //    tempProdModel.Id = rawProdcuts[i].Id;
            //    tempProdModel.ProductName = rawProdcuts[i].Product;
            //    tempProdModel.Price = rawProdcuts[i].Price;
            //    tempProdModel.Code = rawProdcuts[i].Code;
            //    //THIS WOULD BE DYNMAIC LATER
            //    if(tempProdModel.Price > 100.00)
            //    {
            //        tempProdModel.IsDeal = "10OFF"; //Add this elsewhere
            //    }
            //    else
            //    {
            //        tempProdModel.IsDeal = "NODEAL"; //Add this elsewhere
            //    }
            //    products.Add(tempProdModel);
            //}
            
            //ProductsList = products;
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
