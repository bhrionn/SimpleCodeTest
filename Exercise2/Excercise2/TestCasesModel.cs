using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise2.Models
{
    public class TestCasesModel : ITestCasesModel
    {                
        public readonly List<SafestGalaxyPlace> SafeGalaxyPlaceList = new List<SafestGalaxyPlace>();
                      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FullPath"></param>
        public TestCasesModel(string FullPath, int bombMaxValue, int cubeLength)
        {
            int T = GetTestCaseNumber(FullPath);

            SafeGalaxyPlaceList = new List<SafestGalaxyPlace>(T);

            for (var i = 0; i < T; i++)
            {                          
                SafeGalaxyPlaceList.Add(new SafestGalaxyPlace(bombMaxValue, cubeLength));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public int GetTestCaseNumber(string fullPath)
        {
            string sInputFile = File.ReadAllText(fullPath);
            string[] s = sInputFile.Split('=');
            int iResult = 0;
            int.TryParse(s[1], out iResult);
            return iResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--- TestCasesModel ---");
            sb.AppendLine("numberOfTestCases=" + SafeGalaxyPlaceList.Count);
            

            foreach (var v in SafeGalaxyPlaceList)
            {
                v.Calculate();
                sb.AppendLine(v.ToString());
            }           

            return sb.ToString();
        }    
    }

    public interface ITestCasesModel
    {
        int GetTestCaseNumber(string fullPath);
    }
}
 