using MyFootballManagerObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyFootballMangerDAL
{
    public class MatchListFromCSV:MatchList
    {
        public string path { get; set; }
        public List<Team> teams = new List<Team>();
        public void LoadData()
        {
            //TODO: identify if file is on hard or on internet
            //ce se intmpla daca iti da fisierul ca
            //https://raw.githubusercontent.com/SerbanConstantinMatei/MyFootballManager/master/Data/Data.txt
            
            
            using (var reader = new StreamReader(path))
            {
                //TODO: IValidatableObject pentru randuri incorecte
                int n;
                int.TryParse(reader.ReadLine(), out n);
                while (!reader.EndOfStream) 
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Match m = new Match();

                    int id;
                    int.TryParse(values[0], out id);
                    m.ID = id;
                    //tratare erori sau ivalidatable
                    //mostenest din exception
                    int year, month, day;
                    int.TryParse(values[1], out day);
                    int.TryParse(values[2], out month);
                    int.TryParse(values[3], out year);
                    m.Date = new DateTime(year, month, day);

                    m.HomeTeam = new Team();
                    m.AwayTeam = new Team();
                    m.HomeTeam.Name = values[4];
                    m.AwayTeam.Name = values[5];

                    int score;
                    m.Result = new Score();
                    int.TryParse(values[6], out score);
                    m.Result.HomeScore = score;
                    int.TryParse(values[7], out score);
                    m.Result.AwayScore = score;

                    this.Add(m);
                }
            }
        }
    }
}
