using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Infrastructure.Data.Domain
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;


        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;


        [Required]
        public DateTime OrderDate { get; set; }

        [Range(1, 10)]
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return this.Quantity * this.Price - this.Quantity *
                this.Price * this.Discount / 100;
            }
        }

    }
}
