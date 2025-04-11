namespace Pharmacy.Store.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Medicament medicament);
        int RemoveFromCart(Medicament medicament);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
