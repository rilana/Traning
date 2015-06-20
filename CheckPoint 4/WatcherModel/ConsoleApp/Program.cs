using System;
using FillFolderInDatabase;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watcherFolder=new WatcherFolder(@"C:\Наташа");
            watcherFolder.Run();
            Console.ReadKey();
        }
    }
}
