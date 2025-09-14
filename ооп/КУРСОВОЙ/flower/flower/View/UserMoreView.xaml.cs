using Models;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;


namespace flower.View
{
    public partial class UserMoreView : Window
    {
        public User _user = new User();
        public UserMoreView(User user)
        {
            _user = user;
            Debug.WriteLine(user.UserName);
            InitializeComponent();
            Debug.WriteLine(user.Email);
        }

        public void MoreCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ChangeLangButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Name.ToString().ToLower() == "english")
                {
                    ((App)Application.Current).ChangeLanguage("ru");
                    btn.Name = "Русский";
                    //this.ChangeLangText.Text = "Русский";
                }
                else if (btn.Name.ToString().ToLower() == "русский")
                {
                    ((App)Application.Current).ChangeLanguage("en");
                    btn.Name = "English";
                   // this.ChangeLangText.Text = "English";
                }
            }
        }

    }
}
