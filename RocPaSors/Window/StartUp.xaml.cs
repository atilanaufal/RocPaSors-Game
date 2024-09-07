using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Policy;
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
using System.Windows.Threading;
using RocPaSors.Page;
using System.IO;

namespace RocPaSors
{
    /// <summary>
    /// Interaction logic for StartUp.xaml
    /// </summary>
    public partial class StartUp
    {
  
        NameBox nameBox = new NameBox();
        ExitBox exitBox = new ExitBox();
        public MediaPlayer player = new MediaPlayer();
        Uri path = new Uri(@"J:\Sounds Effects\StartUpMusic2.mp3");
        //private readonly DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.021) };
        public StartUp()
        {
            
            InitializeComponent();
            //File.Create($"{PlayerAction.playerName}.txt");
            //PlayerAction.playerName = File.ReadAllText($"{PlayerAction.playerName}.txt");
            StartUpMusic.Source = path;           
            StartUpMusic.LoadedBehavior = MediaState.Play;
            StartUpMusic.MediaEnded += new RoutedEventHandler(Media_Ended);
        }
        private void StartUp_Btn()
        {
            if (!string.IsNullOrWhiteSpace(PlayerAction.playerName)) 
            {
                MainMenuWindow mainMenu = new MainMenuWindow();
                mainMenu.Show();
                this.Close();
            }
            else 
            {
                NameBox.Content = nameBox;
                StartText.Visibility = Visibility.Collapsed;
                nameBox.StartUpName(this);
            }
                     
        }
        private void Exit_Btn()
        {            
            NameBox.Content = exitBox;
            StartText.Visibility = Visibility.Collapsed;
            exitBox.StartUpName(this);           
        }
        private void Press_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) StartUp_Btn();
            else if (e.Key == Key.Escape) Exit_Btn();
        }

      
        public void Media_Ended(object sender, EventArgs e)
        {
            StartUpMusic.Position = TimeSpan.Zero;            
            StartUpMusic.LoadedBehavior = MediaState.Play;
        }
    }
}
