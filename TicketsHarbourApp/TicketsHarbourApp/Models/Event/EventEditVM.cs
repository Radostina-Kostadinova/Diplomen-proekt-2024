using System.ComponentModel.DataAnnotations;
using TicketsHarbourApp.Models.Concert;
using TicketsHarbourApp.Models.Location;

namespace TicketsHarbourApp.Models.Event
{
    public class EventEditVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Concert")]
        public int ConcertId { get; set; }
        public virtual List<ConcertPairVM> Concerts { get; set; } = new List<ConcertPairVM>();


        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public virtual List<LocationPairVM> Locations { get; set; } = new List<LocationPairVM>();


        [Required]
        [Display(Name = "Beginning")]
        public DateTime Beginning { get; set; }


        [Range(0, 300)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }



        [Range(0, 5000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        [Range(0, 99)]
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }



    }
}
