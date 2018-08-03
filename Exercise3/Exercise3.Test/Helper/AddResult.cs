using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class AddResult
    {
        private byte[] f;
        private byte[] s;
        private byte[] result;

        public AddResult(byte[] f, byte[] s, byte[] result)
        {
            this.f = f;
            this.s = s;
            this.result = result;
        }

        /// <summary>
        /// Compare two objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            AddResult res = obj as AddResult;
            if (res == null)
                return false;
            else
                return result.SequenceEqual(res.result);
        }

        public override int GetHashCode()
        {
            return this.result.GetHashCode();
        }
    }
}
