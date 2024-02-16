using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Location
{
    public class LocationPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; } = null!;


    }
}
