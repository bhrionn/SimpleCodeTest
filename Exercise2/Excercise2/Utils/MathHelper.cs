using Excercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Utils
{
    public class MathHelper
    {       
        /// <summary>
        ///  Tuple with point of safest point from nearest bomb.
        /// </summary>
        public Tuple<Point3D, Point3D> bombSafePair { get; set; }
        public List<Tuple<Point3D, Point3D, double>> bomb_SafePt_Dist_Tuple { get; set; }

        /// <summary>
        /// Calculate safest point and distance from a bomb.
        /// </summary>
        /// <param name="bombPoint"></param>
        /// <returns></returns>
        public Tuple<Point3D, Point3D, double> GetSafestPoint(Point3D bombPoint)
        {
            Point3D safestPoint = CalculateFurthestPoint(bombPoint);

            double distance = CalculateDistance(bombPoint, safestPoint);

            return new Tuple<Point3D, Point3D, double>(bombPoint, safestPoint, distance);
        }

        /// <summary>
        /// 
        /// </summary>
        public MathHelper()
        {
            bomb_SafePt_Dist_Tuple = new List<Tuple<Point3D, Point3D, double>>();
        }

        /// <summary>
        /// Return safest location, item1 and nearest bomb point, item2, as a pair. 
        /// // StartRecursion with origin point as safest point.
        /// </summary>
        /// <param name="bombLocations"></param>
        /// <returns></returns>
        public Tuple<Point3D, Point3D> Calculate(List<Point3D> bombLocations)
        {
            Tuple<Point3D, Point3D> tuplePoints;
            FindSafestPointNearestBombInfo(bombLocations, out tuplePoints);
            return tuplePoints;
        }      
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationsR"></param>
        /// <param name="SafestTuple"></param>
        private void FindSafestPointNearestBombInfo(List<Point3D> locationsR, out Tuple<Point3D, Point3D> SafestTuple)
        {
            List<Point3D> safePointList = new List<Point3D>();
            List<Point3D> bombList = new List<Point3D>();

            foreach (var v in locationsR)
            {
                Tuple<Point3D, Point3D, Double> tmp = GetSafestPoint(v);
                bomb_SafePt_Dist_Tuple.Add(tmp);

                safePointList.Add(tmp.Item2);
                bombList.Add(tmp.Item1);
            }

            Point3D safestPoint= GetSafestPointInCube(safePointList);
            Point3D closetBombPoint = GetClosestBombFromSafestPointInCube(bombList, safestPoint);
            SafestTuple = new Tuple<Point3D, Point3D>(closetBombPoint, safestPoint);
        }

        /// <summary>
        /// // Safest point in cube is point that is furthest away from closet bomb.
        /// </summary>
        private Point3D GetSafestPointInCube(List<Point3D> safePointList)
        {
            return InterpolateN(safePointList);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bombList"></param>
        /// <param name="safestPoint"></param>
        /// <returns></returns>
        private Point3D GetClosestBombFromSafestPointInCube(List<Point3D> bombList, Point3D safestPoint)
        {
            double d = 0, dCurrent=0;
            Point3D closetBomb= new Point3D(0, 0, 0);
            foreach(var v in bombList)
            {
                dCurrent = CalculateDistance(v, safestPoint);

                if (d<dCurrent)
                {
                    d = dCurrent;
                    closetBomb = v;
                }
            }
            return closetBomb;
        }

        #region HELPERS
        /// <summary>
        /// Calculate furthest point between CubeLength and a point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Point3D CalculateFurthestPoint(Point3D point)
        {
            int x = Cube.CubeLength - point.x;
            int y = Cube.CubeLength - point.y;
            int z = Cube.CubeLength - point.z;
            return new Point3D(x, y, z);            
        }

        /// <summary>
        /// Calculate distance between two points.
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        public double CalculateDistance(Point3D pointA, Point3D pointB)
        {
            int deltaX = pointA.x - pointB.x;
            int deltaY = pointA.y - pointB.y;
            int deltaZ = pointA.z - pointB.z;

            return (double)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointList"></param>
        /// <returns></returns>
        public Point3D InterpolateN(List<Point3D> pointList)
        {
            int x = 0, y = 0, z = 0;

            foreach (var v in pointList)
            {
                x += Math.Abs(v.x);
                y += Math.Abs(v.y);
                z += Math.Abs(v.z);
            }
            x = x / pointList.Count;
            y = y / pointList.Count;
            z = z / pointList.Count;

            return new Point3D(x, y, z);
        }

        public int GetSquareOfDistance(Tuple<Point3D, Point3D> points)
        {
            int iDistance = 0;
            return iDistance * iDistance;
        }

        ///// <summary>
        ///// Get mid point between points.
        ///// </summary>
        ///// <param name="pointA"></param>
        ///// <param name="pointB"></param>
        ///// <returns></returns>
        //public Point3D CalculateMidPoint(Point3D pointA, Point3D pointB)
        //{
        //    int x = Math.Abs(pointA.x + pointB.x) / 2;
        //    int y = Math.Abs(pointA.y + pointB.y) / 2;
        //    int z = Math.Abs(pointA.z + pointB.z) / 2;

        //    return new Point3D(x, y, z);
        //}
        #endregion
    }
}



