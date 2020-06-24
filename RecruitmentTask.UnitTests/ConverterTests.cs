using RecruitmentTask;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ConverterTests
    {
        private Converter converter;

        public ConverterTests()
        {
            converter = new Converter(new WarehouseComparer(), new StockItemComparer());
        }

        [Fact]
        public void Convert_ReturnsWarehousesInProperOrder()
        {
            var records = new List<InputLine>
            {
                new InputLine
                {
                    MaterialId = "Id1", MaterialName = "Name1",
                    QuantitiesPerWarehouse = new Dictionary<string, int>
                    {
                        { "WHA", 5 },
                        { "WHB", 2 }
                    }
                },
                new InputLine
                {
                    MaterialId = "Id2", MaterialName = "Name2",
                    QuantitiesPerWarehouse = new Dictionary<string, int>
                    {
                        { "WHA", 7 },
                        { "WHC", 9 }
                    }
                },
                new InputLine
                {
                    MaterialId = "Id3", MaterialName = "Name3",
                    QuantitiesPerWarehouse = new Dictionary<string, int>
                    {
                        { "WHC", 2 },
                        { "WHD", 12 }
                    }
                }
            };

            var result = converter.Convert(records);

            Assert.Collection(result,
                item => Assert.Equal("WHD", item.WarehouseName),
                item => Assert.Equal("WHA", item.WarehouseName),
                item => Assert.Equal("WHC", item.WarehouseName),
                item => Assert.Equal("WHB", item.WarehouseName));
        }
    }
}