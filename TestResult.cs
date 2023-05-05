using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class TestResult
    {
        private double timeToCompute;
        private string pathTaken;
        private int walkingTime;

        public TestResult() 
        {
            // default results
            timeToCompute = 0;
            pathTaken = "not calculated";
            walkingTime = -1;
        }

        // get station path
        public string GetPathTaken()
        {
            return pathTaken;
        }

        // get walking time
        public int GetWalkingTime()
        {
            return walkingTime;
        }

        // get calculation time
        public double GetTimeToCompute()
        {
            return timeToCompute;
        }
    }
}
