using System;

namespace Exercise1
{
    public class RunUpStairs
    {
        private int numberFlightOfStairs { get; set; }

        private int[] arrNumberOfFlightSteps;
        private int stepsPerStride { get; set; }
        private readonly int landingTurnAroundStride;
        public int FlightsOfStairs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrStepsPerFlight"></param>
        /// <param name="iStepsPerStride"></param>
        private void Configure(int[] arrStepsPerFlight, int iStepsPerStride)
        {
            arrNumberOfFlightSteps = arrStepsPerFlight;
            numberFlightOfStairs = arrStepsPerFlight.Length;
            stepsPerStride = iStepsPerStride;

            Console.WriteLine("----------------------------");
            Console.WriteLine("numberFlightOfStairs=" + numberFlightOfStairs);
            Console.WriteLine("stepsPerStride=" + iStepsPerStride);
            Console.WriteLine("landingTurnAroundStride=" + landingTurnAroundStride);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iLandingTurnAroundStride"></param>
        public RunUpStairs(int iLandingTurnAroundStride)
        {
            landingTurnAroundStride = iLandingTurnAroundStride;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrStepsPerFlight"></param>
        /// <param name="iStepsPerStride"></param>
        /// <returns></returns>
        internal object Calculate(int[] arrStepsPerFlight, int iStepsPerStride)
        {
            Configure(arrStepsPerFlight, iStepsPerStride);

            var TotalStridesMade = 0;
            foreach (var i in arrNumberOfFlightSteps)
            {
                TotalStridesMade += (int)i / stepsPerStride;
                var remainder = (int)i % stepsPerStride;
                if (remainder > 0)
                    TotalStridesMade++;
            }
            TotalStridesMade += (arrNumberOfFlightSteps.Length - 1) * 2;

            Console.WriteLine("TotalStridesMade=" + TotalStridesMade);
            Console.WriteLine("----------------------------");
            return TotalStridesMade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iNumberFlightOfStairs"></param>
        /// <param name="iStepsPerStride"></param>
        /// <returns></returns>
        internal object Calculate(int iNumberFlightOfStairs, int iStepsPerStride)
        {
            Random rnd = new Random();

            arrNumberOfFlightSteps = new int[iNumberFlightOfStairs];

            for (var i = 0; i < iNumberFlightOfStairs; i++)
            {
                int iNumberOfSteps = rnd.Next(5, 31);
                arrNumberOfFlightSteps[i] = iNumberOfSteps;
            }
            Configure(arrNumberOfFlightSteps, iStepsPerStride);

            return Calculate(arrNumberOfFlightSteps, iStepsPerStride);
        }
    }
}
