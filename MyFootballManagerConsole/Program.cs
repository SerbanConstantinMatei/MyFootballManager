using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyFootballManagerObjects;
using MyFootballMangerDAL;

namespace MyFootballManagerConsole
{
    class Program
    {
        private static string pathToXML = "..\\..\\..\\Data\\Data2.txt";
        private static string pathToCSV = "..\\..\\..\\Data\\Data.txt";
        //pathToCSV overwritten :(

        public static void ShowMatchList(MatchList mm)
        {
            for (int i = 0; i < mm.Count; i++)
            {
                Console.Write(mm[i].ID + " " + mm[i].Date + " " + mm[i].HomeTeam.Name + " ");
                Console.Write(mm[i].AwayTeam.Name + " " + mm[i].Result.HomeScore + " ");
                Console.Write(mm[i].Result.AwayScore);
                Console.WriteLine();
            }
        }

        public static void ShowLeaderboard (MatchList mm)
        {
            mm.SortByPoints();
            for (int i = 0; i < mm.teams.Count; i++)
            {
                Console.Write(mm.teams[i].Name + " " + mm.teams[i].ChampionshipPoints);
                Console.WriteLine(" " + mm.teams[i].GoalsScored);
            } 
        }

        public static int ReadMyInt()
        {
            string data = Console.ReadLine();
            int MyInt;
            while (!int.TryParse(data, out MyInt))
            {
                Console.WriteLine("Invalid input!");
                data = Console.ReadLine();
            }

            return MyInt;
        }

        static void Main(string[] args)
        {
            var mm = new MatchListFromMemory();
            var csvm = new MatchListFromCSV();
            string fileType = null;
            bool xml = false;

            Console.WriteLine("Is the file on hard or internet?");
            Console.WriteLine("Write 0 if on hard, 1 if on internet");
            int input = ReadMyInt();
            while ((input != 1) && (input != 0))
            {
                Console.WriteLine("Invalid input: write 0 if on hard, 1 if on internet");
                input = ReadMyInt();
            }

            if (input == 1)
            {
                Console.WriteLine("Write the url:");
                string stringUrl = Console.ReadLine();
                int i = stringUrl.Length - 2;
                for (; i >= 0; i--)
                {
                    if (stringUrl[i] == '.')
                    {
                        fileType = stringUrl.Substring(i+1);
                        break;
                    }
                }
                if (fileType.Equals("xml"))
                {
                    xml = true;
                }
                Uri uri = new Uri(stringUrl);
                WebClient webClient = new WebClient();
                //https://www.scorespro.com/rss2/live-soccer.xml

                //http://www.tutorialspoint.com/design_pattern/iterator_pattern.htm
                //https://en.wikipedia.org/wiki/Singleton_pattern

                try
                {
                    //pathToCSV = webClient.DownloadString(uri);
                    webClient.DownloadFile(uri, pathToXML);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error encountered while trying to download the file");
                }
            }

            if (xml)
            {
                MatchListFromXML mx = new MatchListFromXML();
                mx.path = pathToCSV;
                mx.LoadData();
                ShowMatchList(mx);
                ShowLeaderboard(mx);
                return;
            }
            csvm.path = pathToCSV;
            try
            {
                csvm.LoadData();
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine(e.Message);
            }

            ShowMatchList(csvm);
        }
    }
}
