using Excercise2.Models;
using Excercise2.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Test
{
    [TestFixture]
    class TestMathHelper
    {
        [Test]
        public void TestSafePlaceModelValues()
        {
            MathHelper m = new MathHelper();

            List<Point3D> bombLocations = new List<Point3D>() { new Point3D(0, 0, 0), new Point3D(10, 0, 0) };
            Tuple<Point3D, Point3D> points = m.Calculate(bombLocations);
            Point3D SafestPoint = points.Item2;
            Double Distance = m.CalculateDistance(points.Item1, points.Item2);
            Assert.IsTrue(SafestPoint.x == 5 && SafestPoint.y == 10 && SafestPoint.z == 10);
            Assert.IsTrue(Distance == 15);

            List<Point3D> bombLocations2 = new List<Point3D>() { new Point3D(0, 0, 0), new Point3D(10, 0, 0), new Point3D(10, 10, 0), new Point3D(0, 10, 0) };
            Tuple<Point3D, Point3D> points2 = m.Calculate(bombLocations2);
            Point3D SafestPoint2 = points2.Item2;
            Double Distance2 = m.CalculateDistance(points.Item1, points.Item2);
            Assert.IsTrue(SafestPoint2.x == 5 && SafestPoint2.y == 5 && SafestPoint2.z == 10);
            Assert.IsTrue(Distance == 15);
        }
    }
}
