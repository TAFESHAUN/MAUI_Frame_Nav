using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MAUI_Frame_Nav.Data;
using CommunityToolkit.Mvvm.Messaging;

public class MainPageViewModel : ObservableObject
{
    private ObservableCollection<Products> _products;
    private int result;

    public ObservableCollection<Products> Products
    {
        get { return _products; }
        set { SetProperty(ref _products, value); }
    }

    public ICommand InsertCommand { get; }

    public MainPageViewModel()
    {
        Products = new ObservableCollection<Products>(); // Initialize and populate your product list

        InsertCommand = new RelayCommand(() =>
        {
            // Handle insertion here

            if (result > 0)
            {
                // Insertion successful, notify the main page to refresh
                WeakReferenceMessenger.Default.Send(new RefreshMessage());
            }
        });
    }
}

public class RefreshMessage
{
}
