using RecruitmentTask;
using Xunit;

namespace UnitTests
{
    public class StockItemDisplayDecoratorTests
    {
        [Fact]
        public void ToString_ReturnsFormatted()
        {
            var stockItem = new StockItem { MaterialId = "Id1", Quantity = 20 };
            var decorator = new StockItemDisplayDecorator(stockItem);

            var result = decorator.ToString();

            Assert.Equal("Id1: 20", result);
        }

    }
}