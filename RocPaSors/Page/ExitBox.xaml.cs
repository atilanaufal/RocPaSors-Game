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

namespace RocPaSors.Page
{
    /// <summary>
    /// Interaction logic for NameBox.xaml
    /// </summary>
    public partial class ExitBox
    {
        StartUp? win;
        public ExitBox()
        {
            InitializeComponent();

        }

        private void Exit_Game(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        public void StartUpName(StartUp win) => this.win = win;
        private void Back_ToStartUp(object sender, RoutedEventArgs e)
        {
            win.NameBox.Content = "";
            win.StartText.Visibility = Visibility.Visible;
        }
        private void Press_Enter(object sender, KeyEventArgs e)
        {        
            if (e.Key == Key.Enter) Exit_Game(sender, e);
            else if (e.Key == Key.Escape) ExitNo.IsCancel = true;
        }

        private void ExitYes_Loaded(object sender, RoutedEventArgs e)
        {
            ExitYes.Focus();
        }

        private void ExitNo_Loaded(object sender, RoutedEventArgs e)
        {
            ExitNo.Focus();
        }
    }
}
