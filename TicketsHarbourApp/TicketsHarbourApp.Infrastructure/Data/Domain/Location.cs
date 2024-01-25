using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Infrastructure.Data.Domain
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;


        [Required]
        [MinLength(10)]
        public string Town { get; set; } = null!;


        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Address { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();


    }
}
