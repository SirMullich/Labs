using System;
using System.Collections.Generic;
//using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherForecast.Models
{
    class Data
    {
        List<String> cityNames;
        Dictionary<string, string> data;

        public Data()
        {
            cityNames = new List<string>();
            data = new Dictionary<string, string>();
        }

        public void LoadCityData() 
        {
            cityNames.AddRange(new string[] {"Almaty", "Astana", "Aktau"});
            for(int i = 0; i < cityNames.Count; ++i)
            {
                cityNames[i] = cityNames[i].ToLower();
            }
        }

        public List<String> LoadWeatherData(string city, int count)
        {
            string url = string.Format("http://www.kazhydromet.kz/rss-pogoda.php?id={0}", city);
            XmlReader reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader);

            reader.Close();
            StringBuilder sb = new StringBuilder();

            List<String> summaryList = new List<string>();
            int i = 0;
            foreach (SyndicationItem item in feed.Items)
            {
                if (i < count)
                {
                    string summary = item.Summary.Text;
                    string[] delimeters = new string[] {" ", ".."};
                    summaryList.AddRange(summary.Split(delimeters, StringSplitOptions.RemoveEmptyEntries));

                    i++;
                }
                else
                {
                    break;
                }
            }
            return summaryList;
        }

    }
}
