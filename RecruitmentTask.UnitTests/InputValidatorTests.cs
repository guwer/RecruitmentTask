using RecruitmentTask;
using Xunit;

namespace UnitTests
{
    public class InputValidatorTests
    {
        [Fact]
        public void IsCommentLine_ReturnsTrue_IfLineStartsWithHash()
        {
            var validator = new InputValidator();

            var result = validator.IsCommentLine("# New materials");

            Assert.True(result);
        }

        [Fact]
        public void IsCommentLine_ReturnsFalse_IfLineDoesNotStartWithHash()
        {
            var validator = new InputValidator();

            var result = validator.IsCommentLine("New materials");

            Assert.False(result);
        }

        [Fact]
        public void IsCommentLine_ReturnsFalse_IfLineIsNull()
        {
            var validator = new InputValidator();

            var result = validator.IsCommentLine(null);

            Assert.False(result);
        }
    }
}