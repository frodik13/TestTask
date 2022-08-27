using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var skier1 = new Skier("", 22, 10, 0, 2, 30, 25);
                var skier2 = new Skier("", 22, 10, 30, 2, 25, 33);
                var skier3 = new Skier("", 22, 11, 00, 2, 31, 2);
                skier1.Result();
                Console.WriteLine("=====================================================");
                skier2.Result();
                Console.WriteLine("=====================================================");
                skier3.Result();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
