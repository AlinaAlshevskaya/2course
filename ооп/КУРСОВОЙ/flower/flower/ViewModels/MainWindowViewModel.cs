using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using flower.ViewModels; // сервисы навигации или MVVM helper\
using flower.Views;

namespace flower.ViewModels
{
   


    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand OpenLoginWindowCommand { get; }

        private void OpenLoginWindow()
        {
            var login = new flower.Views.Login1();
            login.Show();
            RequestClose?.Invoke();
        }
        public MainWindowViewModel()
        {
          
            CreateAccountCommand = new RelayCommand(_ => CreateAccount(), _ => CanCreateAccount());
            OpenLoginWindowCommand = new RelayCommand(_ => OpenLoginWindow());
        }


       


        public event Action OnRequestClose;


        private string _familyName = "";
        private string _name = "";
        private string _phoneNumber = "";
        private string _password = "";
        private string _email = "";

        public string FamilyName
        {
            get => _familyName;
            set
            {
                if (_familyName != value)
                {
                    _familyName = value;
                    OnPropertyChanged();
                    ValidateFamilyName();
                    UpdateCommands();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                    ValidateName();
                    UpdateCommands();
                }
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                    ValidatePhoneNumber();
                    UpdateCommands();
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
                    OnPropertyChanged();
                    ValidatePassword();
                    UpdateCommands();
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    ValidateEmail();
                    UpdateCommands();
                }
            }
        }

        private void ValidateFamilyName()
        {
            ClearErrors(nameof(FamilyName));
            if (string.IsNullOrWhiteSpace(FamilyName))
            {
                AddError(nameof(FamilyName), "Введите фамилию");
                return;
            }
           
            var regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ]+$");
            if (!regex.IsMatch(FamilyName))
            {
                AddError(nameof(FamilyName), "Фамилия должна содержать только русские и английские буквы");
            }
        }

        private void ValidateName()
        {
            ClearErrors(nameof(Name));
            if (string.IsNullOrWhiteSpace(Name))
            {
                AddError(nameof(Name), "Введите имя");
                return;
            }
            var regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ]+$");
            if (!regex.IsMatch(Name))
            {
                AddError(nameof(Name), "Имя должно содержать только русские и английские буквы");
            }
        }

        private void ValidatePhoneNumber()
        {
            ClearErrors(nameof(PhoneNumber));
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
               
                AddError(nameof(PhoneNumber), "Введите номер телефона");
                return;
            }
            
            var regex = new Regex(@"^\+375(25|29|33|44|17)\d{7}$");
            if (!regex.IsMatch(PhoneNumber))
            {
                AddError(nameof(PhoneNumber), "Номер телефона должен начинаться с +375 и содержать корректный код оператора Беларуси (25,29,33,44,17), далее 7 цифр.");
            }
        }

        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if (string.IsNullOrWhiteSpace(Password))
            {
                AddError(nameof(Password), "Введите пароль");
                return;
            }
            if (Password.Length < 8)
            {
                AddError(nameof(Password), "Пароль должен содержать минимум 8 символов");
                return;
            }
            
            var letterRegex = new Regex(@"[a-zA-Zа-яА-ЯёЁ]");
            var upperRegex = new Regex(@"[A-ZА-ЯЁ]");
            var digitRegex = new Regex(@"\d");

            if (!letterRegex.IsMatch(Password))
                AddError(nameof(Password), "Пароль должен содержать буквы (русские или английские)");

            if (!upperRegex.IsMatch(Password))
                AddError(nameof(Password), "Пароль должен содержать хотя бы одну заглавную букву");

            if (!digitRegex.IsMatch(Password))
                AddError(nameof(Password), "Пароль должен содержать хотя бы одну цифру");
        }

        private void ValidateEmail()
        {
            ClearErrors(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
            {
                return; 
            }
            try
            {
                var addr = new MailAddress(Email);
                if (addr.Address != Email)
                    AddError(nameof(Email), "Неправильный формат Email");
            }
            catch
            {
                AddError(nameof(Email), "Неправильный формат Email");
            }
        }

        public ICommand CreateAccountCommand { get; }
        

        public event Action? RequestClose;

        

        private void CreateAccount()
        {
            // Здесь логика создания аккаунта

            MessageBox.Show("Аккаунт успешно создан!");
        }

        private bool CanCreateAccount()
        {
            return !HasErrors &&
                   !string.IsNullOrWhiteSpace(FamilyName) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(PhoneNumber) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

     
        private void UpdateCommands()
        {
           
            (CreateAccountCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }
        
    }

}


