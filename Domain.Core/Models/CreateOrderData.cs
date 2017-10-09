namespace Domain.Core.Models
{
    public class CreateOrderData
    {
        public long ShoppingCartId { get; set; }
        public int ShoppingListItemsCount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}