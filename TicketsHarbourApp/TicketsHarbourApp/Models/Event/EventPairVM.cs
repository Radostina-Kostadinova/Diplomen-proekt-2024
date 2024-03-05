using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Event
{
    public class EventPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Event")]
        public string Name { get; set; } = null!;


    }
}
