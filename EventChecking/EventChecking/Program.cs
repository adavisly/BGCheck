using System;

namespace EventChecking
{
    class Program
    {
       
        static void Main(string[] args)
        {
            SampleWorker sc = new SampleWorker();
            sc.Work();
        }

    }

    public class SampleWorker
    {
        public event EventHandler<Exception> OnError;
        public event EventHandler OnPercentageChange;

        public void Work()
        {
            var currentPercent = 0;
            try
            {
                OnPercentageChange?.Invoke(this, new WorkerEventArgs(currentPercent));
                Console.WriteLine("aaa");
                currentPercent = 100;
                OnPercentageChange?.Invoke(this, new WorkerEventArgs(currentPercent));
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }
        }
        /*
        public void TestExampleWork()
        {
            try
            {
                int a = 5;
                int b = 0;
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex.Message);
                }
            }
        }
        */
    }

    public class SomeSubscriberClass
    {
        public void SomeMethod()
        {
            var worker = new SampleWorker();
            worker.OnError += LogError;
            worker.OnPercentageChange += LogInfo;

            worker.Work();
        }

        public void LogError(object sender, Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        public void LogInfo(object sender, EventArgs args)
        {
            Console.WriteLine((WorkerEventArgs)args.WorkPercent);
        }
    }

    public class WorkerEventArgs : EventArgs
    {
        public int WorkPercent { get; }
        public WorkerEventArgs(int workPercent)
        {
            WorkPercent = workPercent;
        }
    }
}
