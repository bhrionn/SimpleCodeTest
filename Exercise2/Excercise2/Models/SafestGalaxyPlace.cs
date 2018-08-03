using Excercise2.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Excercise2.Models
{
    public class SafestGalaxyPlace
    {      
        private Cube Cube { get; set; }
        public Point3D SafestPoint { get; set; }
        public double Distance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Calculate()
        {
            MathHelper m = new MathHelper();
            Tuple<Point3D, Point3D> points = m.Calculate(Cube.PositionOfBombs);
            SafestPoint = points.Item2;
            Distance = m.CalculateDistance(points.Item1, points.Item2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="N"></param>
        public SafestGalaxyPlace(int bombMaxValue, int cubeLength)
        {
            Cube = new Cube(cubeLength, bombMaxValue);          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("--- SafestGalaxyPlace --- ");
            sb.AppendLine(Cube.ToString());
            sb.AppendLine("SafestPoint:" + SafestPoint);
            sb.AppendLine("Distance:" + Distance);    
            
            return sb.ToString();
        }
    }
}
