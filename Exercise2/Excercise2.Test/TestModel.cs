using Excercise2.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Test
{
    [TestFixture]
    class TestModel
    {
        //[Test]
        //public void TestTestCasesModelIs5()
        //{
        //    string fullPath = Directory.GetCurrentDirectory() + "\\" + @"InputFile.txt";

        //    TestCasesModel m = new TestCasesModel(fullPath, 5, 10);
        //    Debug.Write(m.ToString());
        //    Assert.IsTrue(m.T == 50);            
        //}

        [Test]
        public void TestTestCasesModelIs50()
        {
            string fullPath = Directory.GetCurrentDirectory() + "\\" + @"InputFile.txt";

            TestCasesModel m = new TestCasesModel(fullPath, 5, 10);
            Debug.Write(m.ToString());
            Assert.IsTrue(m.SafeGalaxyPlaceList.Count == 50);
        }
    }
}
