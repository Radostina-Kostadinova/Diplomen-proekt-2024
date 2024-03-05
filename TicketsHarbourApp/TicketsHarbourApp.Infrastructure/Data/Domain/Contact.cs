using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Infrastructure.Data.Domain
{
    public class Contact
    {
        public int Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Names { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;


       


    }
}
