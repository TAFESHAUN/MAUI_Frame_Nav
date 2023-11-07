using CommunityToolkit.Mvvm.Messaging;
using MAUI_Frame_Nav.Components;
using MAUI_Frame_Nav.Data;
using MAUI_Frame_Nav.Views;

namespace MAUI_Frame_Nav
{
    public partial class MainPage : ContentPage
    {
        private Repository _repo;

        public MainPage()
        {
            InitializeComponent();
            //myFrame.Navigate(new Views.Index(_repo));
            //myFrame.Navigation. -> Seperate Project Move to APP
            //SHELL
        }


        private void Refresh(object recipient, RefreshMessage message)
        {
            // Handle the message, for example, update your product list
            // Refresh your data or update your UI here
            productListView.Refresh();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Subscribe to the RefreshMessage
            //WeakReferenceMessenger.Default.Register<RefreshMessage>(this, Refresh);

            // Refresh the product list when the main page appears
            Refresh();
        }

        private void Refresh()
        {
            // Handle the message, for example, update your product list
            // Refresh your data or update your UI here
            productListView.Refresh();
        }


        private async void Button_Click(object sender, EventArgs e)
        {
            //ADD INSERT COMPONENT + Page view
            await Navigation.PushAsync(new InsertProductView());
        }

    }
}
