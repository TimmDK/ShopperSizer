using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace UDP_ClientBroad
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpReceiver = new UdpClient(7000);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7000);
            Console.WriteLine("Receiver is blocked");

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://anbo-bookstorerest.azurewebsites.net/api/Books/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            int i = 0;



            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("Recived: " + receivedData.ToString());

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://shoppersizerrest.azurewebsites.net/api/");
                        //client.BaseAddress = new Uri("https://localhost:44375/api/livenumber/");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        string stringToSend = "{\"number\":" + int.Parse(receivedData) + "}";

                        var response = client.PutAsync("LiveNumber/1", new StringContent(stringToSend, Encoding.UTF8, "application/json")).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                            //Console.WriteLine(stringToSend);
                            //Console.WriteLine(response.StatusCode);
                            //Console.WriteLine(response.RequestMessage);
                        }

                        if (i >= 2)
                        {
                            var result = client.GetAsync("LiveNumber/1");
                            var toSend = result.Result.Content.ReadAsStringAsync().Result;
                            var st = toSend.Split(':').Last().Split('}').First();
                            //Console.WriteLine(st);
                            var response2 = client.PostAsync("datasets",new StringContent(st));
                            //new StringContent(result.ToString())
                            if (response2.IsCompletedSuccessfully)
                            {
                                Console.Write("Success");
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                            i = 0;
                        }
                        i++;

                    }


                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
