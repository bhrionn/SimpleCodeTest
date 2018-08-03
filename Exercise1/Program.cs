using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{    
    class Program
    {
        static void Main(string[] args)
        {
            int iLandingTurnAroundStride = 2;

            var run = new RunUpStairs(iLandingTurnAroundStride);
            
            var iResult1 = run.Calculate(new int[] {15}, 2);
            Debug.Assert((int) iResult1 == 8);

            var iResult2 = run.Calculate(new int[] {15, 15}, 2);
            Debug.Assert((int)iResult2 == 18);

            var iResult3 = run.Calculate(new int[] {5, 11, 9, 13, 8, 30, 14}, 3);
            Debug.Assert((int) iResult3 == 44);

            Random rnd = new Random();
            int iNumberFlightOfStairs =rnd.Next(1, 51); // Number between 1 and 50                
            int iStepsPerStride = rnd.Next(2, 6);        // Number between 2 and 5

            var iResult4 = run.Calculate(iNumberFlightOfStairs, iStepsPerStride);
            Console.WriteLine("iResult4=" + iResult4);            
        }
    }
}
