using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    public class CustomList<T>
    {
        public int Count { get; private set; } = 0;
        private CustomArray<T> _array = new CustomArray<T>(10);
        public void Add(T item)
        {
            IncreaseListSizeIfNeeded();
            _array.SetValue(Count, item);
            Count++;
        }
        public void Remove(T item)
        {
            int itemIndex = 0;
            for(int i = 0; i < _array.ArraySize; i++)
            {
                T temp = _array.GetValue(i);
                if ((temp is null && item is null) || (temp is not null && temp.Equals(item)))
                {
                    itemIndex = i;
                    PushBackward(itemIndex);
                    return;
                }
            }
        }
        public void Clear()
        {
            _array = new CustomArray<T>(10);
            Count = 0;
        }
        public void Insert(int index, T item)
        {
            PushForward(index);
            this[index] = item;
        }
        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                
            }
        }
        private void IncreaseListSizeIfNeeded()
        {
            if (IsFull())
            {
                CustomArray<T> newArray = new CustomArray<T>(_array.ArraySize * 2);
                for(int i = 0; i < _array.ArraySize; i++)
                {
                    T currentValue = _array.GetValue(i);
                    newArray.SetValue(i, currentValue);
                }
                _array = newArray;
            };
        }
        private bool IsFull()
        {
            if (Count >= _array.ArraySize)
            {
                return true;
            }
            else return false;
        }
        private void PushBackward(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _array.SetValue(i, _array.GetValue(i + 1));
            }
            Count--;
        }
        private void PushForward(int index)
        {
            IncreaseListSizeIfNeeded();
            for (int i = Count; i > index; i--)
            {
                _array.SetValue(i, _array.GetValue(i - 1));
            }
            Count++;
        }

    }
}
