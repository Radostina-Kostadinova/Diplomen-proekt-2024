using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Statistic
{
    public class StatisticVM
    {
        [Display(Name = "Count Clients")]
        public int CountClients { get; set; }
        [Display(Name = "Count Events")]
        public int CountEvents { get; set; }
        [Display(Name = "Count Orders")]
        public int CountOrders { get; set; }
        [Display(Name = "Total Sum Orders")]
        public decimal SumOrders { get; set; }
    }
}
