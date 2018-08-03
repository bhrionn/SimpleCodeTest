using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Models
{
    public class Cube
    {
        private static Random rnd = new Random();

        public static int CubeLength;
        public static Point3D Origin;
        public static Point3D MaxEdge;

        public readonly List<Point3D> PositionOfBombs; //3*N

        public Cube(int cubeLength, int bombMaxValue)
        {
            CubeLength = cubeLength;

            int NumberOfBombs = rnd.Next(1, bombMaxValue + 1);

            PositionOfBombs = new List<Point3D>(NumberOfBombs) { };

            // 3*N integers describing positions of bombs.
            for (var i = 0; i < NumberOfBombs; i++)
            {
                PositionOfBombs.Add(new Point3D());
            }

            //  Origin = new Point3D(0, 0, 0);
            //  MaxEdge = new Point3D(CubeLength, CubeLength, CubeLength);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- Cube --- ");
            sb.AppendLine("cubeLength=" + Cube.CubeLength);
            sb.AppendLine("numberOfBombs:" + PositionOfBombs.Count);
            sb.AppendLine("positionOfBombs:");
            
           
            

            foreach (var v in PositionOfBombs)
            {
                sb.AppendLine(">> " + v.ToString());
            }
            sb.AppendLine("------");

            return sb.ToString();
        }
    }
}
