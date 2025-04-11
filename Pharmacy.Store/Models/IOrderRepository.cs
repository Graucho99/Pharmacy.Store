namespace Pharmacy.Store.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
