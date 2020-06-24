using RecruitmentTask;
using Xunit;

namespace UnitTests
{
    public class InputParserTests
    {
        private InputParser parser;

        public InputParserTests()
        {
            var configuration = new InputParserConfiguration();
            parser = new InputParser(configuration);
        }

        [Fact]
        public void ParseLine_ReturnsInputLineType()
        {
            var result = parser.ParseLine("name;id;wh,1");

            Assert.IsType<InputLine>(result);
        }

        [Fact]
        public void ParseLine_ReturnsInputLineData_IfInputLineProperlyFormatted()
        {
            var result = parser.ParseLine("name;id;wha,1|whb,5");

            Assert.Equal("name", result.MaterialName);
            Assert.Equal("id", result.MaterialId);
            Assert.Collection(result.QuantitiesPerWarehouse, 
                item =>
                {
                    Assert.Equal("wha", item.Key);
                    Assert.Equal(1, item.Value);
                },
                item =>
                {
                    Assert.Equal("whb", item.Key);
                    Assert.Equal(5, item.Value);
                });
        }
    }
}