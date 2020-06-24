using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask
{
    public class Warehouse
    {
        public string WarehouseName { get; set; }

        public int Total
        {
            get  { return Stock.Sum(p => p.Quantity); }
        }

        public SortedSet<StockItem> Stock { get; set; }
    }
}