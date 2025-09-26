using Xunit;
using Assignment2;

namespace Assignment2Tests
{
    public class Class1Tests
    {
        [Fact]
        public void FindMaxProduct_ValidNumber_ReturnsMaxProduct()
        {
            var c = new Class1();
            var result = c.FindMaxProduct("123456789");
            Assert.Equal("6*7*8*9 = 3024", result);
        }

        [Fact]
        public void FindMaxProduct_LessThan4Digits_ReturnsError()
        {
            var c = new Class1();
            var result = c.FindMaxProduct("123");
            Assert.Equal("Input must have at least 4 digits.", result);
        }

        [Fact]
        public void FindMaxProduct_ContainsNonDigitCharacters_ReturnsValidationMessage()
        {
            var c = new Class1();
            var result = c.FindMaxProduct("12a34b56");
            Assert.Equal("Invalid input. Please enter digits only (0-9).", result);
        }


        [Fact]
        public void FindMaxProduct_AllZeros_ReturnsZeroProduct()
        {
            var c = new Class1();
            var result = c.FindMaxProduct("0000000");
            Assert.Equal("0*0*0*0 = 0", result);
        }

        [Fact]
        public void FindMaxProduct_MultipleMaxSequences_ReturnsFirstMax()
        {
            var c = new Class1();
            var result = c.FindMaxProduct("111199992222");
            Assert.Equal("9*9*9*9 = 6561", result);
        }
    }
}