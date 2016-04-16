using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherForecast.Models;

namespace WeatherForecast
{
	public partial class Form1 : Form
	{
		int day;
        int dayNight;
		Data dt;
		Dictionary<string, List<String>> allCitiesDict = new Dictionary<string, List<string>>();
        Label[] infos;
        String[] cityNames;

		public Form1()
		{
			dt = new Data();
            day = 0;
            dayNight = 0;

			InitializeComponent();
			//Task Progress = new Task(doit);

            cityNames = new string[] { "aktau", "aktobe", "almaty", "astana", "atyrau", 
											 "jezkazgan", "karaganda", "kokshetau", "kostanay", 
											 "kyzylorda", "pavlodar", "petropavlovsk", "semey", 
											 "toldykorgan", "taraz", "uralsk", "ust-kamenogorsk", "shymkent" };

			infos = new Label[] { infoaktau, infoaktobe, infoalmaty, infoastana, infoatyrau, 
										  infojezkazgan, infokaraganda, infokokshetau, infokostanay, 
										  infokyzylorda, infopavlodar, infopetropavlovsk, infosemey, 
										  infotoldykorgan, infotaraz, infouralsk, infoustkamenogorsk, infoshymkent};
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            DayChanged(this, new EventArgs());

            //foreach (var item in dt.LoadWeatherDataRSS("karaganda", 3))
            //{
            //    label1.Text += item + Environment.NewLine;
            //}

            //label1.Text = dt.LoadWeatherData("almaty", 1).Count.ToString();

			//for (int i = 0; i < 2; i++)
			//{
			//    infos[i].Text = String.Format("{0} / {1}", allCitiesDict[cities[i]].ElementAt(1), allCitiesDict[cities[i]].ElementAt(2));
			//}
		}

		private void doit()
		{

			// For Test
			//foreach (var str in dt.LoadWeatherData("almaty", actualDays))
			//{
			//    label1.Text += str + Environment.NewLine;
			//}
			//for (int i = 0; i < cities.Count(); i++)
			//{
			//    allCitiesDict[cities[i]] = dt.LoadWeatherData(cities[i], actualDays);
			//    //progressBar1.PerformStep();
			//    //label1.Text = weatherData[1];
			//}

        }

        private void DayChanged(object sender, EventArgs e)
        {
            day = listBox1.SelectedIndex;

            DateTime date = DateTime.Parse(dt.GetRecord("almaty", day)[6].ToString());
            date = date.AddDays(day);
            labelTitle.Text = "Прогноз Погоды на " + date.ToString("dd.MM.yyyy");

            object[] objArr;
            for (int i = 0; i < infos.Length; i++)
            {
                objArr = dt.GetRecord(cityNames[i], day);
                infos[i].Text = String.Format("{0} / {1}", objArr[2 + 2 * dayNight], objArr[3 + 2 * dayNight]);
            }
            
        }

        private void DayNightChanged(object sender, EventArgs e)
        {
            dayNight = listBox2.SelectedIndex;
            DayChanged(sender, e);
        }
	}
}
