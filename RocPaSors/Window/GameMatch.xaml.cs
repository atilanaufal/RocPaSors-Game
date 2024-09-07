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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RocPaSors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    
    public partial class GameMatch
    {
        MatchCounter matchCounter;
        PlayerAction playerAction;
        OpponentAction opponentAction;
        
        public GameMatch()
        {
            playerAction = new PlayerAction(this);
            matchCounter = new MatchCounter(this);
            opponentAction = new OpponentAction(this);

            InitializeComponent();
            plyrName.Text = PlayerAction.playerName;
            if (PlayerAction.playerName.Equals("Jenderal Hamonangan", StringComparison.OrdinalIgnoreCase))
            {
                plyrName.Background = Brushes.ForestGreen;
                plyrName.Foreground = Brushes.PaleGreen;
                plyrName.Padding = new Thickness(20,5,20,5);

            }
            Scissors1.AddHandler(Button.ClickEvent, new RoutedEventHandler(playerAction.Scissor_Click));
            Paper1.AddHandler(Button.ClickEvent, new RoutedEventHandler(playerAction.Paper_Click));
            Rock1.AddHandler(Button.ClickEvent, new RoutedEventHandler(playerAction.Rock_Click));
        }
        private void Start_Round(object sender, RoutedEventArgs e) 
        {
            if (PlayerAction.playerCurrentAction != "none") 
            {              
                GamesLogic gamesLogic = new GamesLogic(this);             
                if (PlayerAction.playerName.Equals("Jenderal Hamonangan", StringComparison.OrdinalIgnoreCase))
                {
                    gamesLogic.gamesCheatWin();
                } 
                else
                {
                    opponentAction.OpponentLogic();
                    gamesLogic.gamesLogicWin();
                    gamesLogic.gamesLogicDraw();
                    gamesLogic.gamesLogicLose();
                }
            }
            else if (MatchCounter.roundCounter == 6) { }    
        }
        private void Exit_Match(object sender, RoutedEventArgs e)
        {
            MainMenuWindow backToMainMenu = new MainMenuWindow();
            opponentAction.ResetOpponent();
            playerAction.ResetPlayer();
            matchCounter.ResetAllCounter();
            backToMainMenu.Show();
            this.Close();
        }

        private void Press_Key(object sender, KeyEventArgs e)
        {
            if (NextRoundBtn.Visibility == Visibility.Collapsed)
            {
                if (e.Key == Key.D1) playerAction.Rock_Click(sender, e);
                else if (e.Key == Key.D2) playerAction.Paper_Click(sender, e);
                else if (e.Key == Key.D3) playerAction.Scissor_Click(sender, e);
            }            
            if (e.Key == Key.Enter)
            {
                if (NextRoundBtn.Visibility == Visibility.Visible) NextRoundBtn.Focus();                                 
                else Start_Round(sender, e);      
            }

        }
    }   
}
