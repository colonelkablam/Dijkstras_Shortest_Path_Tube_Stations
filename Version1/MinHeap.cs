/*
 * adapted from
 * Week 8
 * Tutorial Exercises: Heaps - MinHeap class uses HeapItem class
 */

using System;

namespace Testing
{
    public class MinHeap
    {
        private const int initialCapacity = 100;
        private const int noSwapChild = -1;
        private const HeapItem emptySlot = null;     
        private int Capacity = initialCapacity;     // set the intial capacity 
        private HeapItem[] heap;                    // array of HeapItems - the Heap itself
        private int size = 0;                       // number of items in the heap  
                                                    // and also the index of next insertion into heap (e.g. empty heap insert at zero etc)
                                                    // NB minimum key value is in array index 0
        public MinHeap()
        {
            heap = new HeapItem[Capacity];
            initialiseHeap();
        }
        public MinHeap(int capacity)
        {
            Capacity = capacity;
            heap = new HeapItem[Capacity];
            initialiseHeap();
        }
        private void initialiseHeap()
        {
            for (int i = 0; i < Capacity; i++)
            {
                heap[i] = emptySlot;
            }
        }      
        // mapping the child to the parent
        public static int parentIndex(int index)
        {
            return ((index - 1) / 2);
        }
        // mapping the parent to the leftChild
        public static int leftChildIndex(int index)
        {
            return ((2 * index) + 1);
        }
        // mapping the parent to the rightChild
        public static int rightChildIndex(int index)
        {
            return ((2 * index) + 2);
        }
        public void Insert(HeapItem newItem)  
        {
            if (size == Capacity)
            {
                // check if Heap is full - if so then increase its size

                HeapItem[] newHeap = new HeapItem[2 * Capacity];
                Array.Copy(heap, newHeap, Capacity);
                for (int i = Capacity; i < (2 * Capacity); i++)
                {
                    newHeap[i] = emptySlot;
                }
                Capacity = (2 * Capacity);
                heap = newHeap;
            }

            // determining the position for insertion
            // begin at index == size, then sift up -> min key value ends up at the top of the heap

            int index = size;
            bool shouldContinue = true;

            while (index > 0 && shouldContinue == true)
            {
                int parent = parentIndex(index);

                if (heap[parent].GetKey() > newItem.GetKey())
                {
                    heap[index] = heap[parent];
                    index = parent;
                }
                else
                {
                    shouldContinue = false;
                }
            }
            heap[index] = newItem;
            size++;
        }
        public Boolean Empty()
        {
            return (size == 0);
        }
        public HeapItem GetMinimum()
        {
            if (Empty())
            {
                throw new HeapException("Empty Heap");
            }
            else
            {
                return heap[0];
            }
        }
        public HeapItem ExtractMinimum()    //i.e Dequeuing the top (minimum) element
        {
            if (Empty())
            {
                throw new HeapException("Empty Heap");
            }
            HeapItem minimumElement = heap[0];

            // determine position to re-insert heap[size-1]:
            // begin at index==0, then sift down, pulling elements up

            int index = 0, child = 1;
            size--;
            bool shouldContinue = true;

            while (child < size && shouldContinue == true)
            {
                // at this point, child is the left child of the index;
                // so pick the right child instead if it exists and has a smaller value

                if ((child + 1 < size) && (heap[child].GetKey() > heap[child + 1].GetKey()))
                {
                    child++;
                }

                if (heap[child].GetKey() < heap[size].GetKey())
                {
                    heap[index] = heap[child];
                    index = child;
                    child = leftChildIndex(index);
                }
                else
                {
                    shouldContinue = false;
                }
            }

            heap[index] = heap[size];

            return minimumElement;
        }
        //public void Print()
        //{
        //    Console.WriteLine("Heap Array representation: ");

        //    for (int i = 0; i < size; i++)
        //    {
        //        Console.WriteLine("  " + i + ":  " + heap[i].ToString());
        //    }

        //    Console.WriteLine();
        //}


        //public void PrintStructure()
        //{
        //    Console.WriteLine("Heap Array Structure: ");

        //    for (int i = 0; i < size; i++)
        //    {
        //        Console.WriteLine("  " + i + ":  " + heap[i].ToString() + " children: ");

        //        int lCI = leftChildIndex(i);
        //        int rCI = rightChildIndex(i);

        //        if (lCI < size)
        //        {
        //            Console.WriteLine($"\t {lCI}:  Left Child: " + heap[lCI].ToString());

        //            if (rCI < size)
        //            {
        //                Console.WriteLine($"\t {rCI}:  Right Child: " + heap[rCI].ToString());
        //            }
        //            else
        //            {
        //                Console.WriteLine("\t No Right Child");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("\t No Children");
        //        }
        //    }

        //    Console.WriteLine();
        //}


    } 

} 
