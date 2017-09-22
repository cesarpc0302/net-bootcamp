using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] a = new int[n][];
            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
            }


            int diag1 = 0;
            int diag2 = 0;

            for (int i = 0; i < a.Length; i++)
            {
                diag1 += a[i][i];
                diag2 += a[i][a.Length - i - 1];
            }

            Console.WriteLine(Math.Abs(diag1 - diag2));
            Console.Read();
        }
    }
}
