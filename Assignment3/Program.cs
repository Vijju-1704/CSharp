namespace Assignment3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Binary Calculator (Type 'q' to quit) ===");

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add two binary numbers");
                Console.WriteLine("2. Convert binary to float");
                Console.WriteLine("3. Convert float to binary");
                Console.WriteLine("q. Quit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine().Trim().ToLower();

                if (choice == "q")
                {
                    Console.WriteLine("Exiting program.");
                    break;
                }

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter first binary number: ");
                        string bin1 = Console.ReadLine().Trim();

                        Console.Write("Enter second binary number: ");
                        string bin2 = Console.ReadLine().Trim();

                        string sum = BinaryUtils.AddBinaryWithFraction(bin1, bin2);
                        Console.WriteLine($"Sum = {sum}");
                        break;

                    case "2":
                        Console.Write("Enter binary number to convert: ");
                        string binaryInput = Console.ReadLine().Trim();

                        double decimalResult = BinaryUtils.BinaryToFloat(binaryInput);
                        Console.WriteLine($"Decimal value = {decimalResult}");
                        break;

                    case "3":
                        Console.Write("Enter a float number: ");
                        if (double.TryParse(Console.ReadLine().Trim(), out double floatInput))
                        {
                            string binaryStr = BinaryUtils.FloatToBinaryString(floatInput);
                            Console.WriteLine($"Binary = {binaryStr}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid float input.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

}
