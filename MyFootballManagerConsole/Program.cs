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
            Console.WriteLine($"nr matche{mm.Count}");
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

            }

        }
    }
}
