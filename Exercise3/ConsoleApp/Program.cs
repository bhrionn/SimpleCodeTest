using Exercise3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {       
        public static void Main(string[] args)
        {
            var r1 = AddThisAddThat.AddRecursive(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 });
            var r2 = AddThisAddThat.AddRecursive(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 });
            var r3 = AddThisAddThat.AddRecursive(new byte[] { 0, 100, 200 }, new byte[] { 3, 2, 1 });
            // Outputs: 2, 2, 2
            Console.WriteLine(string.Join(", ", r1.Select(n => "" + n).Reverse().ToArray()));
            // Outputs: 1, 2, 0
            Console.WriteLine(string.Join(", ", r2.Select(n => "" + n).Reverse().ToArray()));
            // Outputs: 102, 3, 201
            Console.WriteLine(string.Join(", ", r3.Select(n => "" + n).Reverse().ToArray()));
        }
    }
}
