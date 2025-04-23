namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Интерфейс для репозитория заказа
    /// </summary>
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
    }
}
