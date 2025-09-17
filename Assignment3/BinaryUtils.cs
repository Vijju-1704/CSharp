namespace Assignment3
{
    class BinaryUtils
    {
        // 1. Add two binary numbers (with fractions)
        public static string AddBinaryWithFraction(string a, string b)
        {
            string[] partsA = a.Split('.');
            string[] partsB = b.Split('.');

            string intA = partsA[0];
            string fracA = partsA.Length > 1 ? partsA[1] : "";

            string intB = partsB[0];
            string fracB = partsB.Length > 1 ? partsB[1] : "";

            // Pad fractional parts
            int maxFracLength = Math.Max(fracA.Length, fracB.Length);
            fracA = fracA.PadRight(maxFracLength, '0');
            fracB = fracB.PadRight(maxFracLength, '0');

            // Add fractional part
            string fracResult = "";
            int carry = 0;

            for (int i = maxFracLength - 1; i >= 0; i--)
            {
                int bitA = fracA[i] - '0';
                int bitB = fracB[i] - '0';

                int sum = bitA + bitB + carry;
                fracResult = (sum % 2) + fracResult;
                carry = sum / 2;
            }

            // Pad integer parts
            int maxIntLength = Math.Max(intA.Length, intB.Length);
            intA = intA.PadLeft(maxIntLength, '0');
            intB = intB.PadLeft(maxIntLength, '0');

            // Add integer part
            string intResult = "";
            for (int i = maxIntLength - 1; i >= 0; i--)
            {
                int bitA = intA[i] - '0';
                int bitB = intB[i] - '0';

                int sum = bitA + bitB + carry;
                intResult = (sum % 2) + intResult;
                carry = sum / 2;
            }

            if (carry > 0)
            {
                intResult = "1" + intResult;
            }

            // Final result
            if (fracResult.TrimEnd('0') == "")
                return intResult;
            else
                return intResult + "." + fracResult.TrimEnd('0');
        }

        // 2. Convert binary string (e.g. "101.0101") to float/double
        public static double BinaryToFloat(string binary)
        {
            string[] parts = binary.Split('.');
            string intPart = parts[0];
            string fracPart = parts.Length > 1 ? parts[1] : "";

            double result = 0;
            int power = 0;

            // Integer part
            for (int i = intPart.Length - 1; i >= 0; i--)
            {
                if (intPart[i] == '1')
                    result += Math.Pow(2, power);
                power++;
            }

            // Fractional part
            for (int i = 0; i < fracPart.Length; i++)
            {
                if (fracPart[i] == '1')
                    result += Math.Pow(2, -(i + 1));
            }

            return result;
        }

        // 3. Convert float/double to binary string
        public static string FloatToBinaryString(double num, int fractionBits = 23)
        {
            bool isNegative = false;
            if (num < 0)
            {
                isNegative = true;
                num = -num;
            }

            long integerPart = (long)Math.Floor(num);
            double fractionalPart = num - integerPart;

            string intBinary = Convert.ToString(integerPart, 2);

            string fracBinary = "";
            int count = 0;
            while (fractionalPart > 0 && count < fractionBits)
            {
                fractionalPart *= 2;
                if (fractionalPart >= 1)
                {
                    fracBinary += "1";
                    fractionalPart -= 1;
                }
                else
                {
                    fracBinary += "0";
                }
                count++;
            }

            string result = (isNegative ? "-" : "") + intBinary;
            if (fracBinary != "")
            {
                result += "." + fracBinary;
            }

            return result;
        }
    }

}
