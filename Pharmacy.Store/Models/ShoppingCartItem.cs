namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Модель айтема в корзине
    /// </summary>
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Medicament Medicament { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
