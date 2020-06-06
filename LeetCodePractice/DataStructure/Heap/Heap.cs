using System.Collections.Generic;

namespace LeetCodePractice.DataStructure.Heap
{
    public class Heap<T>
    {
        private readonly IList<T> _data;
        private readonly IComparer<T> _comparer;
        public int Count => _data.Count;
        public T Peek => _data[0];        

        public Heap(IList<T> data, IComparer<T> comparer = null)
        {
            _data = data;
            _comparer = comparer ?? Comparer<T>.Default;
            //heapify data
            int i = _data.Count / 2;
            while(i >= 0)
            {
                Down(i--);
            }
        }

        //push a node down
        private void Down(int i)
        {
            int left = Left(i), right = Right(i), smallest = i;
            if (left < _data.Count && _comparer.Compare(_data[left], _data[i]) < 0) smallest = left;
            if(right < _data.Count && _comparer.Compare(_data[right], _data[smallest]) < 0) smallest = right;
            if(smallest != i)
            {
                Swap(smallest, i);
                Down(smallest);
            }
        }

        //bubble up a node
        private void Up(int i)
        {
            int p = Parent(i);
            if(i != p && _comparer.Compare(_data[p], _data[i]) > 0)
            {
                Swap(p, i);
                Up(p);
            }
        }

        //return the first value, and maintain heap
        public T Pop()
        {
            if(_data.Count > 0)
            {
                T res = _data[0];
                DeleteAt(0);
                return res;
            }
            return default(T);
        }

        //add an element
        public void push(T t)
        {
            _data.Add(t);
            Up(_data.Count - 1);
        }
        
        //delete an element at index i
        public void DeleteAt(int i)
        {
            if(i != _data.Count - 1)
            {
                Swap(i, _data.Count - 1);
                _data.RemoveAt(_data.Count - 1);
                Down(i);
            }
            else
            {
                _data.RemoveAt(i);
            }
        }

        private int Parent(int child)
        {
            return child == 0 ? 0 : (child + 1) / 2 - 1;
        }
        private int Left(int parent)
        {
            return parent * 2 + 1;
        }
        private int Right(int parent)
        {
            return parent * 2 + 2;
        }

        private void Swap(int i, int j)
        {
            T temp = _data[i];
            _data[i] = _data[j];
            _data[j] = temp;
        }
    }
}
