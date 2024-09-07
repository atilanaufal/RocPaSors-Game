using System;
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
using System.Windows.Shapes;
using RocPaSors.Logic.MatchResultLogic;
using RocPaSors.Page;

namespace RocPaSors
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MediaPlayer player = new MediaPlayer();
        Uri path = new Uri(@"J:\Sounds Effects\MainMenu.mp3");
        public MainMenuWindow()
        {
            InitializeComponent();
            MainMenuMusic.Source = path;
            MainMenuMusic.LoadedBehavior = MediaState.Play;
            MainMenuMusic.MediaEnded += new RoutedEventHandler(Media_Ended);

        }

        private void Start_Game(object sender, RoutedEventArgs e)
        {
            GameMatch gameStart = new GameMatch();

            MainMenuMusic.LoadedBehavior = MediaState.Stop;
            gameStart.Show();
             this.Close();
        }

        private void Exit_Game(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GoTo_MatchHistory(object sender, RoutedEventArgs e)
        {
            //MatchHistoryPage.Navigate(MatchHistory.history);
            MatchHistoryPage.Content = MatchHistory.history;
            MatchHistory.history.MainMenuName(this);
         

        }
        public void Media_Ended(object sender, EventArgs e)
        {
            MainMenuMusic.Position = TimeSpan.Zero;
            MainMenuMusic.LoadedBehavior = MediaState.Play;
        }

        private void Back_ToStartUp(object sender, RoutedEventArgs e)
        {
            StartUp startUp = new StartUp();
            startUp.Show();
            this.Close();
        }
    }
}
