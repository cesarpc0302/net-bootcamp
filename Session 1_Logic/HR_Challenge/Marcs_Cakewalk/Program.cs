using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcs_Cakewalk
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] calories_temp = Console.ReadLine().Split(' ');
            int[] calories = Array.ConvertAll(calories_temp, Int32.Parse);

            Array.Sort(calories);
            Array.Reverse(calories);
            long miles = 0;

            for (int i = 0; i < calories.Length; i++)
            { 
                miles += calories[i] * Convert.ToInt64(Math.Pow(2, i));
            }

            Console.WriteLine(miles);
            Console.Read();
        }
    }
}
