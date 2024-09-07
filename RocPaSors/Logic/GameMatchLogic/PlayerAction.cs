using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media.Imaging;

namespace RocPaSors
{
    internal class PlayerAction
    {
        public static string playerName;
        public static string playerCurrentAction = "none";
        MediaPlayer player = new MediaPlayer();
        Uri path = new Uri(@"J:\Sounds Effects\PlayerAction.mp3");
        GameMatch win;       
        public PlayerAction(GameMatch win)
        {
            this.win = win;
        }
        public void ResetPlayer()
        {
            playerCurrentAction = "none";
            if (playerCurrentAction == "none")
            {
                win.Scissors1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Rock1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Paper1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors.png"));
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist.png"));
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper.png"));
            }
        }
        public void Scissor_Click(object sender, RoutedEventArgs e)
        {
            if (playerCurrentAction == "none")
            {
                playerCurrentAction = "scissor";
                win.Scissors1.Background = Brushes.Black;
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors2.png"));
                player.Open(path);
                player.Play();
            }
            else if ( playerCurrentAction == "scissor")
            {              
                playerCurrentAction = "none";
                win.Scissors1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "rock")
            {
                playerCurrentAction = "scissor";
                win.Rock1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Scissors1.Background = new SolidColorBrush(Colors.Black);
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist.png"));
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors2.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "paper")
            {
                playerCurrentAction = "scissor";
                win.Paper1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Scissors1.Background = new SolidColorBrush(Colors.Black);
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper.png"));
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors2.png"));
                player.Open(path);
                player.Play();
            }
        }
        public void Paper_Click(object sender, RoutedEventArgs e)
        {
            if (playerCurrentAction == "none")
            {
                playerCurrentAction = "paper";
                win.Paper1.Background = new SolidColorBrush(Colors.Black);
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper2.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "paper")
            {
                playerCurrentAction = "none";
                win.Paper1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "rock")
            {
                playerCurrentAction = "paper";
                win.Rock1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Paper1.Background = new SolidColorBrush(Colors.Black);
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist.png"));
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper2.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "scissor")
            {
                playerCurrentAction = "paper";
                win.Scissors1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Paper1.Background = new SolidColorBrush(Colors.Black);
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors.png"));
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper2.png"));
                player.Open(path);
                player.Play();
            }
        }
        public void Rock_Click(object sender, RoutedEventArgs e)
        {
            if (playerCurrentAction == "none")
            {
                playerCurrentAction = "rock";
                win.Rock1.Background = new SolidColorBrush(Colors.Black);
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist2.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "rock")
            {
                playerCurrentAction = "none";
                win.Rock1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "paper")
            {
                playerCurrentAction = "rock";
                win.Paper1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Rock1.Background = new SolidColorBrush(Colors.Black);
                win.plyrppr.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\hand-paper.png"));
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist2.png"));
                player.Open(path);
                player.Play();
            }
            else if (playerCurrentAction == "scissor")
            {
                playerCurrentAction = "rock";
                win.Scissors1.Background = new SolidColorBrush(Colors.WhiteSmoke);
                win.Rock1.Background = new SolidColorBrush(Colors.Black);
                win.plyrsci.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\scissors.png"));
                win.plyrrck.Source = new BitmapImage(new Uri("J:\\Icon\\RocPaSors\\fist2.png"));
                player.Open(path);
                player.Play();
            }
        }
    }    
}
