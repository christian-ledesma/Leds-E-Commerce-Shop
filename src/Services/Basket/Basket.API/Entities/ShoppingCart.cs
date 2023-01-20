namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice
        {
            get
            {
                var totalPrice = 0m;
                foreach (var item in Items)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
    }
}
