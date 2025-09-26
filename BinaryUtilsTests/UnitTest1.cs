using Xunit;
using Assignment3;
namespace BinaryUtilsTests
{
    public class BinaryUtilsTests
    {
        // 1.  Binary to Float Conversion
        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("10", 2)]
        [InlineData("101.1", 5.5)]
        [InlineData("110.01", 6.25)]
        [InlineData("0.1", 0.5)]
        [InlineData("0.01", 0.25)]
        [InlineData("11111111.11111111", 255.99609375)]
        public void BinaryToFloat_ShouldConvertCorrectly(string binary, double expected)
        {
            double actual = BinaryUtils.BinaryToFloat(binary);
            Assert.InRange(actual, expected - 0.0001, expected + 0.0001);
        }

        // 2.  Float to Binary Conversion
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "10")]
        [InlineData(5.5, "101.1")]
        [InlineData(0.75, "0.11")]
        [InlineData(4.125, "100.001")]
        [InlineData(255.99609375, "11111111.111111")] // using 6-bit precision
        public void FloatToBinaryString_ShouldConvertCorrectly(double value, string expectedStart)
        {
            string actual = BinaryUtils.FloatToBinaryString(value, 8); // limit fraction bits for comparison
            Assert.StartsWith(expectedStart, actual);
        }

        // 3.  Add Binary Numbers with Fractions
        [Theory]
        [InlineData("101", "11", "1000")]             // 5 + 3 = 8
        [InlineData("10.1", "1.1", "100")]            // 2.5 + 1.5 = 4
        [InlineData("0.1", "0.1", "1")]               // 0.5 + 0.5 = 1
        [InlineData("1.01", "10.1", "11.11")]         // 1.25 + 2.5 = 3.75
        [InlineData("1101.101", "101.011", "10011")]  // 13.625 + 5.375 = 19
        [InlineData("0", "0", "0")]
        public void AddBinaryWithFraction_ShouldAddCorrectly(string a, string b, string expectedSum)
        {
            string actual = BinaryUtils.AddBinaryWithFraction(a, b);
            Assert.Equal(expectedSum, actual);
        }

        // 4.  Float Input Validation
        [Theory]
        //  Valid inputs
        [InlineData("1.33", true)]
        [InlineData("0.13", true)]
        [InlineData("123", true)]
        [InlineData("0", true)]
        [InlineData("1e3", true)]       // scientific notation allowed
        [InlineData("2E2", true)]       // uppercase E allowed
        [InlineData("5.67e-1", true)]   // valid small float

        //  Invalid inputs
        [InlineData("-5", false)]       // negative number
        [InlineData("-0.1", false)]     // negative decimal
        [InlineData("abc", false)]      // letters
        [InlineData("1.2.3", false)]    // malformed
        [InlineData("12-3", false)]     // special characters
        [InlineData("!", false)]        // symbols
        [InlineData("", false)]         // empty
        [InlineData("   ", false)]      // whitespace
        [InlineData(null, false)]       // null input
        public void IsValidFloatInput_ShouldValidateInput(string input, bool expectedIsValid)
        {
            bool isValid = NewProgram.IsValidFloatInput(input, out double _);
            Assert.Equal(expectedIsValid, isValid);
        }
    }
}