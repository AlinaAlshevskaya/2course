using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Globalization;


namespace lab45
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new MainWindowViewModel();
            //var vm = new MainWindowViewModel();
            //this.DataContext = vm;
            //vm.RequestOpenUserDesk += () =>
            //{
            //    UserDesk desk = new UserDesk();
            //    desk.Show();
            //    this.Close();
            //};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Autorisation AuthWind = new Autorisation
            {
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };
            AuthWind.Show();
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
        

    }
}