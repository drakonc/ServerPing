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
            var ips = ConfigurationSettings.AppSettings["lips"];
            List<string> Lista_Ip = ips.Split('|').ToList();

            //Lista_Ip.ForEach(a =>
            //{
            //    Console.WriteLine(a);
            //});
            //Console.ReadLine();

            clPing p = new clPing();
            p.EscribirArchivo(Lista_Ip);

        }
    }
}
