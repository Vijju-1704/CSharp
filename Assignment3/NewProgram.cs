namespace Assignment3
{
    internal class NewProgram
    {
        static void Main()
        {
            Console.WriteLine("=== Float Binary Calculator ===");
            Console.WriteLine("Press 'q' at any point to exit.\n");

            while (true)
            {
                Console.Write("Enter first float number (or 'q' to quit): ");
                string input1 = Console.ReadLine().Trim();
                if (input1.ToLower() == "q") break;

                Console.Write("Enter second float number (or 'q' to quit): ");
                string input2 = Console.ReadLine().Trim();
                if (input2.ToLower() == "q") break;

                if (!double.TryParse(input1, out double float1) || !double.TryParse(input2, out double float2))
                {
                    Console.WriteLine("Invalid input. Please enter valid float numbers.\n");
                    continue;
                }

                // Get binary representations
                string binary1 = BinaryUtils.FloatToBinaryString(float1);
                string binary2 = BinaryUtils.FloatToBinaryString(float2);

                // Binary addition as strings
                string binarySum = BinaryUtils.AddBinaryWithFraction(binary1, binary2);

                // Convert result binary to float
                double floatSum = BinaryUtils.BinaryToFloat(binarySum);

                // Output results
                Console.WriteLine($"\nBinary of {float1} = {binary1}");
                Console.WriteLine($"Binary of {float2} = {binary2}");
                Console.WriteLine($"Sum in binary       = {binarySum}");
                Console.WriteLine($"Sum in float        = {floatSum}\n");
            }

            Console.WriteLine("Exited.");
        }
    }
}
