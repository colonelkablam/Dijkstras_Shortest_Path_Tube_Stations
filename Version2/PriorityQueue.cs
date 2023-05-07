using System;
namespace Adjacency
{
    public class PriorityQueue
    {
        private Pair[] heap;
        private int count;
        private int capacity;

        public PriorityQueue(int capacity)
        {
            this.capacity = capacity;
            heap = new Pair[capacity];
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Enqueue(Pair pair)
        {
            if (count == capacity)
            {
                throw new Exception("Heap is full");
            }

            //Pair pair = new Pair(edge.Weight, edge.Destination);
            int i = count;
            heap[i] = pair;
            count++;

            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (heap[i].Distance < heap[parent].Distance)
                {
                    Swap(i, parent);
                    i = parent;
                }
                else
                {
                    break;
                }
            }
        }

        public Pair Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("Heap is empty");
            }

            Pair resultPair = heap[0];
            count--;

            heap[0] = heap[count];
            heap[count] = null;

            int i = 0;

            while (true)
            {
                int leftChild = 2 * i + 1;
                int rightChild = 2 * i + 2;

                if (leftChild >= count)
                {
                    break;
                }

                int j = leftChild;

                if (rightChild < count && heap[rightChild].Distance < heap[leftChild].Distance)
                {
                    j = rightChild;
                }

                if (heap[j].Distance < heap[i].Distance)
                {
                    Swap(i, j);
                    i = j;
                }
                else
                {
                    break;
                }
            }

            return resultPair;
        }

        private void Swap(int i, int j)
        {
            Pair temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }


}

