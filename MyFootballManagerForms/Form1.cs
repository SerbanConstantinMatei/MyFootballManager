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
    public class DisplayMatch
    {
        public int Id { get; set; }
        public string HomeTeamDisplay { get; set; }

    }
    public partial class Form1 : Form
    {
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
                HomeTeamDisplay = it.HomeTeam.Name
            }).ToArray();

            dgMatches.DataSource = dataArr;
        }
    }
}
