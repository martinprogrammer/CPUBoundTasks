using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPUBoundTasks
{
    class Program
    {
        static  void Main(string[] args)
        {
           
            DoWork();
            
            Console.WriteLine("this should write first");
            Console.Read();
        }

        public static async void DoWork()
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            MyService myClass1 = new MyService();
            Console.WriteLine(await myClass1.WaitFor2Seconds());
            Console.WriteLine(myStopwatch.ElapsedMilliseconds);
            
            Console.Read();
        }
    }

    class MyService
    {
        public Task<DateTime> WaitFor2Seconds()
        {
            return  Task.Run(()=> {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                }
            return DateTime.Now;
                });
        }
    }

    class MyService1
    {
        public async Task<DateTime> WaitFor2Seconds()
        {

            var x = new Func<DateTime>(() => { 
              for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                }
                return DateTime.Now;
            });

            return  await Task.Run(() => x());
          
        }
    }
}
