using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"./response.json");
            var datas = JsonSerializer.Deserialize<List<data>>(json);

            int prev_y = datas[0].boundingPoly.vertices[0].y;

            for (int i= 1; i<datas.Count;i++)
            {
                int y = datas[i].boundingPoly.vertices[0].y;
                if(10 < y-prev_y)
                {
                    Console.WriteLine();
                }
                Console.Write(" "+ datas[i].description);

                prev_y = y;
            }
        }
    }

    public class data
    {
        public string description { get; set; }

        public boundingPoly boundingPoly { get; set; }

    }

    public class boundingPoly
    {
        public List<vertices> vertices { get; set; }
    }

    public class vertices
    {
        public int y { get; set; }

    }

}
