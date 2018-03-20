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
            mm.LoadData();
            mm.SortByPoints();
            Console.WriteLine(mm.Count);
            for (int i = 0; i < mm.Count; i++)
            {
                Console.WriteLine(" ");
                Console.Write(mm[i].ID);
                Console.Write(" ");
                Console.Write(mm[i].Date);
                Console.Write(" ");
                Console.Write(mm[i].HomeTeam.Name);
                Console.Write(" ");
                Console.Write(mm[i].AwayTeam.Name);
                Console.Write(" ");
                Console.Write(mm[i].Result.HomeScore);
                Console.Write(" ");
                Console.Write(mm[i].Result.AwayScore);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write("Leaderboard:");

            for (int i = 1; i <= mm.teams.Count; i++)
            {
                Console.WriteLine(" ");
                Console.Write(i + ". " + mm.teams[i - 1].Name + " " + mm.teams[i - 1].ChampionshipPoints);
                Console.Write("pts " + mm.teams[i - 1].GoalsScored + " goals");
            }
            Console.WriteLine();
            Console.WriteLine();

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
                Uri uri = new Uri(stringUrl);
                WebClient webClient = new WebClient();
                try
                {
                    webClient.DownloadFile(uri, pathToCSV);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error encountered while trying to download the file");
                }
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
