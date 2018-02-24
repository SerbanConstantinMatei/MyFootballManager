using System;

namespace MyFootballManagerObjects
{
    public class Match
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Result { get; set; }
    }
}
