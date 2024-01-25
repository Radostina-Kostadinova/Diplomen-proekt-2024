using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Infrastructure.Data.Domain
{
    public class Event
    {
        public int Id { get; set; }


        [ForeignKey("Concert")]
        public int ConcertId { get; set; }
        public virtual Concert Concert { get; set; } = null!;


        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;


        [Required]
        public DateTime Begining { get; set; }

        [Range(0, 300)]
        public decimal Price { get; set; }


        [Range(0, 5000)]
        public int Quantity { get; set; }

        [Range(0, 99)]
        public decimal Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
