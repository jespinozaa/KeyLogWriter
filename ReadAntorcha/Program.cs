using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadAntorcha
{
    class Program
    {
        static  void  Main(string[] args)
        {

            var x = antorchaReader();
        }


         public static async Task antorchaReader()
        {
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher(".");
            fsw.Filter = @"C:\Users\jespinoza\Desktop\AntorchaConsola\AntorchaConsola\bin\Debug";
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();

            var fs = new FileStream(@"C:\Users\jespinoza\Desktop\AntorchaConsola\AntorchaConsola\bin\Debug\log.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var sr = new StreamReader(fs))
            {
                var s = "";
                while (true)
                {
                    s = sr.ReadLine();
                    if (s != null)
                    {
                        //await .Channel.SendMessage(s);
                        Console.WriteLine("Transmitting: " + s);
                        wh.WaitOne(1000);
                    }
                    else
                    {
                        Console.WriteLine("Sleeping...");
                        wh.WaitOne(1000);
                    }
                  
                }
            }

            wh.Close();
        }
    }
}
