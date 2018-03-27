using MyFootballManagerObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyFootballMangerDAL
{
    public class MatchListFromCSV: MatchList
    {
        public string path { get; set; }
        //public List<Team> teams = new List<Team>();
        public void LoadData()
        {
            //ce se intmpla daca iti da fisierul ca
            //https://raw.githubusercontent.com/SerbanConstantinMatei/MyFootballManager/master/Data/Data.txt

            int row = 1;
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream) 
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Match m = new Match();

                    int id;
                    if(!int.TryParse(values[0], out id))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid ID!");
                    }
                    m.ID = id;
                    int year, month, day;
                    if (!int.TryParse(values[1], out day))
                    {                                            
                        throw new InvalidDataException("[Row " + row + "]: Inavlid date - inavlid day");
                    }

                    if(!int.TryParse(values[2], out month))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid date - invalid month");
                    }

                    if(!int.TryParse(values[3], out year))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid date - invalid year");
                    }

                    //Checking if the date is valid
                    if ((year > 2018) || (year < 1950))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid date - invalid year");
                    }

                    if ((month < 1) || (month > 12))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid date - invalid month");
                    }
                        
                    if ((day < 1) || (day > 31))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Inavlid date - inavlid day");
                    }

                    if (((month == 2) || (month == 4) || (month == 6) || (month == 9) ||
                        (month == 11)) && (day == 31))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Inavlid date - inavlid day");
                    } 

                    if ((month == 2) && (year % 4 == 0) && (day > 29))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Inavlid date - inavlid day");
                    }

                    if ((month == 2) && (day > 28))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Inavlid date - inavlid day");
                    }
                    m.Date = new DateTime(year, month, day);

                    m.HomeTeam = new Team();
                    m.AwayTeam = new Team();
                    m.HomeTeam.Name = values[4];
                    m.AwayTeam.Name = values[5];

                    int score;
                    m.Result = new Score();
                    if(!int.TryParse(values[6], out score))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid score");
                    }
                    m.Result.HomeScore = score;
                    if (!int.TryParse(values[7], out score))
                    {
                        throw new InvalidDataException("[Row " + row + "]: Invalid score");
                    }
                    m.Result.AwayScore = score;

                    row++;
                    this.Add(m);
                }
            }
        }
    }
}
