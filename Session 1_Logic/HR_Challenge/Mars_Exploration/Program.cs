using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Exploration
{
    class Program
    {
        static void Main(String[] args)
        {
            string S = Console.ReadLine();
            int result = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (i % 3 == 1)
                {
                    if (S.Substring(i, 1) != "O")
                    {
                        result++;
                    }
                }
                else if (S.Substring(i, 1) != "S")
                {
                    result++;
                }
            }

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
