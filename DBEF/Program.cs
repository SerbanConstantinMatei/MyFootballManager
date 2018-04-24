using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db=new Model1())
            {
                var Scores1 = db.Score;
                var Scores=Scores1.ToArray();
                foreach (var Score in Scores)
                {
                    Console.WriteLine(Score.HomeScore + " " + Score.AwayScore);
                }

                var m1 = db.Match.Where(it => it.ID == 1);
                var m=m1.FirstOrDefault();
                Console.WriteLine(m.DateTIme);
                Console.WriteLine(m.Team.Name + " " + m.Team1.Name);


                var s = db.Score.Where(it => it.ID == 1).FirstOrDefault();
                s.HomeScore = 4;
                s.AwayScore = 0;
                db.SaveChanges();
            }
        }
    }
}
