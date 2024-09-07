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
    internal class MatchHistoryContent
    {
        public ListBoxItem historyBoardContent = ListBoard();
        public ListBoxItem historyBoardContent2 = ListBoard();
        public ListBoxItem historyBoardContent3 = ListBoard();
        string? labelResult;
        SolidColorBrush? bgColor2;
        SolidColorBrush? fgColor2;

        public  void HistoryBoardContent()
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

            historyBoardContent.Background = bgColor2;
            historyBoardContent.Foreground = fgColor2;
            historyBoardContent.Content = labelResult;
            historyBoardContent.Name = $"dadad";

            historyBoardContent2.Background = bgColor2;
            historyBoardContent2.Foreground = fgColor2;
            historyBoardContent2.Content = $"Score {MatchCounter.plyrScoreCounter}"; ;
            historyBoardContent2.Name = $"dadad";

            historyBoardContent3.Background = bgColor2;
            historyBoardContent3.Foreground = fgColor2;
            historyBoardContent3.Content = $"Score {MatchCounter.opScoreCounter}"; ;
            historyBoardContent3.Name = $"dadad";            
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
