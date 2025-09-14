using flower.Helpers;
using Models;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class ProductMoreViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public ProductMoreViewModel(Product product,User user)
        {
            Product = product;
            User = user;
            ProductName = Product.ProductName;
            ProductDesctiprion = Product.ProductDescription;
            Price = Product.Price;
            Amount = Product.Amount;

        }

        private string _productName;
        public string ProductName
        {
            get=>_productName;
            set
            {
                if(_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        private string _productDescription;
        public string ProductDesctiprion
        {
            get => _productDescription;
            set
            {
                if(_productDescription != value)
                {
                    _productDescription = value;
                    OnPropertyChanged(nameof(ProductDesctiprion));
                }
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if(_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                if(value != _amount)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }
        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save,CanSave);
        private void Save(object parameter)
        {
           
            if (ProductName != null && ProductDesctiprion != null&&Price!=0&&Amount!=0)
            {
                Product product = new Product(ProductName, ProductDesctiprion, Amount, Price, Product.PhotoPath);

                if (App.repository.UpdateProduct(product, Product.ProductId))
                {
                    MessageBox.Show("Product was updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Something went wrong","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid input!","Fail",MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }

        private bool CanSave(object parameter)
        {
            return true;
        }
        


        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand(Delete,CanDelete);
        private void Delete(object parameter)
        {
            if (App.repository.DeleteProduct(Product.ProductId))
            {
                MessageBox.Show("Product deleted","Success",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanDelete(object parameter)
        {
            return true;
        }

    }
}
