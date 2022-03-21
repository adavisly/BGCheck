using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsTask
{
    class KeyPressing
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                char key = Console.ReadKey().KeyChar;
                OnKeyPressed?.Invoke(this, key);
                exit = char.ToLower(key) == 'c' ? true : false;
            }
        }
    }
}
