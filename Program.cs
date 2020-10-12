using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "174.251.135.156";
            string url = "https://api.ipgeolocationapi.com/geolocate/";



               string read_str = "";
               HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url+ip);

            // read data
               request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
               using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
               using (StreamReader reader = new StreamReader(stream))
               {
                read_str = reader.ReadToEnd();
               }



            // for (int i = 0; i < filedatas.Count; i++)
            // {
            // var obj = new { IP = "79.178.108.27" };

            string result = (url + ip);
            //  var obj = JSON.parse(read_str);
            JObject o = JObject.Parse(read_str);
            Console.WriteLine(o);
            string country2 = o.GetValue("alpha3").ToString();
            Console.WriteLine(country2);
            Console.ReadLine();
                /*
        //    JObject data = JObject.Parse(result);
                JObject geo = JObject.Parse(o.GetValue("geo").ToString());
                string latitude = geo.GetValue("latitude").ToString();
                string longitude = geo.GetValue("longitude").ToString();
                string country = geo.GetValue("alpha3").ToString();
            //    filedata.LATITUDE = latitude;
            //    filedata.LONGITUDE = longitude;
                Console.WriteLine(country);
                Console.ReadLine();

                //    }
                */
             


        }


        private static void ReadCsvFile()
        {

            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"C:\IPlist.csv")), true))
            {
                csvTable.Load(csvReader);
            }
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                //   string date = DataFiles[i].Date.ToString();
                //  DataFiles.Add(new FileData { Date = csvTable.Rows[i][0].ToString(), LocationName = csvTable.Rows[i][1].ToString(), IP = csvTable.Rows[i][2].ToString() });
                DataFiles.Add(new FileData { Date = csvTable.Rows[i][0].ToString(), LocationName = csvTable.Rows[i][1].ToString(), IP = csvTable.Rows[i][2].ToString() });
                Console.WriteLine(DataFiles.ToString());
                //GetCoordinatesLocationByIP(DataFiles[i]);

            }

        }
    }
}
