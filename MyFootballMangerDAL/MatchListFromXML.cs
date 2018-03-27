using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyFootballManagerObjects;

namespace MyFootballMangerDAL
{
    public class MatchListFromXML : MatchList
    {
        public string path { get; set; }

        public void LoadData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            //TODO: Work in progress
            XmlNodeList info = xmlDoc.GetElementsByTagName("description");
            XmlNodeList infoDate = xmlDoc.GetElementsByTagName("pubDate");
            for (int i = 1; i < info.Count; i++)
            {
                Console.WriteLine("info: " + info[i].InnerText);
                Console.WriteLine("infoDate: " + infoDate[i].InnerText);
                Console.WriteLine();

                Match m = new Match();
                m.ID = i;

                string line = info[i].InnerText;
                var firstSplit = line.Split(':');
                var secondSplit = firstSplit[0].Split(' ');

                m.HomeTeam = new Team();
                m.AwayTeam = new Team();
                teams.Add(m.AwayTeam);
                teams.Add(m.HomeTeam);
                int j = 2;
                while (!secondSplit[j].Equals("vs"))
                {
                    m.HomeTeam.Name += secondSplit[j] + ' ';
                    j++;
                }
                j++;
                for (; j < secondSplit.Length; j++)
                {
                    m.AwayTeam.Name += secondSplit[j] + ' ';
                }

                m.Result = new Score();
                var nextSplit = firstSplit[1].Split(' ');
                var scoresSplit = nextSplit[1].Split('-');
                int goals;
                if(!int.TryParse(scoresSplit[0], out goals))
                {
                    throw new InvalidDataException("Invalid score!");
                }
                m.Result.HomeScore = goals;
                if(!int.TryParse(scoresSplit[1], out goals))
                {
                    throw new InvalidDataException("Invalid Score!");
                }
                m.Result.AwayScore = goals;

                line = infoDate[i].InnerText;
                var dateSplit = line.Split(' ');
                int day, month, year;

                if(!int.TryParse(dateSplit[1], out day))
                {
                    throw new InvalidDataException("Invalid day!");
                }
                if(!int.TryParse(dateSplit[3], out year))
                {
                    throw new InvalidDataException("Invalid year!");
                }

                switch (dateSplit[2])
                {
                    case "Jan":
                        month = 1;
                        break;

                    case "Feb":
                        month = 2;
                        break;

                    case "Mar":
                        month = 3;
                        break;

                    case "Apr":
                        month = 4;
                        break;

                    case "May":
                        month = 5;
                        break;

                    case "Jun":
                        month = 6;
                        break;

                    case "Jul":
                        month = 7;
                        break;

                    case "Aug":
                        month = 8;
                        break;

                    case "Sep":
                        month = 9;
                        break;

                    case "Oct":
                        month = 10;
                        break;

                    case "Nov":
                        month = 11;
                        break;

                    case "Dec":
                        month = 12;
                        break;

                    default:
                        throw new InvalidDataException("Invalid Month!");
                }

                m.Date = new DateTime(year, month, day);
                this.Add(m);
            }
        }
    }
}
