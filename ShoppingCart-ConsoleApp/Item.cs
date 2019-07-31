
namespace ShoppingCart_ConsoleApp
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int DiscountType { get; set; }
    }
}
