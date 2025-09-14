using flower.Helpers;
using flower.View;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class LogInViewModel
    {
        private string _phoneNumber;

        private string _password;
        private User _loggeduser = new User();
        public User LoggedUser
        {
            get => _loggeduser;
            set
            {
                _loggeduser = value;
            }
        }

        private LogInView _loginView;
        public LogInViewModel(LogInView loginView)
        {
            _loginView = loginView;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }


            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));

                }

            }
        }


        private ICommand _logIncommand;
        public ICommand LogInCommand => _logIncommand ??= new RelayCommand(Login, CanLogin);


        private void Login(object parameter)
        {
           
            ObservableCollection<User> allUsers = App.repository.GetAllUsers();
            bool found = false;
            foreach(var user in allUsers)
            {
                if (user.Password==Password&&user.PhoneNumber==PhoneNumber)
                {
                    found = true;
                    LoggedUser = user;
                }
            }
            Password = string.Empty;
            PhoneNumber = string.Empty;
            if (!found)
            {
                MessageBox.Show("Such Account Does Not Exist!","Failed to Log In",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
             
              
                UserMainView userMain = new UserMainView(LoggedUser);
                userMain.Show();
                _loginView.Close();
            }

           
        }

       
        private bool CanLogin(object parameter)
        {
         
            return true;
        }



    }
}
