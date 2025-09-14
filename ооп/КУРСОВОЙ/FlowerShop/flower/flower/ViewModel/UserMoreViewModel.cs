using flower.Helpers;
using flower.View;
using Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class UserMoreViewModel
    {
        private User _infoUser = new User();
        public User InfoUser
        {
            get => _infoUser;
            set
            {
                _infoUser= value;
            }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = InfoUser.UserName + InfoUser.UserSurename;
            }
        }
        private void ClearData()
        {
            UpdUserName = string.Empty;
            UpdUserSurename = string.Empty;
            UpdUserEmail = string.Empty;
            UpdUserPhoneNumber = string.Empty;
        }
        private void ResetData()
        {
            ClearData();
            UpdUserName = InfoUser.UserName;
            UpdUserSurename = InfoUser.UserSurename;
            UpdUserEmail = InfoUser.Email;
            UpdUserPhoneNumber = InfoUser.PhoneNumber;
            if (InfoUser.IsAdmin)
            {
                UseRole = "Admin";
            }
            else
            {
                UseRole = "User";
            }
        }

        private bool CheckFieldsNullability()
        {
            if (string.IsNullOrWhiteSpace(UpdUserName) || string.IsNullOrWhiteSpace(UpdUserSurename) || string.IsNullOrWhiteSpace(UpdUserEmail) || string.IsNullOrWhiteSpace(UpdUserPhoneNumber))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private UserMoreView view;
        public UserMoreViewModel(User user,UserMoreView _view) 
        {
            view = _view;
            InfoUser = user;
            ResetData();
        }

        private string _updUserName;
        public string UpdUserName
        {
            get => _updUserName;
            set
            {
                if (_updUserName != value)
                {
                    _updUserName = value;
                    OnPropertyChanged(nameof(UpdUserName));
                }
            }
        }

        private string _updUserSurename;
        public string UpdUserSurename
        {
            get => _updUserSurename;
            set
            {
                if(_updUserSurename != value)
                {
                    _updUserSurename= value;
                    OnPropertyChanged(nameof(UpdUserSurename));
                }
            }
        }

        private string _updUserEmail;
        public string UpdUserEmail
        {
            get => _updUserEmail;
            set
            {
                if(_updUserEmail != value)
                {
                    _updUserEmail = value;
                    OnPropertyChanged(nameof(UpdUserEmail));
                }
            }
        }

        private string _updUserPhoneNumber;
        public string UpdUserPhoneNumber
        {
            get => _updUserPhoneNumber;
            set
            {
                if(_updUserPhoneNumber != value)
                {
                    _updUserPhoneNumber = value;
                    OnPropertyChanged(nameof(UpdUserPhoneNumber));
                }
            }
        }

        private string _userRole;
        public string UseRole
        {
            get => _userRole;
            set
            {
                _userRole= value;
            }
        }


        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??= new RelayCommand(Cancel,CanCancel);
        private void Cancel(object parameter)
        {
            ClearData();
            MessageBox.Show("Cancel clicked");
        }
        private bool CanCancel(object parameter)
        {
            return true;
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save,CanSave);

        private void Save(object parameter)
        {
            User updUser = new User();
            updUser.UserId = InfoUser.UserId;
            updUser.UserName = UpdUserName;
            updUser.UserSurename = UpdUserSurename;
            updUser.Email = UpdUserEmail;
            updUser.PhoneNumber = UpdUserPhoneNumber;
            if (App.repository.UpdateUser(updUser, InfoUser.UserId))
            {
                MessageBox.Show("Info Updated Successfully","Success",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                ResetData();
                MessageBox.Show("Something went wrong!","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private bool CanSave(object parameter)
        {
            return CheckFieldsNullability();
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand(Delete,CanDelete);
        private void Delete(object parameter)
        {
            if (App.repository.DeleteUser(InfoUser.UserId))
            {
                MessageBox.Show("User was deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearData();
                view.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private bool CanDelete(object parameter)
        {
            return true;
        }


       

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

    }
}
