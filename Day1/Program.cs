using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleOne();

            PuzzleTwo();

            Console.ReadLine();
        }

        static void PuzzleOne()
        {
            var numModules = 0;
            var fuelSum = 0;

            string[] values = File.ReadAllLines("./input.txt");

            foreach(string val in values)
            {
                //int.TryParse(val, out var mass);
                var mass = Convert.ToInt32(val);
                var fuel = (int)Math.Floor((double)mass / 3) - 2;

                //Console.WriteLine("mass: {0} - fuel {1}", mass, fuel);

                fuelSum += fuel;
                numModules++;
            }

            Console.WriteLine("Fuel requirements for {0} modules: {1}", numModules, fuelSum);
        }

        static void PuzzleTwo()
        {
            var numModules = 0;
            var fuelSum = 0;

            string[] values = File.ReadAllLines("./input.txt");

            foreach (string val in values)
            {
                //int.TryParse(val, out var mass);
                var mass = Convert.ToInt32(val);
                //var fuel = (int)Math.Floor((double)mass / 3) - 2;
                var fuel = CalculateFuel(mass);

                Console.WriteLine("mass: {0} - fuel {1}", mass, fuel);

                fuelSum += fuel;
                numModules++;

                //if (numModules >= 3)
                //    break;
            }

            Console.WriteLine("Fuel requirements for {0} modules: {1}", numModules, fuelSum);
        }

        static int CalculateFuel(int mass)
        {
            var fuel = (int)Math.Floor((double)mass / 3) - 2;
            if(fuel > 0)
            {
                fuel += CalculateFuel(fuel);
            }
            else
            {
                fuel = 0;
            }

            return fuel;
        }
    }
}
