using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grading_Students
{
    class Program
    {
        static int[] solve(int[] grades)
        {
            int[] finalGrades = new int[grades.Length];
            int i = 0;
            foreach (int value in grades)
            {
                if (value < 38)
                {
                    finalGrades[i] = value;
                }
                else if ((value % 5) < 3)
                {
                    finalGrades[i] = value;
                }
                else
                {
                    finalGrades[i] = value - (value % 5) + 5;
                }
                i++;
            }

            return finalGrades;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int grades_i = 0; grades_i < n; grades_i++)
            {
                grades[grades_i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] result = solve(grades);
            Console.WriteLine(String.Join("\n", result));
            Console.Read();

        }
    }
}
