using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHarbourApp.Core.Contracts
{
    public interface IStatisticService
    {

        int CountEvents();
        int CountClients();
        int CountOrders();
        decimal SumOrders();



    }
}
