using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;
using RocPaSors.Logic.MatchResultLogic;
using RocPaSors.Page;
using System.Linq;

namespace RocPaSors
{
    internal class RoundResult
    {
        GameMatch? win;
        MatchCounter matchCounter;
        PlayerAction playerAction;
        OpponentAction opponentAction;
        Button nextRoundBtn;
        MatchResultWindow matchResult = new MatchResultWindow();
        SolidColorBrush bgColor;
        static int bgColorIndex = 0;
        public static SolidColorBrush[] bgColorArray = {Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray };
        SolidColorBrush fgColor;
        static int fgColorIndex = 0;
        public static SolidColorBrush[] fgColorArray = { Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray };
        public RoundResult(GameMatch? win)
        {
            this.win = win;
            nextRoundBtn = win.NextRoundBtn;
            matchCounter = new MatchCounter(win);
            playerAction = new PlayerAction(win);
            opponentAction = new OpponentAction(win);
        }
        
        StackPanel resultDisplay = new StackPanel
        {
            Opacity = 0.9,
            Width = SystemParameters.PrimaryScreenWidth,
            Height = 200,
           
        };
        TextBlock resultContent = new TextBlock
        {         
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            FontSize = 75,
            Margin = new Thickness { Bottom = 40, Top = 40 },
            FontStyle = FontStyles.Italic,
        };
        public void AddRoundResult(SolidColorBrush bgColor, SolidColorBrush fgColor, string headLine)
        {           
            this.bgColor = bgColor;
            nextRoundBtn.Background = this.bgColor;
            nextRoundBtn.Visibility = Visibility.Visible;
          
            resultContent.Text = headLine;

            this.fgColor = fgColor;

            resultDisplay.Background = this.bgColor;
            resultContent.Foreground = this.fgColor;
            win.MatchWindow.Children.Add(resultDisplay);

            resultDisplay.Children.Add(resultContent);
            nextRoundBtn.AddHandler(Button.ClickEvent, new RoutedEventHandler(RemoveRoundResult));           
        }
        public void RemoveRoundResult(object sender, RoutedEventArgs e)
        {
            bgColorArray[MatchCounter.roundCounter - 1] = bgColor;
            fgColorArray[MatchCounter.roundCounter - 1] = fgColor;
            for (int i = 0; i < 5; i++)
            {
                matchResult.AddScoreBoardContent(MatchCounter.roCount[i], MatchCounter.opCount[i], MatchCounter.plyrCount[i], bgColorArray[i], fgColorArray[i]);
            }
            matchCounter.startRoundCounter();
            
            if (MatchCounter.roundCounter == 6) 
            {
                bgColorIndex = 0;
                win.Round.Text = "5";
                MatchHistoryContent addHistory = new MatchHistoryContent();
                addHistory.HistoryBoardContent();
               
                MatchHistory.history.ResultRow.Children.Add(addHistory.historyBoardContent);
                MatchHistory.history.PlyrRow.Children.Add(addHistory.historyBoardContent2);
                MatchHistory.history.OpRow.Children.Add(addHistory.historyBoardContent3);
                matchResult.SendElPos(
                      MatchHistory.history.ResultRow.Children.IndexOf(addHistory.historyBoardContent),
                      MatchHistory.history.PlyrRow.Children.IndexOf(addHistory.historyBoardContent2),
                      MatchHistory.history.OpRow.Children.IndexOf(addHistory.historyBoardContent3)
                    );
               
                matchResult.Show();
                win.Close();
               
                nextRoundBtn.Visibility = Visibility.Collapsed;
                win.MatchWindow.Children.Remove(resultDisplay);
                resultDisplay.Children.Remove(resultContent);
                nextRoundBtn.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(RemoveRoundResult));
                bgSoundEffects();

                opponentAction.ResetOpponent();
                playerAction.ResetPlayer();
                matchCounter.ResetAllCounter();

            }                         
                opponentAction.ResetOpponent();
                playerAction.ResetPlayer();
                nextRoundBtn.Visibility = Visibility.Collapsed;
                win.MatchWindow.Children.Remove(resultDisplay);
                resultDisplay.Children.Remove(resultContent);
                nextRoundBtn.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(RemoveRoundResult));              
        }

        private void bgSoundEffects()
        {
            if (MatchCounter.plyrScoreCounter > MatchCounter.opScoreCounter) bgSource(new Uri(@"J:\Sounds Effects\MatchVictory.mp3"));                  
            else if (MatchCounter.plyrScoreCounter < MatchCounter.opScoreCounter)  bgSource(new Uri(@"J:\Sounds Effects\MatchDefeat.mp3"));
            else if (MatchCounter.plyrScoreCounter == MatchCounter.opScoreCounter) bgSource(new Uri(@"J:\Sounds Effects\MatchTie.mp3"));
        }
        private void bgSource(Uri path) 
        {
            matchResult.MatchResultMusic.Source = path;
            matchResult.MatchResultMusic.LoadedBehavior = MediaState.Play;
        }           
    }
}
