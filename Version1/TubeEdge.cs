//using System.Collections.Generic;

namespace Testing
{
    internal class TubeEdge
    {
        private TubeStation Source;
        private TubeStation Destination;
        private int WalkingTime;
        private string TubeLine;



        public TubeEdge(TubeStation source, TubeStation destination, int walkingTime)
        {
            Source = source;
            Destination = destination;
            WalkingTime = walkingTime;

            // Determine the TubeLine connecting the source and destination stations
            string[] sourceLines = source.GetTubeLines();
            string[] destLines = destination.GetTubeLines();
            TubeLine = sourceLines.Intersect(destLines).FirstOrDefault();
        }

        public TubeStation GetSource()
        {
            return Source;
        }

        public TubeStation GetDestination()
        {
            return Destination;
        }

        public int GetWalkingTime()
        {
            return WalkingTime;
        }

        public string GetTubeLine()
        {
            return TubeLine;
        }

        private string GetCommonTubeLine(string[] sourceLines, string[] destLines)
        {
            foreach (string sourceLine in sourceLines)
            {
                foreach (string destLine in destLines)
                {
                    if (sourceLine == destLine)
                    {
                        return sourceLine;
                    }
                }
            }

            return null;
        }

    }
}
