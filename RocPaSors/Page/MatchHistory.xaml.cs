﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RocPaSors.Page
{
    /// <summary>
    /// Interaction logic for MatchHistory.xaml
    /// </summary>
    /// 
   
    public partial class MatchHistory 
    {
        MainMenuWindow? win;
        public static MatchHistory history = new MatchHistory();
        public MatchHistory()
        {
            InitializeComponent();
            PlayerScoreTitle.Content = PlayerAction.playerName;
        }


        private void GoTo_MainMenu(object sender, RoutedEventArgs e)
        {      
            win.MatchHistoryPage.Content = null;
        }

        public void MainMenuName(MainMenuWindow win) => this.win = win;
    }
}
