using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MAUI_Frame_Nav.ViewModels
{
    public class ProductDetailsViewModel : ObservableObject
    {
        private Products _product;

        public Products Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }
        public ProductDetailsViewModel()
        {

        }

        //public ICommand UpdateCommand { get; }
        //public ICommand DeleteCommand { get; }

        //private bool _isUpdateMode;
        //public bool IsUpdateMode
        //{
        //    get { return _isUpdateMode; }
        //    set { SetProperty(ref _isUpdateMode, value); }
        //}

        //private bool _isDeleteMode;
        //public bool IsDeleteMode
        //{
        //    get { return _isDeleteMode; }
        //    set { SetProperty(ref _isDeleteMode, value); }
        //}

        //public ProductDetailsViewModel()
        //{
        //    IsUpdateMode = true; // Set the default mode to Update

        //    // Initialize the commands with methods
        //    UpdateCommand = new AsyncRelayCommand(OnUpdateClickedAsync);
        //    DeleteCommand = new AsyncRelayCommand(OnDeleteClickedAsync);
        //}

        //// Handle the Update button click
        //private async Task OnUpdateClickedAsync()
        //{
        //    // Implement your update logic here

        //    // After updating, switch back to Update mode
        //    SwitchToUpdateMode();
        //    await App.Current.MainPage.DisplayAlert("SwitchMode", "Update Swap", "Ok");

        //}

        //// Handle the Delete button click
        //private async Task OnDeleteClickedAsync()
        //{
        //    // Implement your delete logic here

        //    // After deleting, switch back to Update mode or handle navigation
        //    SwitchToUpdateMode(); // You can switch to Update mode or navigate back, for example
        //    await App.Current.MainPage.DisplayAlert("SwitchMode", "Delete Swap", "Ok");
        //}

        //// Switch to Update mode
        //private void SwitchToUpdateMode()
        //{
        //    IsUpdateMode = true;
        //    IsDeleteMode = false;
        //}
    }
}
