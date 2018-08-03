using Excercise2.Models;
using Excercise2.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullPath = Directory.GetCurrentDirectory() + "\\" + @"InputFile.txt";

            if (!File.Exists(fullPath))
                throw new Exception("ERROR: Peas check file exists");

            TestCasesModel m1 = new TestCasesModel(fullPath, 10, 100);
            Console.WriteLine(m1.ToString());

            TestCasesModel m2 = new TestCasesModel(fullPath, 200, 1000);
            Console.WriteLine(m2.ToString());
        }
    }
}



