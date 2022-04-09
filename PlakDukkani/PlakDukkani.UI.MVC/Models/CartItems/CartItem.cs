namespace PlakDukkani.UI.MVC.Models.CartItems
{
    public class CartItem   //Ürün
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal 
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
