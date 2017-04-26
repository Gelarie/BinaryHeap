using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    class MaxBinaryHeap<T> : BinaryHeap<T>
    where T : IComparable
    {
        public MaxBinaryHeap(params T[] heap) : base(heap)
        {
        }
        protected override void IncrementKey(int position)
        {
            while (position > 0 && value[position].CompareTo(value[(position - 1) / 2]) > 0)
            {
                T replace = value[position];
                value[position] = value[(position - 1) / 2];
                value[(position - 1) / 2] = replace;
                position = (position - 1) / 2;
            }
        }
        public override void Heapify(int position)
        {
            int leftChild = 2 * position + 1;
            int rightChild = 2 * position + 2;
            int largestChild = position;
            if (leftChild < Size && value[leftChild].CompareTo(value[largestChild]) > 0) largestChild = leftChild;
            if (rightChild < Size && value[rightChild].CompareTo(value[largestChild]) > 0) largestChild = rightChild;
            if (largestChild != position)
            {
                T changed = value[position];
                value[position] = value[largestChild];
                value[largestChild] = changed;
                Heapify(largestChild);
            }
        }
    }
}