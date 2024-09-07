using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using RocPaSors.Logic.MatchResultLogic;
using RocPaSors.Logic;
using RocPaSors.Page;

namespace RocPaSors
{
    /// <summary>
    /// Interaction logic for MatchResultWindow.xaml
    /// </summary>
    public partial class MatchResultWindow: Window
    {       
        GameMatch gameRestart = new GameMatch();
        int index1, index2, index3;
     
        public MatchResultWindow()
        {
            MatchResultContent matchResultContent = new MatchResultContent(this);
            InitializeComponent();            
            PlayerScoreTitle.Content = PlayerAction.playerName;          
        }
        public  void AddScoreBoardContent(int round, int op, int plyr, SolidColorBrush bgColor, SolidColorBrush fgColor)
        {       
            MatchResultContent matchResultContent = new MatchResultContent(this);   
            
             matchResultContent.ScoreBoardContent(round, op, plyr, bgColor, fgColor);                  
        }
        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            MatchHistory.history.ResultRow.Children.RemoveAt(index1);
            MatchHistory.history.PlyrRow.Children.RemoveAt(index2);
            MatchHistory.history.OpRow.Children.RemoveAt(index3);
            gameRestart.Show();
            this.Close();
        }
        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            
            //var data1 = MatchHistory.history.ResultRow.Children[index1];
            //var data2 = MatchHistory.history.PlyrRow.Children[index2];
            //var data3 = MatchHistory.history.OpRow.Children[index3];
            //File.WriteAllText($"{PlayerAction.playerName}.txt", PlayerAction.playerName);
            MainMenuWindow backToMainMenu = new MainMenuWindow();          
            backToMainMenu.Show();
            this.Close();
        }

        public void SendElPos(int index1, int index2, int index3)
        {
            this.index1 = index1;
            this.index2 = index2;
            this.index3 = index3;
        }
    }
}
