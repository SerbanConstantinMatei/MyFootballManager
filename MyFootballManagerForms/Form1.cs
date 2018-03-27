using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFootballMangerDAL;

namespace MyFootballManagerForms
{

    public partial class Form1 : Form
    {
        MatchListFromXML mm;
        private string path = "..\\..\\..\\Data\\Data.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //mm = new MatchListFromMemory();
            mm = new MatchListFromXML();
            string url = "https://www.scorespro.com/rss2/live-soccer.xml";
            mm.path = path;
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

            var dataArr = mm.Select(it => new DisplayMatch()
            {
                Id = it.ID,
                HomeTeamDisplay = it.HomeTeam.Name,
                AwayTeamDisplay = it.AwayTeam.Name,
                HomeScoreDisplay = it.Result.HomeScore,
                AwayScoreDisplay = it.Result.AwayScore
            }).ToArray();
            dgMatches.DataSource = dataArr;
        }

        private void BtnLeaderboard_Click(object sender, EventArgs e)
        {
            LeaderboardForm LF = new LeaderboardForm();
            LF.Llist = mm;
            
            LF.ShowDialog(this);
        }

        private void btnWinner_Click(object sender, EventArgs e)
        {
            var winnerList = mm.Winners();
            var list = winnerList.ToList();
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            winnerList = list.ToArray();
            string winner = "";
            for (int i = 0; i < winnerList.Length; i++)
            {
                winner += winnerList[i].Name + ' ' + winnerList[i].ChampionshipPoints + Environment.NewLine;
            }

            MessageBox.Show(winner);
        }

        private void Loser_Click(object sender, EventArgs e)
        {
            var loserList = mm.Losers();
            var list = loserList.ToList();
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            loserList = list.ToArray();
            string loser = "";
            for (int i = 0; i < loserList.Length; i++)
            {
                loser += loserList[i].Name + ' ' + loserList[i].ChampionshipPoints + Environment.NewLine;
            }
            MessageBox.Show(loser);
        }
    }
}
