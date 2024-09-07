using System.Windows.Media;
using System.Windows.Controls;
using System;

namespace RocPaSors
{
    internal class GamesLogic
    {
        MatchCounter matchCounter;
        RoundResult roundResult;
        GameMatch win;
        public GamesLogic(GameMatch win)
        {
            this.win = win;
            matchCounter = new MatchCounter(win);
            roundResult = new RoundResult(win);
        }
        public void gamesLogicWin()
        {           
            if (OpponentAction.opponentCurrentAction == "scissor" && PlayerAction.playerCurrentAction == "rock")
            {
                matchCounter.startPlayerCounter();
                roundResult.AddRoundResult(Brushes.ForestGreen, Brushes.PaleGreen, "You Win");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundWin.mp3"));
            }
            else if (OpponentAction.opponentCurrentAction == "rock" && PlayerAction.playerCurrentAction == "paper")
            {
                matchCounter.startPlayerCounter();
                roundResult.AddRoundResult(Brushes.ForestGreen, Brushes.PaleGreen, "You Win");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundWin.mp3"));
            }
            else if (OpponentAction.opponentCurrentAction == "paper" && PlayerAction.playerCurrentAction == "scissor")
            {
                matchCounter.startPlayerCounter();
                roundResult.AddRoundResult(Brushes.ForestGreen, Brushes.PaleGreen, "You Win");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundWin.mp3"));
            }
            
        }
        public void gamesLogicDraw()
        {
            if (OpponentAction.opponentCurrentAction == "scissor" && PlayerAction.playerCurrentAction == "scissor")
            {
                roundResult.AddRoundResult(Brushes.LightGray, Brushes.DarkSlateGray, "Tie");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundTie.mp3"));
            }
            else if (OpponentAction.opponentCurrentAction == "rock" && PlayerAction.playerCurrentAction == "rock")
            {
                roundResult.AddRoundResult(Brushes.LightGray, Brushes.DarkSlateGray, "Tie");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundTie.mp3"));
            }
            else if (OpponentAction.opponentCurrentAction == "paper" && PlayerAction.playerCurrentAction == "paper")
            {
                roundResult.AddRoundResult(Brushes.LightGray, Brushes.DarkSlateGray, "Tie");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundTie.mp3"));
            }
            
        }
        public void gamesLogicLose()
        {
            if (OpponentAction.opponentCurrentAction == "rock" && PlayerAction.playerCurrentAction == "scissor")
            {
                matchCounter.startOpponentCounter();
                roundResult.AddRoundResult(Brushes.DarkRed, Brushes.Red, "You Lose");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundLose.mp3"));
            }
            else if (OpponentAction.opponentCurrentAction == "paper" && PlayerAction.playerCurrentAction == "rock")
            {
                matchCounter.startOpponentCounter();
                roundResult.AddRoundResult(Brushes.DarkRed, Brushes.Red, "You Lose");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundLose.mp3"));
            }
            else if (OpponentAction.opponentCurrentAction == "scissor" && PlayerAction.playerCurrentAction == "paper")
            {
                matchCounter.startOpponentCounter();
                roundResult.AddRoundResult(Brushes.DarkRed, Brushes.Red, "You Lose");
                RoundSound(new Uri(@"J:\Sounds Effects\RoundLose.mp3"));
            }
            
        }
        public void gamesCheatWin()
        {
            if (PlayerAction.playerCurrentAction == "rock")
            {
                OpponentAction.opponentCurrentAction = "scissor";
                win.Scissors2.Background = new SolidColorBrush(Colors.Red);
                matchCounter.startPlayerCounter();
                roundResult.AddRoundResult(Brushes.ForestGreen, Brushes.PaleGreen, "You Win");
            }
            else if (PlayerAction.playerCurrentAction == "paper")
            {
                OpponentAction.opponentCurrentAction = "rock";
                win.Rock2.Background = new SolidColorBrush(Colors.Red);
                matchCounter.startPlayerCounter();
                roundResult.AddRoundResult(Brushes.ForestGreen, Brushes.PaleGreen, "You Win");
            }
            else if (PlayerAction.playerCurrentAction == "scissor")
            {
                OpponentAction.opponentCurrentAction = "paper";
                win.Paper2.Background = new SolidColorBrush(Colors.Red);
                matchCounter.startPlayerCounter();
                roundResult.AddRoundResult(Brushes.ForestGreen, Brushes.PaleGreen, "You Win");
            }

        }
        private void RoundSound(Uri path) 
        {
            win.RoundSound.Source = path;
            win.RoundSound.LoadedBehavior = MediaState.Play;
        }
    }
}
