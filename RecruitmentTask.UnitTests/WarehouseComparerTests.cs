using RecruitmentTask;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class WarehouseComparerTests
    {
        [Fact]
        public void Compare_ReturnsGreaterThanZero_IfFirstWarehouseTotalIsLessThenSecondWarehouseTotal()
        {
            var comparer = new WarehouseComparer();
            var warehouse1 = new Warehouse
            {
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 10 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };
            var warehouse2 = new Warehouse
            {
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 30 },
                }
            };

            var result = comparer.Compare(warehouse1, warehouse2);

            Assert.True(result > 0);
        }

        [Fact]
        public void Compare_ReturnsLessThanZero_IfFirstWarehouseTotalIsGreaterThenSecondWarehouseTotal()
        {
            var comparer = new WarehouseComparer();
            var warehouse1 = new Warehouse
            {
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };
            var warehouse2 = new Warehouse
            {
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 10 },
                    new StockItem { MaterialId = "2", Quantity = 10 },
                }
            };

            var result = comparer.Compare(warehouse1, warehouse2);

            Assert.True(result < 0);
        }

        [Fact]
        public void Compare_ReturnsGreaterThanZero_IfTotalsAreEqualAndFirstWarehouseNameIsLessThenSecondWarehouseName()
        {
            var comparer = new WarehouseComparer();
            var warehouse1 = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };
            var warehouse2 = new Warehouse
            {
                WarehouseName = "WHB",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };

            var result = comparer.Compare(warehouse1, warehouse2);

            Assert.True(result > 0);
        }

        [Fact]
        public void Compare_ReturnsLessThanZero_IfTotalsAreEqualAndFirstWarehouseNameIsGreaterThenSecondWarehouseName()
        {
            var comparer = new WarehouseComparer();
            var warehouse1 = new Warehouse
            {
                WarehouseName = "WHB",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };
            var warehouse2 = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };

            var result = comparer.Compare(warehouse1, warehouse2);

            Assert.True(result < 0);
        }

        [Fact]
        public void Compare_ReturnsZero_IfTotalsAreEqualAndFirstWarehouseNameIsEqualToSecondWarehouseName()
        {
            var comparer = new WarehouseComparer();
            var warehouse1 = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };
            var warehouse2 = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };

            var result = comparer.Compare(warehouse1, warehouse2);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Compare_ReturnsZero_IfFirstWarehouseAndSecondWarehouseIsNull()
        {
            var comparer = new WarehouseComparer();

            var result = comparer.Compare(null, null);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Compare_ReturnsLessThanZero_IfFirstWarehouseIsNull()
        {
            var comparer = new WarehouseComparer();
            var warehouse2 = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };

            var result = comparer.Compare(null, warehouse2);

            Assert.True(result < 0);
        }

        [Fact]
        public void Compare_ReturnsGreaterThanZero_IfSecondWarehouseIsNull()
        {
            var comparer = new WarehouseComparer();
            var warehouse1 = new Warehouse
            {
                WarehouseName = "WHA",
                Stock = new SortedSet<StockItem>(new StockItemComparer())
                {
                    new StockItem { MaterialId = "1", Quantity = 20 },
                    new StockItem { MaterialId = "2", Quantity = 20 },
                }
            };

            var result = comparer.Compare(warehouse1, null);

            Assert.True(result > 0);
        }
    }
}