using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Data;

namespace lab45
{
     public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
      
      
        private string _firstname;
        private string _name;
        private string _number;
        private string _password;
        private string _email;

        public string Firstname
        {
            get => _firstname;
            set { _firstname = value; OnPropertyChanged(nameof(Firstname)); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Number
        {
            get => _number;
            set { _number = value; OnPropertyChanged(nameof(Number)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        // Команда регистрации
        public ICommand RegisterCommand { get; }

        public MainWindowViewModel()
        {
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }

        private void Register()
        {
            UserDesk userdesk = new UserDesk();
            userdesk.Show();
            //mainwindow.Close();
        }

        private bool CanRegister()
        {
            // Можно регистрироваться только если все поля валидны
            return string.IsNullOrEmpty(Error);
        }

        // Реализуем IDataErrorInfo для валидации отдельного свойства

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Firstname):
                        if (string.IsNullOrWhiteSpace(Firstname))
                            return "Поле нельзя оставить пустым";
                        if (!Regex.IsMatch(Firstname, @"^[A-Za-zА-ЯЁа-яё]+$"))
                            return "Это поле введено неправильно";
                        break;

                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            return "Поле нельзя оставить пустым";
                        if (!Regex.IsMatch(Name, @"^[A-Za-zА-ЯЁа-яё]+$"))
                            return "Это поле введено неправильно";
                        break;

                    case nameof(Number):
                        if (string.IsNullOrWhiteSpace(Number))
                            return "Поле нельзя оставить пустым";
                        if (!Regex.IsMatch(Number, @"^\+375(25|29|33|44)\d{7}$"))
                            return "Это поле введено неправильно";
                        break;

                    case nameof(Password):
                        if (string.IsNullOrWhiteSpace(Password))
                            return "Поле нельзя оставить пустым";
                        if (Password.Length < 8)
                            return "Пароль должен содержать минимум 8 символов";
                        if (!Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                            return "Пароль должен содержать минимум 1 заглавную букву и 1 цифру";
                        break;

                    case nameof(Email):
                        if (!string.IsNullOrEmpty(Email)) // Email необязателен, но если введён — проверить
                        {
                            if (!Regex.IsMatch(Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                                return "Это поле введено неправильно";
                        }
                        break;
                }
                return null;
            }
        }

        // Аггрегированная ошибка для всей модели
        public string Error
        {
            get
            {
                string[] properties = { nameof(Firstname), nameof(Name), nameof(Number), nameof(Password), nameof(Email) };
                foreach (var prop in properties)
                {
                    if (!string.IsNullOrEmpty(this[prop]))
                        return "Заполните поля корректно";
                }
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            (RegisterCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }
    }

    // Простой RelayCommand с CanExecute поддержкой для MVVM команд
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class ErrorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hasError = (bool)value;
            return hasError ? Brushes.LightCoral : Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

