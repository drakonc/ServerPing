using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

namespace ServerPing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var ips = ConfigurationManager.AppSettings["lips"];
            List<string> Lista_Ip = ips.Split('|').ToList();

            clPing p = new clPing();
            p.EscribirArchivo(Lista_Ip);

            Lista_Ip.ForEach(ip =>
            {
                Console.WriteLine(ip);
            });

            Console.ReadLine();

        }
    }
}
