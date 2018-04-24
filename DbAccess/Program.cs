using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyFootballManagerObjects;
using MyFootballMangerDAL;

namespace DbAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sq=new SqlConnection())
            {
               
                sq.ConnectionString = @"Server=.\SQLEXPRESS;Database=MyFootballManager;Trusted_Connection=True;";
                sq.Open();
                using(var cmd = sq.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [dbo].[Score] SET[HomeScore] = 71,[AwayScore] =41 WHERE id = 1";
                    cmd.ExecuteNonQuery();
                }
                using(var cmd = sq.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT TOP (1000) [HomeScore],[AwayScore],[ID] FROM[MyFootballManager].[dbo].[Score]";
                    using(var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Score s = new Score();
                            s.AwayScore = int.Parse(rd["AwayScore"].ToString());
                            s.HomeScore = int.Parse(rd["HomeScore"].ToString());
                            Console.WriteLine(s.HomeScore + " " + s.AwayScore);
                        }
                    }
                }

                using(var cmd = sq.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT TOP (1000) [ID],[DateTIme],[ID_TeamHome],[ID_TeamAway]
      ,[ID_Score]
        FROM[MyFootballManager].[dbo].[Match]
        where id = 1";

                    using(var read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Match m = new Match();
                            m.Date = DateTime.Parse(read["DateTime"].ToString());
                            Console.WriteLine(m.Date);
                        }
                    }
                }

                MatchListFromXML mm = new MatchListFromXML();
                string url = "https://www.scorespro.com/rss2/live-soccer.xml";
                mm.path = "..\\..\\..\\Data\\Data.txt";
                Uri uri = new Uri(url);
                WebClient webClient = new WebClient();
                try
                {
                    webClient.DownloadFile(uri, mm.path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }

                mm.LoadData();
                int id_var = 200;
                for (int i = 0; i < mm.Count; i++, id_var++)
                {
                    using(var cmd = sq.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [dbo].[Score] ([HomeScore],[AwayScore],[ID]) VALUES (";
                        cmd.CommandText += mm[i].Result.HomeScore + ", " +mm[i].Result.AwayScore + ", " + id_var + ")";
                        Console.WriteLine(cmd.CommandText); 
                        cmd.ExecuteNonQuery();
                    }

                    using(var cmd = sq.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [dbo].[Team] ([ID], [Name], [ChampionshipPoints], [GoalsScored])";
                        cmd.CommandText += "VALUES (" + id_var + ", '" + mm[i].AwayTeam.Name + "', " + mm[i].AwayTeam.ChampionshipPoints;
                        cmd.CommandText += ", " + mm[i].HomeTeam.GoalsScored + ")";
                        Console.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                    }

                    int id_var2 = 2 * id_var;
                    using (var cmd = sq.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [dbo].[Team] ([ID], [Name], [ChampionshipPoints], [GoalsScored])";
                        cmd.CommandText += "VALUES (" + id_var2 + ", '" + mm[i].AwayTeam.Name + "', " + mm[i].AwayTeam.ChampionshipPoints;
                        cmd.CommandText += ", " + mm[i].AwayTeam.GoalsScored + ")";
                        Console.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = sq.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [dbo].[Match] ([ID], [DateTIme], [ID_TeamHome], [ID_TeamAway] ,[ID_Score]) ";
                        cmd.CommandText += "VALUES (" + id_var + ", " + "25/10/2017" + ", " + id_var + ",  " + id_var2 + ", " + id_var + ")";
                        Console.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
