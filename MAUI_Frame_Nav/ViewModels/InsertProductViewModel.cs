using System;
using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI_Frame_Nav.ViewModels
{
    public class InsertProductViewModel : ObservableObject
    {
        private Repository _repository;

        public InsertProductViewModel()
        {
            _repository = new Repository();
            InsertCommand = new Command(ExecuteInsert);
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        private double _price;
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        public Command InsertCommand { get; }

        private async void ExecuteInsert()
        {
            Products newProduct = new Products
            {
                Product = ProductName,
                Price = Price,
                Code = Code
            };

            int result = _repository.InsertProduct(newProduct);

            if (result > 0)
            {
                // Insertion successful, you can show a success message.
                await App.Current.MainPage.DisplayAlert("Success", "Insert success", "Ok");

                // Use PopAsync to navigate back
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                // Insertion failed, handle the error.
                await App.Current.MainPage.DisplayAlert("Failed", "Insertion failed", "Ok");
            }
        }
    }
}
