using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency_Test_App
{
    public class DeadlockExample
    {
        private Mutex lockA = new Mutex();
        private Mutex lockB = new Mutex();


        void thread1()
        {
            lockA.WaitOne();
            Console.WriteLine(String.Format("Thread {0} acquires lock A", Thread.CurrentThread.Name));
            Thread.Sleep(1000);
            lockB.WaitOne();
            Console.WriteLine(String.Format("Thread {0} acquired both locks", Thread.CurrentThread.Name));
        }

        void thread2()
        {
            lockB.WaitOne();
            Console.WriteLine(String.Format("Thread {0} acquires lock B", Thread.CurrentThread.Name));
            Thread.Sleep(1000);
            lockA.WaitOne();
            Console.WriteLine(String.Format("Thread {0} acquired both locks", Thread.CurrentThread.Name));

        }


        public void runTest()
        {

            Thread t1 = new Thread(() =>
            {
                thread1();
            });

            Thread t2 = new Thread(() =>
            {
                thread2();
            });


            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

        }
    }
}

