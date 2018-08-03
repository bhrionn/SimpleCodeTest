#define USEDATA
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Test
{  
    [TestFixture]
    public class TestAddThisAddThat
    {
#if USEDATA
        [Test, TestCaseSource(typeof(TestCaseData), "Add_Source")]
#else
        [Test, TestCaseSource("Add_Source")]
#endif
        public AddResult Add_UsingARecursiveAlgorithm_ValuesAreAdded(byte[] f, byte[] s)
        {
            // Arrange

            // Act
            var result =  AddThisAddThat.AddRecursive(f,s).Reverse().ToArray(); ;

            // Assert
            return new AddResult(f, s, result);          
        }

        ///
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

        //[Test]
        public void Add_UsingARecursiveAlgorithm_ValuesAreAdded2()
        {
            //First Test
            byte[] expectedResult = AddThisAddThat.AddRecursive(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 2, 2, 2 }));
            //Sec Test
            expectedResult = AddThisAddThat.AddRecursive(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 1, 2, 0 }));
            //Third Test
            expectedResult = AddThisAddThat.AddRecursive(new byte[] { 255, 255, 255 }, new byte[] { 255, 255, 255 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 255, 255, 254 }));
        }

#if OTHERSOLUTIONS
        [Test]
        public void Add_UsingARecursiveAlgorithm_ValuesAreAdded_Eg1()
        {
            //First Test
            byte[] expectedResult = AddThisAddThat.AddRecursive1(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 2, 2, 2 }));
            //Sec Test
            expectedResult = AddThisAddThat.AddRecursive1(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 1, 2, 0 }));
            //Third Test
            expectedResult = AddThisAddThat.AddRecursive1(new byte[] { 255, 255, 255 }, new byte[] { 255, 255, 255 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 255, 255, 254 }));
        }

        [Test]
        public void Add_UsingARecursiveAlgorithm_ValuesAreAdded_Eg3()
        {
            //First Test
            byte[] expectedResult = AddThisAddThat.Add(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 2, 2, 2 }));
            //Sec Test
            expectedResult = AddThisAddThat.Add(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 1, 2, 0 }));
            //Third Test
            expectedResult = AddThisAddThat.Add(new byte[] { 255, 255, 255 }, new byte[] { 255, 255, 255 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 255, 255, 254 }));
        }


        [Test]
        public void Add_UsingARecursiveAlgorithm_ValuesAreAdded_Eg4()
        {
            //First Test
            byte[] expectedResult = AddThisAddThat.AddArray(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 2, 2, 2 }));
            //Sec Test
            expectedResult = AddThisAddThat.AddArray(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 1, 2, 0 }));
            //Third Test
            expectedResult = AddThisAddThat.AddArray(new byte[] { 255, 255, 255 }, new byte[] { 255, 255, 255 }).Reverse().ToArray();
            Assert.That(expectedResult, Is.EqualTo(new byte[] { 255, 255, 254 }));
        }
#endif
    }   
}
