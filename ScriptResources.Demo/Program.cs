using System;

namespace ScriptResources.Demo
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Hello Script Resources", Database.Default.Query());
        }
    }
}
