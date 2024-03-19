using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Infrastructure.Data.Domain
{
    public class Concert
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ConcertName { get; set; } = null!;


        [Required]
        [MaxLength(200)]
        public string Performers { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;


        [Required]
        public string Picture { get; set; } = null!;


        public virtual IEnumerable<Event> Events { get; set; } = new List<Event>();

    }
}
