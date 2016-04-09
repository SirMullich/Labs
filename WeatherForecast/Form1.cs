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
        readonly int actualDays = 3;
        //readonly int relevantField = 12;
        Data dt;
        Dictionary<string, List<String>> allCitiesDict = new Dictionary<string, List<string>>();


        String[] cities = new String[] { "aktau", "aktobe", "almaty", "astana", "atyrau", 
                                             "jezkazgan", "karaganda", "kokshetau", "kostanay", 
                                             "kyzylorda", "pavlodar", "petropavlovsk", "semey", 
                                             "toldykorgan", "taraz", "uralsk", "ust-kamenogorsk", "shymkent" };

        public Form1()
        {
            dt = new Data();
            dt.LoadCityData();
            InitializeComponent();
            //Task Progress = new Task(doit);

            Label[] infos = new Label[] { infoaktau, infoaktobe, infoalmaty, infoastana, infoatyrau, 
                                          infojezkazgan, infokaraganda, infokokshetau, infokostanay, 
                                          infokyzylorda, infopavlodar, infopetropavlovsk, infosemey, 
                                          infotoldykorgan, infotaraz, infouralsk, infoustkamenogorsk, infoshymkent};

            //Progress.RunSynchronously();
            //Progress.Start();

            backgroundWorker1.RunWorkerAsync();


            for (int i = 0; i < 5; i++)
            {
                infos[i].Text = String.Format("{0} / {1}", allCitiesDict[cities[i]].ElementAt(1), allCitiesDict[cities[i]].ElementAt(2));
            }
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

        private void RunWorkerAsync(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                allCitiesDict[cities[i]] = dt.LoadWeatherData(cities[i], actualDays);
                //progressBar1.PerformStep();
                //label1.Text = weatherData[1];
            }
        }
    }
}
