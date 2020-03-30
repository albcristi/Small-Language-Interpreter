using System;
using System.Collections.Concurrent;
using System.Threading;
using ToyLanguage.Model.Value;

namespace ToyLanguage.DataStructures
{
    public class Heap: ConcurrentDictionary<Int32,Value>,HeapInterface
    {
        private static Int32 addrVal = 0;
        private static Mutex mutex;
        public Heap()
        {
            mutex = new Mutex();
        }

        public int generateAddress()
        {
            Int32 val;
            mutex.WaitOne();
            addrVal++;
            val = addrVal;
            mutex.ReleaseMutex();
            return val;
        }
    }
}