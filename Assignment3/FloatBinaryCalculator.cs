namespace Assignment3
{
    public class FloatBinaryCalculator
    {
        //Checks for the valid inputs and return true if they are valid or else returns false
        public static bool IsValidFloatInput(string input, out double value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (!double.TryParse(input, out value))
                return false;

            if (value < 0)
                return false;

            return true;
        }
        public static void RunCalculator()
        {
            //Console.WriteLine("=== Float Binary Calculator ===");
            //Console.WriteLine("Press 'q' at any point to exit.\n");

            while (true)
            {
                Console.Write("Enter first float number (or 'q' to quit): ");
                string firstInput = Console.ReadLine().Trim();
                if (firstInput.ToLower() == "q") break;

                Console.Write("Enter second float number (or 'q' to quit): ");
                string secondInput = Console.ReadLine().Trim();
                if (secondInput.ToLower() == "q") break;


                if (!IsValidFloatInput(firstInput, out double firstNumber) || !IsValidFloatInput(secondInput, out double secondNumber))
                {
                    Console.WriteLine("Invalid input. Please enter positive float numbers only.\n");
                    continue;
                }
                // Get binary representations
                string firstBinary = BinaryUtils.FloatToBinaryString(firstNumber);
                string secondBinary = BinaryUtils.FloatToBinaryString(secondNumber);

                // Binary addition as strings
                string binarySum = BinaryUtils.AddBinaryWithFraction(firstBinary, secondBinary);

                // Convert result binary to float
                double floatSum = BinaryUtils.BinaryToFloat(binarySum);

                // Output results
                Console.WriteLine($"\nBinary of {firstNumber} = {firstBinary}");
                Console.WriteLine($"Binary of {secondNumber} = {secondBinary}");
                Console.WriteLine($"Sum in binary       = {binarySum}");
                Console.WriteLine($"Sum in float        = {floatSum}\n");
            }

            //Console.WriteLine("Exited.");
        }
    }
}
