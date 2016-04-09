using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;

namespace WeatherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Load();

            while (true)
            {
                F4();
            }
        }

        static string[] list = new string[] { "Almaty", "Astana" };
        static Dictionary<string, string> data = new Dictionary<string, string>();

        public static object Cache { get; private set; }

        private static void F4()
        {

            //Console.OutputEncoding = Encoding.UTF8;

            string cityName = Console.ReadLine().ToLower();

            if (list.Contains(cityName))
            {
                if (!data.ContainsKey(cityName))
                {

                    string url = string.Format("http://www.kazhydromet.kz/rss-pogoda.php?id={0}", cityName);
                    XmlReader reader = XmlReader.Create(url);

                    SyndicationFeed feed = SyndicationFeed.Load(reader);

                    reader.Close();
                    StringBuilder sb = new StringBuilder();

                    foreach (SyndicationItem item in feed.Items)
                    {
                        sb.AppendLine(item.Summary.Text);

                    }

                    data[cityName] = sb.ToString();

                    Console.WriteLine("from data online");
                }
                else
                {
                    Console.WriteLine("from data offline");
                }

                Console.WriteLine(data[cityName]);
            }

        }

        private static void F3()
        {

            Console.OutputEncoding = Encoding.UTF8;

            string cityName = Console.ReadLine().ToLower();

            if (list.Contains(cityName))
            {

                string url = string.Format("http://www.kazhydromet.kz/rss-pogoda.php?id={0}", cityName);
                XmlReader reader = XmlReader.Create(url);

                SyndicationFeed feed = SyndicationFeed.Load(reader);

                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine(item.Summary.Text);
                }
            }
        }

        private static void Load()
        {
            for(int i = 0; i < list.Length; ++i)
            {
                list[i] = list[i].ToLower();
            }
        }

        private static void F2()
        {
            string name = Console.ReadLine();
            string sname = Console.ReadLine();

            string result = string.Format("My names is {0}, surname is {1}",name,sname);

            Console.WriteLine(result);
        }

        private static void F1()
        {
            Console.OutputEncoding = Encoding.UTF8;


            string url = "http://www.kazhydromet.kz/rss-pogoda.php?id=almaty";
            XmlReader reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader);

            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine(item.Summary.Text);
            }
        }
    }
}
