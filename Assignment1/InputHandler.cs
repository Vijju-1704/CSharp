using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class InputHandler
    {
        public static void ProcessInput()
        {
                StringSearcher c1 = new StringSearcher();
                while (true)
                {
                    Console.Write("Enter the main string (S1): ");
                    string mainString = Console.ReadLine();

                    Console.Write("Enter the substring to find (S2): ");
                    string substring = Console.ReadLine();

                    if (string.IsNullOrEmpty(mainString) || string.IsNullOrEmpty(substring))
                    {
                        Console.WriteLine("Both strings must be non-empty. Try again.");
                        continue;
                    }
                    List<int> indexPositions = c1.FindAllIndexes(mainString, substring);

                    Console.WriteLine("No. of times occurred = " + indexPositions.Count);
                    Console.Write("Index positions = ");
                    foreach (int position in indexPositions)
                    {
                        Console.Write(position + " ");
                    }
                    Console.WriteLine();

                    Console.Write("\nPress 'q' to quit or any other key to continue: ");
                    var key = Console.ReadKey().KeyChar;
                    if (key == 'q' || key == 'Q')
                    {
                        Console.WriteLine("\nExiting the program.");
                        break;
                    }
                    Console.WriteLine();
                }
        }
    }
}
