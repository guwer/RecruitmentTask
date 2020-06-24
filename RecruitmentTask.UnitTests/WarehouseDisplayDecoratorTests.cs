using RecruitmentTask;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class WarehouseDisplayDecoratorTests
    {
        [Fact]
        public void ToString_ReturnsFormattedWarehouse()
        {
            var warehouse = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "Id1", Quantity = 20 },
                    new StockItem { MaterialId = "Id2", Quantity = 20 },
                }
            };
            var decorator = new WarehouseDisplayDecorator(warehouse, s => new StockItemDisplayDecorator(s));

            var result = decorator.ToString();

            Assert.Equal("WHA (total 40)\r\nId1: 20\r\nId2: 20\r\n", result);
        }
    }
}