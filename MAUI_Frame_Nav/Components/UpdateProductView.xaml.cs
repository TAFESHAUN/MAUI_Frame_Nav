using Microsoft.Maui.Controls;
using MAUI_Frame_Nav.Data;

namespace MAUI_Frame_Nav.Components
{
    public partial class UpdateProductView : ContentView
    {
        private Repository _repository;

        public UpdateProductView()
        {
            InitializeComponent();
            _repository = new Repository();
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ProductIdEntry.Text);
            string productName = ProductNameEntry.Text;
            double price = Convert.ToDouble(PriceEntry.Text);
            string code = CodeEntry.Text;

            Products updatedProduct = new Products
            {
                Id = productId,
                Product = productName,
                Price = price,
                Code = code
            };

            int result = _repository.UpdateProduct(updatedProduct);

            if (result > 0)
            {
                // Update successful, you can show a success message or update the product list.
            }
            else
            {
                // Update failed, handle the error.
            }
        }
    }
}
