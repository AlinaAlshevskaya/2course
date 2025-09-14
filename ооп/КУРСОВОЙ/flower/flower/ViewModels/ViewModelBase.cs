using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace flower.ViewModels
{

    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private readonly Dictionary<string, List<string>> _errors = new();

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.SelectMany(err => err.Value);
            else if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            else
                return Array.Empty<string>();
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }

}


