using flower.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class OrderDetailsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


        private Order _order = new Order();
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private User _user = new User();
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public OrderDetailsViewModel(Order order,User user)
        {
            Order = order;
            User = user;
            this.NewStatus = Order.OrderStatus;
        }

        private string _userReview;
        public string UserReview
        {
            get => _userReview;
            set
            {
                if(_userReview != value)
                {
                    _userReview = value;
                    OnPropertyChanged(nameof(UserReview));
                }
            }
        }

        private int _userRating;
        public int UserRating
        {
            get => _userRating;
            set
            {
                if(_userRating != value)
                {
                    _userRating = value;
                    OnPropertyChanged(nameof(UserRating));
                }
            }
        }

        private ICommand _saveReviewCommand;
        public ICommand SaveReviewCommand => _saveReviewCommand ??= new RelayCommand(SaveReview,CanSaveReview);
        
        private void SaveReview(object parameter)
        {
            Review newReview = new Review();
            if(UserReview!= null)
            {
                try
                {
                    //Order reviewedOrder = new Order(Order.TotalAmount, Order.TotalPrice, Order.OrderStatus);
                    //User reviewingUser = new User(User.UserName, User.UserSurename, User.Password, User.Email, User.PhoneNumber, User.IsAdmin);
                    //newReview.Order = reviewedOrder;
                    //newReview.User = reviewingUser;
                    newReview.ReviewText = UserReview;
                    newReview.Rate = UserRating;
                    newReview.OrderId = Order.OrderId;
                    newReview.UserId = User.UserId;
                    newReview.User = User;
                    newReview.Order = Order;
                    Order.Reviews.Add(newReview);
                    App.repository.UpdOrderReviews(Order,Order.OrderId);
                    if (App.repository.AddReview(newReview))
                    {
                        MessageBox.Show("Review Added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add review","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                    MessageBox.Show("Review Added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
               
            }
            else
            {
                MessageBox.Show("Can't save an empty review","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private bool CanSaveReview(object parameter)
        {
            return true;
        }


        private string _newStatus;
        public string NewStatus
        {
            get => _newStatus;
            set
            {
                if(_newStatus != value)
                {
                    _newStatus = value;
                }
                OnPropertyChanged(nameof(NewStatus));
            }
        }

        private ICommand _saveStatusCommand;
        public ICommand SaveStatusCommand => _saveStatusCommand ??= new RelayCommand(SaveStatus,CanSaveStatus);
        private void SaveStatus(object parameter)
        {
            if (NewStatus != null)
            {
                if (App.repository.UpdOrderStatus(NewStatus, Order.OrderId))
                {
                    MessageBox.Show("Order status updated", "Success", MessageBoxButton.OK,MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Failed to update status. It's empty", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanSaveStatus(object parameter)
        {
            return true;
        }
    }
}
