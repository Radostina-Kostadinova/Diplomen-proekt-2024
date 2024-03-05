using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Contact
{
    public class ContactIndexVM
    {

        public int Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Display(Name = "Names")]

        public string Names { get; set; } = null!;

        [Display(Name = "Message")]
        public string Message { get; set; } = null!;



    }
}
