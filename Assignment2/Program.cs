namespace Assignment2
{
        internal class Program
        {
            static void Main(string[] args)
            {
                Class1 c1=new Class1();

                while (true)
                {
                    Console.Write("\nEnter a number (or press 'q' to quit): ");
                    string input = Console.ReadLine();

                    if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }

                    c1.FindMaxProduct(input);
                }
            }
        }
    

}
