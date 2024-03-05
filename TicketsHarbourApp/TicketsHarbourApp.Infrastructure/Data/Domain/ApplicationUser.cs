using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Infrastructure.Data.Domain
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; } = null!;


        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Address { get; set; } = null!;

        public virtual IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
