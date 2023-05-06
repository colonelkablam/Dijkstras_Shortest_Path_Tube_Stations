using System;
using System.Collections.Generic;

namespace Testing
{
    public class Journey
    {
        private string start;
        private string end;
        private int time;
        private Journey? nextJourney;

        public Journey(string start, string end, int time)
        {
            this.start = start;
            this.end = end;
            this.time = time;
            this.nextJourney = null;
        }

        public string GetStart()
        {
            return start;
        }
        public string GetEnd()
        {
            return end;
        }
        public int GetTime()
        {
            return time;
        }
        public Journey GetNext()
        {
            return this.nextJourney;
        }
        public void AddNext(Journey next)
        {
            this.nextJourney = next;
        }
    }
}
