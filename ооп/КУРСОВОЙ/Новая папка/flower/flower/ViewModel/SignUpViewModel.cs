using flower.Helpers;
using flower.View;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class SignUpViewModel
    {


        private string _firstName;
        private string _surename;
        private string _phoneNumber;
        private string _password;
        private string _email;

        private SignUpView _signUpView;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));



        public SignUpViewModel(SignUpView signUpView)
        {
            _signUpView = signUpView;
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if(_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string Surename
        {
            get=> _surename;
            set
            {
                if(_surename != value)
                {
                    _surename = value;
                    OnPropertyChanged(nameof(Surename));
                }
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if(_phoneNumber != value)
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
                if(_password != value)
                {
                    _password = value;
                    ((RelayCommand)SignUpCommand).RaiseCanExecuteChanged();
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if(_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private ICommand _signUpCommand;
        public ICommand SignUpCommand => _signUpCommand ??= new RelayCommand(SignUp,CanSignUp);


        private void SignUp(object parameter)
        {
            ObservableCollection<User> allUsers = App.repository.GetAllUsers();
            User newUser = new User(FirstName, Surename, Password, Email, PhoneNumber, false);
            bool failed = false;
            Debug.WriteLine($"{FirstName} - {Surename} - {Password} - {Email}");
            newUser.Address = "NO";
            newUser.ImagePath = "NO";
            string MessageBoxMessage = "Something went wrong";
            if(FirstName!=null && Surename!=null && Password != null && Email != null && PhoneNumber != null)
            {
                bool hasPassedChecks = true;
                if (!Validator.IsValidName(FirstName) || !Validator.IsValidName(Surename))
                {
                    hasPassedChecks = false;
                    MessageBoxMessage = "Invalid Name ore surename";
                }
                if(!Validator.IsValidEmail(Email))
                {
                    hasPassedChecks = false;
                    MessageBoxMessage = "Invalid Email";
                }
                if (!Validator.IsValidPassword(Password))
                {
                    hasPassedChecks = false;
                    MessageBoxMessage = "Invalid Password";
                }
                foreach(User user in allUsers)
                {
                    if (user.PhoneNumber == newUser.PhoneNumber)
                    {
                        hasPassedChecks = false;
                        MessageBoxMessage = "This User Already exists";
                    }
                }

                if (hasPassedChecks)
                {
                    if (App.repository.AddUser(newUser))
                    {
                        

                        FirstName = string.Empty;
                        Surename = string.Empty;
                        Email = string.Empty;
                        Password = string.Empty;
                        PhoneNumber = string.Empty;
                        UserMainView userMain = new UserMainView(newUser);
                        userMain.Show();
                        _signUpView.Close();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong", "Failed to sign up", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"{MessageBoxMessage}","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
                }
               

            }
            else
            {
                MessageBox.Show("Failed to sign up","Fail",MessageBoxButton.OK, MessageBoxImage.Error); 
            }


        }

        private bool CanSignUp(object parameter)
        {
            return true;
        }
    }
}
