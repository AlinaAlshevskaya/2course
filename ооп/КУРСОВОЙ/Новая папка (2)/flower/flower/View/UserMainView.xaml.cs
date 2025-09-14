using System.Windows;
using Models;
using flower.ViewModel;
using System.Windows.Controls;
using System.Diagnostics;



namespace flower.View
{

    public partial class UserMainView : Window
    {
        private  User _user = new User();
        public UserMainView(User enteredUser)
        {
            Debug.WriteLine(enteredUser.UserName);
            _user = enteredUser;
            InitializeComponent();
            
          
            this.WindowState = WindowState.Maximized;
            if (enteredUser.IsAdmin)
            {
                this.FirstLetterText.Text = "A";
                this.buttonCustomers.Visibility = Visibility.Visible;
                
                
            }
            else
            {
                this.buttonCustomers.Visibility = Visibility.Collapsed;
                this.FirstLetterText.Text = enteredUser.UserName[0].ToString();

            }
            DataContext = new UserDeskViewModel(enteredUser, this);

            if (!isCollapsed)
            {

                isCollapsed = true;
                GridControlPanel.Width = new GridLength(50);
                controlPanel.Width = 50;
                foto.Visibility = Visibility.Hidden;
                userName.Visibility = Visibility.Collapsed;
                seporator.Visibility = Visibility.Collapsed;
                Customers.Visibility = Visibility.Collapsed;
                Orders.Visibility = Visibility.Collapsed;
                Feedbacks.Visibility = Visibility.Collapsed;
                Products.Visibility = Visibility.Collapsed;
                backtoAu.Width = 30;
                backtoAu.Height = 30;
      
            }
        }

        private bool isCollapsed = false;
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (!isCollapsed)
            {

                isCollapsed = true;
                GridControlPanel.Width = new GridLength(50);
                controlPanel.Width = 50;
                foto.Visibility = Visibility.Hidden;
                userName.Visibility = Visibility.Collapsed;
                seporator.Visibility = Visibility.Collapsed;
                Customers.Visibility = Visibility.Collapsed;
                Orders.Visibility = Visibility.Collapsed;
                Feedbacks.Visibility = Visibility.Collapsed;
                Products.Visibility = Visibility.Collapsed;
                backtoAu.Width = 30;
                backtoAu.Height = 30;
              
            }
            else if (isCollapsed)
            {
                isCollapsed = false;

                GridControlPanel.Width = new GridLength(200);
                controlPanel.Width = 200;
                foto.Visibility = Visibility.Visible;
                userName.Visibility = Visibility.Visible;
                seporator.Visibility = Visibility.Visible;
                Customers.Visibility = Visibility.Visible;
                Orders.Visibility = Visibility.Visible;
                Feedbacks.Visibility = Visibility.Visible;
                Products.Visibility = Visibility.Visible;
                backtoAu.Width = 30;
                backtoAu.Height = 30;


            }


        }

        private void ChangeLangClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Name.ToString().ToLower() == "english")
                {
                    ((App)Application.Current).ChangeLanguage("ru");
                    btn.Name = "Русский";
                    this.changeLangButton.Text = "Русский";
                }
                else if (btn.Name.ToString().ToLower() == "русский")
                {
                    ((App)Application.Current).ChangeLanguage("en");
                    btn.Name = "English";
                    this.changeLangButton.Text = "English";
                }
            }
        }

        private void buttonCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.priceSort.Visibility = Visibility.Collapsed;
            if (this._user.IsAdmin)
            {
                this.AddUserButton.Visibility = Visibility.Visible;
                this.AddProductButton.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Products1_Click(object sender, RoutedEventArgs e)
        {
            this.priceSort.Visibility = Visibility.Visible;
            if (this._user.IsAdmin)
            {
                this.AddUserButton.Visibility = Visibility.Collapsed;
                this.AddProductButton.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.priceSort.Visibility = Visibility.Collapsed;
            this.AddUserButton.Visibility = Visibility.Collapsed;
            this.AddProductButton.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.priceSort.Visibility = Visibility.Collapsed;
            this.AddUserButton.Visibility = Visibility.Collapsed;
            this.AddProductButton.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.priceSort.Visibility = Visibility.Collapsed;
            this.AddUserButton.Visibility = Visibility.Collapsed;
            this.AddProductButton.Visibility = Visibility.Collapsed;
        }
    }
}
