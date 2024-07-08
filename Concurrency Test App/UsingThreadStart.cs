using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency_Test_App
{
    public class UsingThreadStart
    {

        static void sayHi()
        {
            Console.WriteLine("Hi from static method");
        }


        void sayHello()
        {
            Console.WriteLine("Hello from instance method");
        }

        public void runTest()
        {
            ThreadStart threadStart = new ThreadStart(sayHi);
            Thread thread = new Thread(threadStart);
            thread.Start();
            thread.Join();

            threadStart = new ThreadStart(new UsingThreadStart().sayHello);
            thread = new Thread(threadStart);
            thread.Start();
            thread.Join();
        }
    }
}
