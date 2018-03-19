﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFootballMangerDAL;

namespace MyFootballManagerForms
{

    public partial class Form1 : Form
    {
        MatchListFromMemory mm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var mm = new MatchListFromMemory();
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
            //TODO How to show this form on click?
            mm.LoadData();
            mm.SortByPoints();
            //missing something...?
            LF.ShowDialog(this);
        }
    }
}
