using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    public unsafe class CustomArray<T>
    {
        private Mutex mutex = new Mutex();
        private T* pointerArray;
        public uint ArraySize { get;}
        public static int numArray { get; private set; } = 0;
        public CustomArray(uint arraySize)
        {
            pointerArray = (T*)NativeMemory.Alloc(GetSize() * arraySize);
            ArraySize = arraySize;
            numArray = numArray + 1;
        }
        private uint GetSize()
        {
            if (typeof(T) == typeof(int))
            {
                return sizeof(int);
            }
            else if (typeof(T) == typeof(float))
            {
                return sizeof(float);
            }
            else if (typeof(T) == typeof(double))
            {
                return sizeof(double);
            }
            else if (typeof(T) == typeof(decimal))
            {
                return sizeof(decimal);
            }
            else if (typeof(T) == typeof(long))
            {
                return sizeof(long);
            }
            else if (typeof(T) == typeof(short))
            {
                return sizeof(short);
            }
            else if (typeof(T) == typeof(uint))
            {
                return sizeof(uint);
            }
            else if (typeof(T) == typeof(ulong))
            {
                return sizeof(ulong);
            }
            else if (typeof(T) == typeof(ushort))
            {
                return sizeof(ushort);
            }
            else if (typeof(T) == typeof(char))
            {
                return sizeof(char);
            }
            else
            {
                throw new Exception("not using valid type");
            }
        }
        private bool IsValid(int idx)
        {
            return idx < ArraySize && idx >= 0;
        }
        public void SetValue(int idx, T value)
        {
            if (IsValid(idx))
            {
                mutex.WaitOne();
                *(pointerArray + idx) = value;
                mutex.ReleaseMutex();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public T GetValue(int idx)
        {
            if (IsValid(idx))
            {
                mutex.WaitOne();
                T value = *(pointerArray + idx);
                mutex.ReleaseMutex();
                return value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void PrintNumOfArray()
        {
            Console.WriteLine(numArray);
        }
        ~CustomArray()
        {
            NativeMemory.Free(pointerArray);
        }
    }
}
