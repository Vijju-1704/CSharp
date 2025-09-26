namespace Assignment2
{
    public class MaxProductCalculator
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
                char firstDigitChar = number[i];
                char secondDigitChar = number[i + 1];
                char thirdDigitChar = number[i + 2];
                char fourthtDigitChar = number[i + 3];

                if (char.IsDigit(firstDigitChar) && char.IsDigit(secondDigitChar) && char.IsDigit(thirdDigitChar) && char.IsDigit(fourthtDigitChar))
                {
                    int firstDigit = firstDigitChar - '0';
                    int secondDigit = secondDigitChar - '0';
                    int thirdDigit = thirdDigitChar - '0';
                    int fourthDigit = fourthtDigitChar - '0';

                    int product = firstDigit * secondDigit * thirdDigit * fourthDigit;

                    if (product > maxProduct)
                    {
                        maxProduct = product;
                        maxDigits = $"{firstDigit}*{secondDigit}*{thirdDigit}*{fourthDigit}";
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
