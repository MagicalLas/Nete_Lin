using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main() {
            using (var host = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                new LasModules();
                Console.ReadLine();
                host.Stop();
            }

        }
    }
}
