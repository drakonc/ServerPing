using System;
using System.IO;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace ServerPing
{
    public class clPing
    {
        public void EscribirArchivo(List<string> ips)
        {
            string path = Directory.GetCurrentDirectory();
            string name = "ping_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt";
            string txt = path + @"\" + name;
            string salto = "\n";
            string header = "";

            using (StreamWriter escribe = new StreamWriter(txt))
            {
                for (int i = 0; i < ips.Count; i++)
                {
                    header = "<--------------PING: " + ips[i] + "--------------><br>";
                    List<string> respuesta = SimplePing(ips[i]);
                    escribe.WriteLine(header);

                    if (respuesta != null)
                    {
                        for (int j = 0; j < respuesta.Count; j++)
                        {
                            escribe.Write(respuesta[j].ToString());
                        }
                    }
                    else
                    {
                        escribe.Write("La IP: " + ips[i] + "Es Inalcansable<br>");
                    }

                    escribe.WriteLine(salto);
                }                

                escribe.WriteLine(salto);
            }

        }

        public List<string> SimplePing(string ip)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply;
                string cadena = "";
                List<string> respuesta = new List<string>();

                    for (int i = 0; i < 4; i++)
                    {
                        reply = pingSender.Send(ip);
                        cadena += "IP: " + reply.Address.ToString() + " bytes: " + reply.Buffer.Length.ToString() + " tiempo: " + reply.RoundtripTime.ToString() + "ms TTL: " + reply.Options.Ttl.ToString() + "<br>" + Environment.NewLine;
                        respuesta.Add(cadena);
                        cadena = "";
                    }

                return respuesta;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
