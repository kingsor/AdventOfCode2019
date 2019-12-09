using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 4 Project");

            PuzzleOne();

            PuzzleTwo();

            Console.ReadLine();
        }

        static void PuzzleOne()
        {
            var startNum = 272091;
            var endNum = 815432;

            var count = 0;

            for (int idx = startNum; idx <= endNum; idx++)
            {
                if (IsCodeValid(idx))
                {
                    Console.WriteLine("Code: {0}", idx);
                    count++;
                }
            }

            Console.WriteLine("Count: {0}", count);


            //var nums = new int[] { 111111, 223450, 123789, 112233, 123444, 111122 };

            //foreach (int num in nums)
            //{
            //    Console.WriteLine("Code {0} is valid: {1}", num, IsCodeValid(num));
            //}

        }

        static bool IsCodeValid(int code)
        {
            if(code.ToString().Length != 6)
            {
                return false;
            }

            var nums = IntToArray(code);
            var occurence = new int[10];

            for(int idx=0; idx<nums.Length; idx++)
            {
                occurence[nums[idx]]++;

                if(idx>0)
                {
                    if(nums[idx] < nums[idx-1])
                    {
                        return false;
                    }
                }
            }

            var maxVal = occurence.Max();

            if(maxVal<2)
            {
                return false;
            }

            if(maxVal>2)
            {
                var tmp = occurence.Where(i => i == 2).ToArray();

                if(tmp.Length == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static int[] IntToArray(int num)
        {
            var result = new List<int>();
            while (num != 0)
            {
                result.Insert(0, num % 10);
                num /= 10;
            }
            return result.ToArray();
        }

        static void PuzzleTwo()
        {

        }
    }
}
