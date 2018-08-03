using Excercise2.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Test
{
    [TestFixture]
    public class TestCube
    {
        [Test]
        public void TestCubeIs1000()
        {
            Cube c = new Cube(1000, 200);
            Assert.IsTrue(Cube.CubeLength == 1000);
        }

        [Test]
        public void TestCubeLength()
        {
            Cube c = new Cube(1000, 200);
            Debug.Write("Expected Max length=" + Cube.CubeLength * Math.Sqrt(2));

            Assert.IsTrue(Cube.CubeLength == 1000);
        }

        [Test]
        public void TestCubeIsGreaterThan1000()
        {            
            Assert.Greater(Cube.CubeLength == 1001, "Cube greater than 1001");
        }
    }
}
