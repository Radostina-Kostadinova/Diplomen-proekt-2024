using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Order
{
    public class OrderDeleteVM
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public string? Picture { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
