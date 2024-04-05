using Microsoft.AspNetCore.Mvc;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Models.Statistic;

namespace TicketsHarbourApp.Controllers
{
    public class StatisticController:Controller
    {
        private readonly IStatisticService statisticsService;

        public StatisticController(IStatisticService statisticsService)
        {
            this.statisticsService = statisticsService;
        }
        public IActionResult Index()
        {
            StatisticVM statistics = new StatisticVM();

            statistics.CountClients = statisticsService.CountClients();
            statistics.CountEvents = statisticsService.CountEvents();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = statisticsService.SumOrders();

            return View(statistics);

        }
    }
}
