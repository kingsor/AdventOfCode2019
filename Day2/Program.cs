using System;
using System.IO;

namespace Day2
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
            var lines = File.ReadAllLines("./input.txt");

            for (int idx = 0; idx < lines.Length; idx++)
            {
                var result = ExecProgram(lines[idx], 12, 2, true);
                Console.WriteLine("Result: {0}", result);
            }

            var count = 0;

            for(int noun=0; noun<100; noun++)
            {
                for(int verb=0; verb<100; verb++)
                {
                    var result = ExecProgram(lines[5], noun, verb, false);
                    count++;
                    if(result == 19690720)
                    {
                        Console.WriteLine("result {0} - noun {1} - verb {2} - exec count {3}", result, noun, verb, count);
                        return;
                    }
                }
            }

        }

        static int ExecProgram(string values, int noun, int verb, bool showLog)
        {
            var intcode = ToIntArray(values, ',');

            if(intcode.Length > 20)
            {
                intcode[1] = noun;
                intcode[2] = verb;
            }

            var opCount = 0;

            for (int idx = 0; idx < intcode.Length; idx += 4)
            {
                var opCode = intcode[idx];

                opCount++;

                if (opCode == 99)
                    break;

                var op1 = intcode[idx + 1];
                var op2 = intcode[idx + 2];
                var res = intcode[idx + 3];

                if(showLog)
                    Console.WriteLine("opCode: {0} - op1 {1} - op2 {2} - res {3}", opCode, op1, op2, res);

                switch (opCode)
                {
                    case 1:
                        intcode[res] = intcode[op1] + intcode[op2];
                        break;
                    case 2:
                        intcode[res] = intcode[op1] * intcode[op2];
                        break;
                }

                if(showLog)
                    Console.WriteLine("values: op1 {0} - op2 {1} - res {2}", intcode[op1], intcode[op2], intcode[res]);
            }

            if(showLog)
                Console.WriteLine("Executed {0} op", opCount);

            var result = intcode[0];

            return result;
        }

        static int[] ToIntArray(string value, char separator)
        {
            return Array.ConvertAll(value.Split(separator), s => int.Parse(s));
        }

        static void PuzzleTwo()
        {

        }
    }
}
