using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
//using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WeatherForecast.Models
{
	class Data
	{
		// Список городов
		List<string> cityNames;


		DatabaseConnection objConnect;
		string conString;

		DataSet ds;
		DataRow dRow;

		int maxRows;

		int inc = 0;


		// Создаем соединение с БД WeatherDB
		public Data()
		{
			cityNames = new List<string>() { "aktau", "aktobe", "almaty", "astana", "atyrau", 
											 "jezkazgan", "karaganda", "kokshetau", "kostanay", 
											 "kyzylorda", "pavlodar", "petropavlovsk", "semey", 
											 "toldykorgan", "taraz", "uralsk", "ust-kamenogorsk", "shymkent" };


			// Создаем соединение с БД WeatherDB
			try
			{
				objConnect = new DatabaseConnection();

				// ConnectionString from properties
				conString = Properties.Settings.Default.WeatherDBConnectionString;

				objConnect.ConnectionString = conString;
				objConnect.Sql = Properties.Settings.Default.SQL;

				ds = objConnect.GetConnection;
				maxRows = ds.Tables[0].Rows.Count;

				//NavigateRecords();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		/// <summary>
		/// Gets data for city and the day number. Checks if data is relevant. It data is older than 5 minutes, connects to Internet.
		/// </summary>
		/// <param name="city">city name</param>
		/// <param name="day">today = 0, tomorrow = 1, the day after tomorrow = 2</param>
		/// <returns>array of objects</returns>
		public object[] GetRecord(string city, int day)
		{
			DataRow row = ds.Tables[0].Rows[3 * cityNames.IndexOf(city) + day];

			// If current time and DB time difference is bigger than 1 minute or it's null, then connect to Internet
			if ( String.IsNullOrWhiteSpace( row.ItemArray[6].ToString() ))
			{
				LoadWeatherDataRSS(city, 3);
                MessageBox.Show("Connected to Internet. Updating data for: " + city);
			}

			row = ds.Tables[0].Rows[3 * cityNames.IndexOf(city) + day];
            //foreach (var item in row.ItemArray)
            //{
            //    MessageBox.Show(item.ToString());
            //}
			//MessageBox.Show(row.ItemArray[2].GetType().ToString());
			// Почему пустой????
			//MessageBox.Show(dRow.ItemArray[8].ToString());
			DateTime timeDB = DateTime.Parse( row.ItemArray[6].ToString() );
            //MessageBox.Show(timeDB.ToString());

			if ((DateTime.Now - timeDB).TotalMinutes > 5)
			{
				LoadWeatherDataRSS(city, 3);
                MessageBox.Show("Connected to Internet. Updating data for: " + city);
			}
			return row.ItemArray;
		}


		// Грузим данные из интернета для города city и count дней и записываем в БД
		public void LoadWeatherDataRSS(string city, int count)
		{
			

            try
            {
                string url = string.Format("http://www.kazhydromet.kz/rss-pogoda.php?id={0}", city);
                XmlReader reader = XmlReader.Create(url);

                SyndicationFeed feed = SyndicationFeed.Load(reader);

                reader.Close();
                StringBuilder sb = new StringBuilder();

                List<String> summaryList = new List<string>();
                int i = 0;

                // feed.Items содержит коллекцию температур на 5 дней
                foreach (SyndicationItem item in feed.Items)
                {
                    if (i < count)
                    {
                        string summary = item.Summary.Text;
                        string[] delimeters = new string[] { " ", ".." };
                        summaryList.AddRange(summary.Split(delimeters, StringSplitOptions.RemoveEmptyEntries));
                        string[] splitedSummary = summary.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

                        DataRow row = ds.Tables[0].Rows[3 * cityNames.IndexOf(city) + i];
                        //MessageBox.Show(row.ItemArray[1].ToString());
                        //DataRow row = ds.Tables[0].Rows[0];


                        //foreach (var it in row.ItemArray)
                        //{
                        //    MessageBox.Show(it.ToString());
                        //}


                        // Для каждого дня 15 значений в splitedSummary

                        // Day condition
                        //row[4] = splitedSummary[3];

                        // Night condition
                        //row[7] = splitedSummary[7];

                        // Time (time of update)
                        row[6] = DateTime.Now;


                        try
                        {
                            // Day temperature (low, high)
                            row[2] = splitedSummary[1];
                            row[3] = splitedSummary[2];

                            if (splitedSummary[3] == "<br>Ночь")
                            {
                                row[4] = splitedSummary[4];
                                row[5] = splitedSummary[5];
                            }
                            else
                            {
                                row[4] = splitedSummary[5];
                                row[5] = splitedSummary[6];
                            }
                        }
                        catch (FormatException e)
                        {
                            MessageBox.Show(e.Message);
                        }

                        try
                        {
                            objConnect.UpdateDatabase(ds);
                            //MessageBox.Show("Record updated");
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        i++;
                    }
                    else
                    {
                        break;
                    }
                } 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw new ArgumentNullException();
                
            }

		}

	}
}
