using flower.Helpers;
using flower.View;
using Models;
using System.Windows;
using System.Windows.Input;


namespace flower.ViewModel
{
    public class ReviewMoreViewModel
    {
        private Review _review = new Review();
        public Review Review
        {
            get => _review;
            set => _review = value;
        }
        private ReviewMoreWindow _window;
        private User _user;
        public ReviewMoreViewModel(Review review,ReviewMoreWindow revWindow,User user)
        {
            _user = user;
            this._window = revWindow;
            this.Review = review;
            CurrentOrder = App.repository.GetOrderByReviewOrderId(Review.OrderId);
            if(CurrentOrder is null)
            {
                MessageBox.Show("Failed to load order","Fail",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (_user.IsAdmin)
            {
                _window.DeleteButton.Visibility = Visibility.Visible;
            }

        }

        private Order _currentOrder = new Order();
        public Order CurrentOrder
        {
            get=> _currentOrder;
            set => _currentOrder = value;
        }


        private ICommand _deleteReviewCommand;
        public ICommand DeleteReviewCommand => _deleteReviewCommand ??= new RelayCommand(DeleteReview,CanDeleteReview);

        private void DeleteReview(object parameter)
        {
            if (App.repository.DeleteReviewByReviewId(Review.ReviewId))
            {
                MessageBox.Show("Review deleted","Success",MessageBoxButton.OK,MessageBoxImage.Information);
                this._window.Close();
            }
            else
            {
                MessageBox.Show("Failed to delete", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanDeleteReview(object parameter)
        {
            return true;
        }
    }
}
