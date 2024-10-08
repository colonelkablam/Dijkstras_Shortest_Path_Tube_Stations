﻿namespace Testing
{
    public class JourneyLinkedList
    {
        // fields
        private int version;
        private int walkTime;
        private Journey? head;

        public JourneyLinkedList(int version)
        {
            walkTime = -1;
            this.version = version;
        }

        // Add to the end of the linked list
        public void AddJourney(Journey journey)
        {
            // if empty list then add journey as head
            if (head == null)
            {
                head = journey;
                return;
            }

            // keep track of node
            Journey? current = this.head;
            // look for end of linked list
            while (current.GetNext() != null)
            {
                current = current.GetNext();
            }
            // add next journey to list
            current.AddNext(journey);
        }
        public int GetWalkTime()
        {
            return walkTime;
        }
        public void AddWalkTime(int time)
        {
            this.walkTime = time;
        }

        // display journey calculated from different versions and walk times
        public void DisplayAll()
        {   
            // print out route to console
            Console.WriteLine();
            Console.WriteLine($"Version {version}: calculated shortest route - {walkTime} min walk");
            Console.WriteLine($"------------------------------------------------------");

            // if empty a default journey added
            if (this.head == null) this.AddJourney(new Journey());

            // keep track of current node
            Journey? current = this.head;

            // keep going until the end!
            while (current != null)
            {
                Console.WriteLine($"{current.GetStart()} - {current.GetEnd()} ({current.GetTime()}) mins");
                current = current.GetNext();
            }
            Console.WriteLine($"------------------------------------------------------");
        }

    }
}
