using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flower.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class LoginWindowViewModel : ViewModelBase
    {
        private string _phoneNumber = "";
        private string _password = "";

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
                    RaiseCanExecuteChanged();
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
                    RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand OpenRegistrationWindowCommand { get; }

        public event Action? RequestClose;

        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login(), _ => !HasErrors && !string.IsNullOrWhiteSpace(Password));
            OpenRegistrationWindowCommand = new RelayCommand(_ => OpenRegistrationWindow());
        }

        private void ValidatePhoneNumber()
        {
            ClearErrors(nameof(PhoneNumber));
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                AddError(nameof(PhoneNumber), "Введите номер телефона");
            else if (!PhoneNumber.All(char.IsDigit) || PhoneNumber.Length < 10)
                AddError(nameof(PhoneNumber), "Некорректный номер телефона");
        }

        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if (string.IsNullOrWhiteSpace(Password))
                AddError(nameof(Password), "Введите пароль");
            else if (Password.Length < 8)
                AddError(nameof(Password), "Пароль должен быть не менее 8 символов");
        }

        private void Login()
        {
            MessageBox.Show("Входим в систему...");
            // TODO: проверка пользователя
        }

        private void OpenRegistrationWindow()
        {
            var reg = new flower.Views.MainWindow();
            reg.Show();
            RequestClose?.Invoke();
        }

        private void RaiseCanExecuteChanged()
        {
            (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }
    }


}
