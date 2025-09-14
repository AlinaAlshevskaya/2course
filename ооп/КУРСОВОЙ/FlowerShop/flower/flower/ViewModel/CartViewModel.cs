using flower.Helpers;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class CartViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        private UserDeskViewModel _userDeskViewModel = new UserDeskViewModel();

        public UserDeskViewModel UserDeskViewModel
        {
            get => _userDeskViewModel;
            set
            {
                _userDeskViewModel = value;
                OnPropertyChanged(nameof(UserDeskViewModel));
            }
        }

        private decimal _totalCart=0;
        public decimal TotalCart
        {
            get => _totalCart;
            set
            {
                if (_totalCart != value)
                {
                    _totalCart = value;
                    OnPropertyChanged(nameof(TotalCart));
                }
            }
        }

        private ObservableCollection<Product> _cart = new ObservableCollection<Product>();
        public ObservableCollection<Product> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        private void CountTotal(ObservableCollection<Product>Cart_)
        {
            TotalCart = 0;
            foreach (var product in Cart_)
            {
                TotalCart += product.Price;
            }
        }
        public CartViewModel(ObservableCollection<Product> cart, UserDeskViewModel mainVMDL)
        {

            Cart = cart;
            foreach (Product product in Cart)
            {
                Products.Add(product);
            }
            CountTotal(Cart);
            UserDeskViewModel = mainVMDL;

        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ??= new GenericRelayCommand<Product>(RemoveProduct, CanRemoveProduct);
        private void RemoveProduct(Product product)
        {
            ObservableCollection<Product> previous = new ObservableCollection<Product>(Cart);
            Cart.Clear();
            TotalCart = 0;
            previous.Remove(product);
            foreach(var item in previous)
            {
                Cart.Add(item);
                TotalCart+= item.Price;
                
                
            }
            

            

        }
        private bool CanRemoveProduct(Product product)
        {
            return true;
        }


        private ICommand _checkoutCommand;
        public ICommand CheckOutCommand => _checkoutCommand ??= new RelayCommand(AddOrder, CanAddOrder);

        private void AddOrder(object parameter)
        {
            OrderDetails detail = new OrderDetails();

            if (Cart.Count != 0)

            {

                int total_amount = 0;

                int total_price = 0;

                foreach (var product in Cart)

                {

                    total_amount += product.Amount;

                    total_price += (int)product.Price;

                }

                Order newOrder = new Order

                {

                    User = UserDeskViewModel.EteredUser,

                    TotalAmount = UserDeskViewModel.ChosenAmount,

                    TotalPrice = total_price,

                    OrderStatus = "Taken"

                };

                // Insert each detail associated with this order

                foreach (var product in Cart)

                {

                    detail.Order = newOrder; // Associate the order with the details

                    detail.Product = product;

                    detail.Amount = product.Amount;

                    App.repository.AddOrderDetails(detail); // Assuming this method designates details to newOrder

                }

                // Save the new order, and let SQL Server handle the OrderId

                App.repository.AddOrder(newOrder);
                Cart.Clear();
                Products.Clear();
                MessageBox.Show("Order placed", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Can't checkout to an empty order", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanAddOrder(object parameter)
        {
            return true;
        }
    }
}
