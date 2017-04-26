using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    abstract class BinaryHeap<T>
        where T : IComparable
    {
        protected T[] value;
        public int Size
        {
            get
            {
                return value.Length;
            }
        }
        public BinaryHeap(params T[] heap)
        {
            value = new T[0];
            BuildingHeap(heap);
        }

        protected void BuildingHeap(params T[] heap)
        {
            Array.Resize(ref value, heap.Length);
            value = heap;
            for (int i = (Size - 1) / 2; i >= 0; i--) Heapify(i);
        }
        public abstract void Heapify(int position);
        protected abstract void IncrementKey(int position);

        public void AddNewChild(T key)
        {
            Array.Resize(ref value, Size + 1);
            value[Size - 1] = key;
            IncrementKey(Size - 1);
        }


        public T DeleteVertex()
        {
            if (Size >= 1)
            {
                T vertex = value[0];
                value[0] = value.Last();
                Array.Resize(ref value, Size - 1);
                Heapify(0);
                return vertex;
            }
            throw new ArgumentNullException("В куче нет ни одного элемента");
        }
    }
}
