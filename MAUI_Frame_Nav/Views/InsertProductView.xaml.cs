using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.ViewModels;

namespace MAUI_Frame_Nav.Components
{
    public partial class InsertProductView : ContentPage
    {
        public InsertProductView()
        {
            InitializeComponent();

            // Set the ViewModel as the BindingContext
            BindingContext = new InsertProductViewModel();
        }
    }
}
