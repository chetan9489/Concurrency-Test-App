using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency_Test_App
{
    public class UsingParameterizedThreadStart
    {

        static void sayHi(Object obj)
        {
            String name = (String)obj;
            Console.WriteLine("Hi " + name + " from static method");
        }


        void sayHello(Object obj)
        {
            String name = (String)obj;
            Console.WriteLine("Hello " + name + " from instance method");
        }

        public void runTest()
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(sayHi);
            Thread thread = new Thread(threadStart);
            thread.Start("Fahim");
            thread.Join();

            threadStart = new ParameterizedThreadStart(new UsingParameterizedThreadStart().sayHello);
            thread = new Thread(threadStart);
            thread.Start("Fahim");
            thread.Join();
        }
    }
}
