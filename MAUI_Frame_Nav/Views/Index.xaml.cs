using MAUI_Frame_Nav.Data;

namespace MAUI_Frame_Nav.Views
{
    public partial class Index : ContentPage
    {
        private Repository _repo;

        public Index(Repository repo)
        {
            _repo = repo;
            InitializeComponent();
            dgProduct.ItemsSource = _repo.GetProduct();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var product = button.Parent.BindingContext as Products;

                if (product != null)
                {
                    switch (button.Text)
                    {
                        case "Edit":
                            //Navigation.PushAsync(new Update(_repo, product));
                            break;
                        case "Delete":
                            //Navigation.PushAsync(new Delete(_repo, product));
                            break;
                    }
                }
            }
        }
    }
}
