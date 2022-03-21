using System;

namespace EventsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyPressing keyP = new KeyPressing();

            keyP.OnKeyPressed += (sender, key) => Console.WriteLine("\nВы нажали на символ " + key);
            keyP.Run();
        }
    }
}
