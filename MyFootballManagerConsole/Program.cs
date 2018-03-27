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
        private static string pathToCSV = "..\\..\\..\\Data\\Data.txt";

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
                //TODO: read scores and display in program and in form
               
                //http://www.tutorialspoint.com/design_pattern/iterator_pattern.htm
                //https://en.wikipedia.org/wiki/Singleton_pattern

                try
                {
                    //pathToCSV = webClient.DownloadString(uri);
                    webClient.DownloadFile(uri, pathToCSV);
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
                //TODO: leaderboard
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
           
            for (int i = 0; i < csvm.Count; i++)
            {
                Console.Write(csvm[i].ID + " " + csvm[i].Date + " " + csvm[i].HomeTeam.Name + " ");
                Console.Write(csvm[i].AwayTeam.Name + " " + csvm[i].Result.HomeScore + " ");
                Console.Write(csvm[i].Result.AwayScore);
                Console.WriteLine();
            }
        }
    }
}
