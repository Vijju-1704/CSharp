using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class InputClass
    {
        public static void InputMethod()
        {
                Class1 c1 = new Class1();
                while (true)
                {
                    Console.Write("Enter the main string (S1): ");
                    string s1 = Console.ReadLine();

                    Console.Write("Enter the substring to find (S2): ");
                    string s2 = Console.ReadLine();

                    if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                    {
                        Console.WriteLine("Both strings must be non-empty. Try again.");
                        continue;
                    }
                    List<int> indexes = c1.FindAllIndexes(s1, s2);

                    Console.WriteLine("No. of times occurred = " + indexes.Count);
                    Console.Write("Index positions = ");
                    foreach (int pos in indexes)
                    {
                        Console.Write(pos + " ");
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
