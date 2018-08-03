using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Models
{
    public class Point3D
    {             
        private static Random rnd = new Random();        
       
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Point3D(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

       /// <summary>
       /// 
       /// </summary>
        public Point3D()
        {         
            x = rnd.Next(0, Cube.CubeLength + 1); //CubeLength +1
            y = rnd.Next(0, Cube.CubeLength + 1);
            z = rnd.Next(0, Cube.CubeLength + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + x + "," + y + "," + z + "]";
        }             
    }
}

//Contract.Requires(x >= 0 && x <= Cube.CubeLength);
//Contract.Requires(y >= 0 && y <= Cube.CubeLength);
//Contract.Requires(z >= 0 && z <= Cube.CubeLength);
//int iSeed = ((int)DateTime.Now.Ticks);
//Random rnd2 = new Random(iSeed);
//int iSeed2 = rnd2.Next(1, (int)EnumConsts.BombSeedMaxValue + 1);



///// <summary>
///// Random 3D Point created in coordinates [0,1000,1000]
///// </summary>
//public Point3D(int iSeed)
//{            
//    Random rnd = new Random(iSeed);
//    x = rnd.Next(0, ((int)EnumConsts.CubeLength) + 1); //CubeLength +1
//    y = rnd.Next(0, ((int)EnumConsts.CubeLength) + 1);
//    z = rnd.Next(0, ((int)EnumConsts.CubeLength) + 1);

//    Contract.Requires(x >= 0 && x <= (int)EnumConsts.CubeLength);
//    Contract.Requires(y >= 0 && y <= (int)EnumConsts.CubeLength);
//    Contract.Requires(z >= 0 && z <= (int)EnumConsts.CubeLength);
//}     
