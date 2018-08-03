using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class AddThisAddThat
    {
        private static int carry = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte[] AddRecursive(byte[] a, byte[] b)
        {
            //Start from bottom of the byte[] array
            a = a.Reverse().ToArray();
            b = b.Reverse().ToArray();
            if (a.Length == 0) return new byte[] { };
            int tempresult = a[0] + b[0] + carry;
            byte[] z = new byte[]
            { (byte)(tempresult) };
            carry = tempresult / (byte.MaxValue + 1);
            return z.Concat(AddRecursive(a.Skip(1).ToArray(), b.Skip(1).ToArray())).ToArray();
        }

#if OTHERSOLUTIONS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte[] AddRecursive1(byte[] a, byte[] b)
        {
            if (a.Length == 0) return new byte[] { };

            return
                new byte[] { (byte)(a[0] + b[0]) }.Concat(
                AddRecursive1(a.Skip(1).ToArray(), b.Skip(1).ToArray())
                ).ToArray();
        }

    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte[] Add(byte[] a, byte[] b, int index = -1)
        {
            if (index < 0)
            {
                return Add((byte[])a.Clone(), b, 0);
            }
            if (index < a.Length)
            {
                Add(a, b, index + 1);
                a[index] += b[index];
            }
            return a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ary1"></param>
        /// <param name="ary2"></param>
        /// <returns></returns>
        public static byte[] AddArray(byte[] ary1, byte[] ary2)
        {
            System.Diagnostics.Debug.Assert(ary1.Length == ary2.Length);
            if ((ary1 == null) || (ary2 == null))
            {
                throw new ArgumentException("Empty or null array");
            }
            // sum the last element
            var ix = ary1.Length - 1;
            var sum = (ary1[ix] + ary2[ix]);
            if (sum > byte.MaxValue)
            {
                if (ix == 0)
                {
                    throw new ArgumentException("Overflow");
                }
                // Add carry by recursing on ary1
                var carry = (byte)(sum - byte.MaxValue);
                var carryAry = new byte[ary1.Length];
                carryAry[ix - 1] = carry;
                ary1 = AddArray(ary1, carryAry);
            }

            if ((ary1.Length == 1) || (ary2.Length == 1))
            {
                return new byte[] { (byte)sum }; // end recursion
            }
            // create the remainder, elements from 0 it (len-1)
            var ary1Remainder = new byte[ary1.Length - 1];
            var ary2Remainder = new byte[ary2.Length - 1];
            Array.Copy(ary1, 0, ary1Remainder, 0, ary1.Length - 1);
            Array.Copy(ary2, 0, ary2Remainder, 0, ary2.Length - 1);
            // recurse
            var remainder = AddArray(ary1Remainder, ary2Remainder);
            // build return array (using linq Concat)
            var rv = (remainder.Concat(new byte[] { (byte)sum }));
            return rv.ToArray(); // return as an array 
        } 
#endif      
    }
}
