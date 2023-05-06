using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class JourneyLinkedList
    {
        private string name;
        private int walkTime;
        private Journey? head;

        public JourneyLinkedList(string name)
        {
            this.name = name;
        }

        // method to add to the end of the linked list
        public void AddJourney(Journey journey)
        {
            Journey? next = this.head;
            
            while (next != null)
            {
                next = next.GetNext();
            }

            next.AddNext(journey);
        }
        public void AddWalkTime(int time)
        {
            this.walkTime = time;
        }

        // display jorneys and times
        public void DisplayAll()
        {
            Console.WriteLine($"Route start and end: {name}");
            Journey? current = this.head;

            while (current != null)
            {
                Console.WriteLine($"{current.GetStart()} - {current.GetEnd()} ({current.GetTime()} mins");
                current = current.GetNext();
            }
        }

    }
}
