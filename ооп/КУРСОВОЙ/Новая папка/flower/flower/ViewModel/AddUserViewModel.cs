using Models;
using flower.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace flower.ViewModel
{
    public class AddUserViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));



        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                if(_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }


        private string _userSurename;
        public string UserSurename
        {
            get => _userSurename;
            set
            {
                if( _userSurename != value)
                {
                    _userSurename = value;
                    OnPropertyChanged(nameof(UserSurename));
                }
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                if(_userEmail != value)
                {
                    _userEmail = value;
                    OnPropertyChanged(nameof(UserEmail));
                }
            }
        }

        private string _userPhoneNumber;
        public string UserPhoneNumber
        {
            get => _userPhoneNumber;
            set
            {
                if(_userPhoneNumber != value)
                {
                    _userPhoneNumber = value;
                    OnPropertyChanged(nameof(UserPhoneNumber));
                }
            }
        }

        private string _userPassword;
        public string UserPassword
        {
            get=>_userPassword;
            set
            {
                if(_userPassword != value)
                {
                    _userPassword = value;
                    OnPropertyChanged(nameof(UserPassword));
                }
            }
        }
        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save,CanSave);
        private void Save(object parameter)
        {
            User newUser = new User(UserName, UserSurename, UserPassword, UserEmail, UserPhoneNumber, false);
            if (App.repository.AddUser(newUser))
            {
                MessageBox.Show("User added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Fail","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


        private bool CanSave(object parameter)
        {
            return true;
        }

    }
}
