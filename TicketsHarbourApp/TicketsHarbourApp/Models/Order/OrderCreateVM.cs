using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Order
{
    public class OrderCreateVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public string? Picture { get; set; }
       

        [Range(1, 100)]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
