using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using flower.ViewModel;

namespace flower.View
{

    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            DataContext = new LogInViewModel(this);
            WindowState = WindowState.Maximized;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LogInViewModel vm && sender is PasswordBox pb)
            {
                vm.Password= pb.Password;
            }
        }

        public void ChangeLangClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Content.ToString().ToLower() == "english")
                {
                    ((App)Application.Current).ChangeLanguage("ru");
                    btn.Content = "Русский";
                }
                else if (btn.Content.ToString().ToLower() == "русский")
                {
                    ((App)Application.Current).ChangeLanguage("en");
                    btn.Content = "English";
                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var signUpWindow = new SignUpView();
            signUpWindow.Show();
            this.Close();
        }


      

    }
}
