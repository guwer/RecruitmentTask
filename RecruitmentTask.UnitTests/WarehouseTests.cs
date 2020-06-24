using RecruitmentTask;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class WarehouseTests
    {
        [Fact]
        public void Total_ReturnsSumOfAllItemsQuantities()
        {
            var warehouse = new Warehouse
            {
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 10 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                    new StockItem { MaterialId = "3", Quantity = 30 },
                }
            };

            Assert.Equal(60, warehouse.Total);
        }
    }
}