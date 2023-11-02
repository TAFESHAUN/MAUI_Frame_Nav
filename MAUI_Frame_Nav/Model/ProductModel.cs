namespace MAUI_Frame_Nav.Model
{
    /// <summary>
    /// Model the ALL raw data ABOUT products to our applictions framework such as DEVOPS etc.
    /// One size fits all solution FOR DATA
    /// </summary>
    public class ProductModel
    {
        //Products
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }

        //Promotionals
        //DONT NEED THESE
        //public string ProductCatalougeMonth { get; set; }
        //public string ProductCurrentPromotion { get; set; }

        //NEED THESE
        public string IsDeal { get; set; } //10OFF -> flick or set our bool

        //Check current checkouts and purchases

        //API REFS => TODO with operations
    }
}
