using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ServerPing
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> ips = new List<string>();
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
