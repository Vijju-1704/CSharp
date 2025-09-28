namespace Assignment3
{
    public class BinaryUtils
    {
        //Add two binary numbers (with fractions)
        public static string AddBinaryWithFraction(string a, string b)
        {
            string[] Exponent = a.Split('.');
            string[] Mantissa = b.Split('.');

            string integerA = Exponent[0];
            string fractionA = Exponent.Length > 1 ? Exponent[1] : "";

            string integerB = Mantissa[0];
            string fractionB = Mantissa.Length > 1 ? Mantissa[1] : "";

            // Pad fractional parts
            int maxFractionLength = Math.Max(fractionA.Length, fractionB.Length);
            fractionA = fractionA.PadRight(maxFractionLength, '0');
            fractionB = fractionB.PadRight(maxFractionLength, '0');

            // Add fractional part
            string fractionResult = "";
            int carry = 0;

            for (int i = maxFractionLength - 1; i >= 0; i--)
            {
                int bitA = fractionA[i] - '0';
                int bitB = fractionB[i] - '0';

                int sum = bitA + bitB + carry;
                fractionResult = (sum % 2) + fractionResult;
                carry = sum / 2;
            }

            // Pad integer parts
            int maxIntLength = Math.Max(integerA.Length, integerB.Length);
            integerA = integerA.PadLeft(maxIntLength, '0');
            integerB = integerB.PadLeft(maxIntLength, '0');

            // Add integer part
            string integerResult = "";
            for (int i = maxIntLength - 1; i >= 0; i--)
            {
                int bitA = integerA[i] - '0';
                int bitB = integerB[i] - '0';

                int sum = bitA + bitB + carry;
                integerResult = (sum % 2) + integerResult;
                carry = sum / 2;
            }

            if (carry > 0)
            {
                integerResult = "1" + integerResult;
            }

            // Final result
            if (fractionResult.TrimEnd('0') == "")
                return integerResult;
            else
                return integerResult + "." + fractionResult.TrimEnd('0');
        }

        //Convert binary string to float
        public static double BinaryToFloat(string binary)
        {
            string[] parts = binary.Split('.');
            string integerPart = parts[0];
            string fractionPart = parts.Length > 1 ? parts[1] : "";

            double result = 0;
            int power = 0;

            // integerA part
            for (int i = integerPart.Length - 1; i >= 0; i--)
            {
                if (integerPart[i] == '1')
                    result += Math.Pow(2, power);
                power++;
            }

            // Fractional part
            for (int i = 0; i < fractionPart.Length; i++)
            {
                if (fractionPart[i] == '1')
                    result += Math.Pow(2, -(i + 1));
            }

            return result;
        }

        //Convert float to binary string
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

            string integerBinary = Convert.ToString(integerPart, 2);

            string fractionBinary = "";
            int count = 0;
            while (fractionalPart > 0 && count < fractionBits)
            {
                fractionalPart *= 2;
                if (fractionalPart >= 1)
                {
                    fractionBinary += "1";
                    fractionalPart -= 1;
                }
                else
                {
                    fractionBinary += "0";
                }
                count++;
            }

            string result = (isNegative ? "-" : "") + integerBinary;
            if (fractionBinary != "")
            {
                result += "." + fractionBinary;
            }

            return result;
        }
    }

}
