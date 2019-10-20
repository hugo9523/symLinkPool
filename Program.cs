using System;
using System.Runtime.InteropServices;
using System.IO;
namespace netCore
{
    class Program
    {
               static void Main(string[] args)
        {
            

            Watcher mwatcher= new Watcher(@"C:\Users\Prexun\Documents",@"C:\Users\Prexun\Documents\Symlinks");
            mwatcher.Run();
            /*file mfile= new file();
            
            mfile.printHello();*/
            //Console.WriteLine("Hello World!");
        }
    }
}
