namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Детали заказа
    /// </summary>
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int MedicamentId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Medicament Medicament { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
