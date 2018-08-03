using NUnit.Framework;
using System.Collections;

namespace Exercise3.Test
{
    public class TestCaseData
    {
        public static IEnumerable Add_Source
        {
            get
            {
                yield return new NUnit.Framework.TestCaseData(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 })
                    .Returns(new AddResult(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }, new byte[] { 2, 2, 2 }));

                yield return new NUnit.Framework.TestCaseData(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 })
                  .Returns(new AddResult(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }, new byte[] { 1, 2, 0 }));

                yield return new NUnit.Framework.TestCaseData(new byte[] { 0, 100, 200 }, new byte[] { 3, 2, 1 })
                  .Returns(new AddResult(new byte[] { 0, 100, 200 }, new byte[] { 3, 2, 1 }, new byte[] { 102, 3, 201 }));
            }
        }
    }
}
