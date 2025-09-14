using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab45
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window
    {
        public string number;
        public string password;
        public Autorisation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow RegisterWind = new MainWindow
            {
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };
            RegisterWind.Show();
            Hide();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            number = TBnumberAu.Text.Trim();
            string numberPAttern = @"^\+375(25|29|33|44)\d{7}$";
            bool isValidNumber = Regex.IsMatch(number, numberPAttern);

            if (number == null)
            {
                TBnumberAu.ToolTip = "Поле нельзя оставить пустым";
                TBnumberAu.Background = Brushes.LightCoral;
            }
            else if (!isValidNumber)
            {
                TBnumberAu.ToolTip = "Это поле введено некореектно";
                TBnumberAu.Background = Brushes.LightCoral;
            }
            else
            {
                TBnumberAu.ToolTip = "";
                TBnumberAu.Background = Brushes.White;
            }
        }

        private void TBpassAu_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = TBpassAu.Password;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ;
            UserDesk userdesk = new UserDesk();
            userdesk.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
         
            UserDesk userdesk = new UserDesk();
            userdesk.Show();
            Hide();
        }
    }
}
