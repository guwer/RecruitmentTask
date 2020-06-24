using RecruitmentTask;
using Xunit;

namespace UnitTests
{
    public class StockItemComparerTests
    {
        [Fact]
        public void Compare_ReturnsLessThanZero_IfFirstItemMaterialIdIsLessThenSecondItemMaterialId()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem { MaterialId = "A" };
            var stockItem2 = new StockItem { MaterialId = "B" };

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.True(result < 0);
        }

        [Fact]
        public void Compare_ReturnsGreaterThanZero_IfFirstItemMaterialIdIsGreaterThenSecondItemMaterialId()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem { MaterialId = "B" };
            var stockItem2 = new StockItem { MaterialId = "A" };

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.True(result > 0);
        }

        [Fact]
        public void Compare_ReturnsZero_IfFirstItemMaterialIdIsEqualToSecondItemMaterialId()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem { MaterialId = "A" };
            var stockItem2 = new StockItem { MaterialId = "A" };

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Compare_ReturnsLessThanZero_IfFirstItemIsNull()
        {
            var comparer = new StockItemComparer();
            var stockItem2 = new StockItem { MaterialId = "A" };

            var result = comparer.Compare(null, stockItem2);

            Assert.True(result < 0); ;
        }

        [Fact]
        public void Compare_ReturnsLessThanZero_IfFirstItemMaterialIdIsNull()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem();
            var stockItem2 = new StockItem { MaterialId = "A" };

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.True(result < 0); ;
        }

        [Fact]
        public void Compare_ReturnsGreaterThanZero_IfSecondItemIsNull()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem { MaterialId = "A" };

            var result = comparer.Compare(stockItem1, null);

            Assert.True(result > 0); ;
        }

        [Fact]
        public void Compare_ReturnsGreaterThanZero_IfSecondItemMaterialIdIsNull()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem { MaterialId = "A" };
            var stockItem2 = new StockItem();

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.True(result > 0); ;
        }

        [Fact]
        public void Compare_ReturnsZero_IfFirstAndSecondItemIsNull()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem();
            var stockItem2 = new StockItem();

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.Equal(0, result); ;
        }

        [Fact]
        public void Compare_ReturnsZero_IfFirstAndSecondItemMaterialIdIsNull()
        {
            var comparer = new StockItemComparer();
            var stockItem1 = new StockItem();
            var stockItem2 = new StockItem();

            var result = comparer.Compare(stockItem1, stockItem2);

            Assert.Equal(0, result); ;
        }
    }
}