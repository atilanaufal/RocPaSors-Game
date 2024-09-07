using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace RocPaSors.Logic.MatchResultLogic
{
    internal class MatchResultContent
    {

        MatchResultWindow win2;
        string labelResult;
        SolidColorBrush bgColor2;
        SolidColorBrush fgColor2;

        public MatchResultContent(MatchResultWindow win2) { this.win2 = win2; }

        ListBoxItem scoreBoardContent = ListBoard();
        ListBoxItem scoreBoardContent2 = ListBoard();
        ListBoxItem scoreBoardContent3 = ListBoard();
        public  ListBoxItem scoreBoardContent4 = new ListBoxItem()
        {
            Margin = new Thickness(left: 0, top: 345, right: 0, bottom: 0),
            Height = 90.5,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Width = 900,
            BorderThickness = new Thickness(0),
            FontSize = 40,
            FontWeight = FontWeights.DemiBold,
            FontFamily = new FontFamily("Verdana"),
            FontStyle = FontStyles.Italic
        };

        public void ScoreBoardContent(int round, int op, int plyr, SolidColorBrush bgColor, SolidColorBrush fgColor)
        {            
            if (MatchCounter.plyrScoreCounter > MatchCounter.opScoreCounter)
            {
                bgColor2 = Brushes.ForestGreen;
                fgColor2 = Brushes.PaleGreen;
                labelResult = "VICTORY";
               
            }
            else if (MatchCounter.plyrScoreCounter < MatchCounter.opScoreCounter)
            {
                bgColor2 = Brushes.DarkRed;
                fgColor2 = Brushes.Red;
                labelResult = "DEFEAT";
            }
            else
            {
                bgColor2 = Brushes.LightGray;
                fgColor2 = Brushes.DarkSlateGray;
                labelResult = "TIE";
            }

            scoreBoardContent.Background = bgColor;
            scoreBoardContent.Foreground = fgColor;
            scoreBoardContent.Content = $"Round {round}";
            scoreBoardContent.Name = "dadad";

            scoreBoardContent2.Background = bgColor;
            scoreBoardContent2.Foreground = fgColor;
            scoreBoardContent2.Content = $"Score {plyr}"; ;
            scoreBoardContent2.Name = "dadad";

            scoreBoardContent3.Background = bgColor;
            scoreBoardContent3.Foreground = fgColor;
            scoreBoardContent3.Content = $"Score {op}"; ;
            scoreBoardContent3.Name = "dadad";

            scoreBoardContent4.Background = bgColor2;
            scoreBoardContent4.Foreground = fgColor2;
            scoreBoardContent4.Content = labelResult; ;


            win2.RoundScore.Children.Add(scoreBoardContent);           
            win2.PlyrScore.Children.Add(scoreBoardContent2);        
            win2.OpScore.Children.Add(scoreBoardContent3);
            win2.MatchResultContainer.Children.Add(scoreBoardContent4);
        }
        private static ListBoxItem ListBoard()
        {
            return new ListBoxItem()
            {
                Margin = new Thickness(0),
                Height = 60,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Width = 300,
                BorderThickness = new Thickness(0),
                FontSize = 25,
                FontWeight = FontWeights.DemiBold,
            };
        }
    }
}
