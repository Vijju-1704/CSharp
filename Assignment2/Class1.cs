namespace Assignment2
{
    public class Class1
    {
        public string FindMaxProduct(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return "Invalid input. Please enter digits only (0-9).";
            }
            if (number.Length < 4)
            {
                return "Input must have at least 4 digits.";
            }

            int maxProduct = -1;
            string maxDigits = "";

            for (int i = 0; i <= number.Length - 4; i++)
            {
                char c1 = number[i];
                char c2 = number[i + 1];
                char c3 = number[i + 2];
                char c4 = number[i + 3];

                if (char.IsDigit(c1) && char.IsDigit(c2) && char.IsDigit(c3) && char.IsDigit(c4))
                {
                    int d1 = c1 - '0';
                    int d2 = c2 - '0';
                    int d3 = c3 - '0';
                    int d4 = c4 - '0';

                    int product = d1 * d2 * d3 * d4;

                    if (product > maxProduct)
                    {
                        maxProduct = product;
                        maxDigits = $"{d1}*{d2}*{d3}*{d4}";
                    }
                }
            }

            if (!string.IsNullOrEmpty(maxDigits))
            {
                return $"{maxDigits} = {maxProduct}";
            }
            else
            {
                return "No valid 4-digit product found.";
            }
        }
    }
}
