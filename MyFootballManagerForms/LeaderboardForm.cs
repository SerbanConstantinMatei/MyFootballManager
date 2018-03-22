﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFootballManagerObjects;

namespace MyFootballManagerForms
{
    public partial class LeaderboardForm : Form
    {
        public MatchList Llist;
        public LeaderboardForm()
        {
            InitializeComponent();
        }

        private void LeaderboardForm_Load(object sender, EventArgs e)
        {
            Llist.SortByPoints();
            matchListBindingSource.DataSource = Llist;
        }
    }
}
