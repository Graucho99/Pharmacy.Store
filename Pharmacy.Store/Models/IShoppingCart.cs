namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Интерфейс для репозитория корзины
    /// </summary>
    public interface IShoppingCart
    {
        Task AddToCartAsync(Medicament medicament);
        Task<int> RemoveFromCartAsync(Medicament medicament);
        Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync();
        Task ClearCartAsync();
        Task<decimal> GetShoppingCartTotalAsync();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
