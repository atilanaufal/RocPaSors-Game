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
    public partial class NameBox
    {
        StartUp? win;
        public NameBox()
        {
            InitializeComponent();
            EnterName.Focus();
            AddText();
            EnterName.KeyDown += RemoveText;
        }

        private void Continue_ToGame(object sender, RoutedEventArgs e)
        {
            if (EnterName.Text == "Enter Your Name" || string.IsNullOrWhiteSpace(EnterName.Text)) {   }
            else
            {
                MainMenuWindow mainMenu = new MainMenuWindow();
                PlayerAction.playerName = EnterName.Text;
                EnterName.Text = "";
                mainMenu.Show();
             
                win.Close();                
            }       
        }
        private void Back_ToStartUp(object sender, RoutedEventArgs e)
        {
            win.NameBox.Content = "";
            win.StartText.Visibility = Visibility.Visible;
        }
        private void Press_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Continue.Focus();
            else if (e.Key == Key.Escape) Back.IsCancel = true;
        }
        public void StartUpName(StartUp win) => this.win = win;

        public void RemoveText(object sender, EventArgs e)
        {
            if (EnterName.Text == "Enter Your Name")
            {
                EnterName.Text = "";
                EnterName.Foreground = Brushes.WhiteSmoke;
            }
        }

        public void AddText()
        {
            if (string.IsNullOrWhiteSpace(EnterName.Text))
            {
                EnterName.Text = "Enter Your Name";
                EnterName.Foreground = Brushes.Gray;
            }
        }
    }
}
