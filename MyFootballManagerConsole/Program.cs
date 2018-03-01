using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFootballMangerDAL;

namespace MyFootballManagerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mm = new MatchListFromMemory();
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

            Console.WriteLine(" ");

            for (int i = 1; i <= mm.teams.Count; i++)
            {
                Console.WriteLine(" ");
                Console.Write(i + ". " + mm.teams[i - 1].Name + " " + mm.teams[i - 1].GoalsScored);
            }
            Console.WriteLine(" ");
        }
    }
}
