using flower.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace flower.View
{

    public partial class SignUpView : Window
    {
        public SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel(this);
            WindowState = WindowState.Maximized;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignUpViewModel vm && sender is PasswordBox pb)
            {
                vm.Password = pb.Password;
            }
        }

        public void ShowLoginClick(object sender, RoutedEventArgs e)
        {
            LogInView logIn = new LogInView();
            logIn.Show();
            this.Close();
        }

        public void ChangeLangButtonClick(object sender, RoutedEventArgs e)
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
    }
}
