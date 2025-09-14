
using flower.Helpers;
using flower.View;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class UserDeskViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


        private User _enteredUser = new User();

        public User EteredUser
        {
            get => _enteredUser;
            set
            {
                _enteredUser = value;
            }
        }


        private UserMainView _userView;


        public UserDeskViewModel(User enteredUser,UserMainView userView) 
        {
            EteredUser= enteredUser;
            _userView = userView;
            ChosenAmount = 1;
            ShowProductsCommand.Execute(EteredUser);
        }

        public UserDeskViewModel() { ChosenAmount = 1; }

        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    OnPropertyChanged(nameof(FilterText));
                }
            }
        }

        private int _lowerPriceRange;
        public int LowerPriceRange
        {
            get => _lowerPriceRange;
            set
            {
                if( _lowerPriceRange != value)
                {
                    _lowerPriceRange = value;
                    OnPropertyChanged(nameof(LowerPriceRange));
                }
            }
        }

        private int _upperPriceRange;
        public int UpperPriceRange
        {
            get=> _upperPriceRange;
            set
            {
                if(_upperPriceRange != value)
                {
                    _upperPriceRange = value;
                    OnPropertyChanged(nameof(UpperPriceRange));
                }
            }
        }

        private ObservableCollection<Category> _allCategories = App.repository.GetAllCategories();
        public ObservableCollection<Category> AllCategories
        {
            get => _allCategories;
            set
            {
                _allCategories = value;
                OnPropertyChanged(nameof(AllCategories));
            }
        }

        private ObservableCollection<Color>_allColors = App.repository.GetAllColors();
        public ObservableCollection<Color> AllColors
        {
            get => _allColors;
            set
            {
                _allColors = value;
                OnPropertyChanged(nameof(AllColors));
            }
        }

        private ICommand _exitCommand;
        public ICommand ExitCommand => _exitCommand ??= new RelayCommand(Exit,CanExit);

        private void Exit(object parameter)
        {
           LogInView logInView = new LogInView();
            logInView.Show();
            _userView.Close();
        }
        private bool CanExit(object parameter)
        {
            return true;
        }


        private ICommand _showMoreUserCommand;
        public ICommand ShowMoreUserCommand => _showMoreUserCommand ??= new GenericRelayCommand<User>(ShowMoreUser,CanShowMoreUser);

        private void ShowMoreUser(User user)
        {
            UserMoreView _moreView = new UserMoreView(user);
            _moreView.DataContext = new UserMoreViewModel(user,_moreView);
            _moreView.Show();
        }

        private bool CanShowMoreUser(User user)
        {
            return true;
        }

        private ICommand _showMoreCommand;
        public ICommand ShowMoreCommand => _showMoreCommand ??= new RelayCommand(ShowUser,CanShowUser);
        private void ShowUser(object parameter)
        {
            UserMoreView _moreView = new UserMoreView(EteredUser);
            _moreView.DataContext = new UserMoreViewModel(EteredUser, _moreView);
            _moreView.Show();
        }
        private bool CanShowUser(object parameter)
        {
            return true;
        }

        private ICommand _showUsersCommand;
        public ICommand ShowUsersCommand => _showUsersCommand ??= new RelayCommand(ShowUsers,CanShowUsers);

        private ObservableCollection<User>_usersToShow = new ObservableCollection<User>();
       
        
        public ObservableCollection<User> UsersToShow
        {
            get => _usersToShow;
            set
            {
                _usersToShow = value;
                OnPropertyChanged(nameof(UsersToShow));
            }
        }


        private ObservableCollection<User> _allUsers = new ObservableCollection<User>();

        public ObservableCollection<User> AllUsers
        {
            get => _allUsers;
            set
            {
                _allUsers = value;
                OnPropertyChanged(nameof(AllUsers));
            }
        }
        private void ShowUsers(object parameter)
        {

            UsersToShow.Clear();
            ObservableCollection<User> users = App.repository.GetAllUsers();
            foreach(var user in users)
            {
                UsersToShow.Add(user);
                AllUsers.Add(user);
            }
            this._userView.ContentControl.ItemsSource = UsersToShow;
        }
        private bool CanShowUsers(object parameter)
        {
            return true;
        }


        private ObservableCollection<Order> _ordersToShow = new ObservableCollection<Order>();
        public ObservableCollection<Order> OrdersToShow
        {
            get => _ordersToShow;
            set
            {
                _ordersToShow = value;
                OnPropertyChanged(nameof(OrdersToShow));
            }
        }

        private ObservableCollection<Order> _allOrders = new ObservableCollection<Order>();
        public ObservableCollection<Order> AllOrders
        {
            get=>_allOrders;
            set
            {
                _allOrders = value;
                OnPropertyChanged(nameof(AllOrders));
            }
        }

        private ICommand _showOrdersCommand;
        public ICommand ShowOrdersCommand => _showOrdersCommand ??= new RelayCommand(ShowOrders,CanShowOrders);
        private void ShowOrders(object parameter)
        {
            OrdersToShow.Clear();
            ObservableCollection<Order>orders = EteredUser.IsAdmin?App.repository.GetAllOrders():App.repository.GetAllOrdersByUserId(EteredUser.UserId);
            foreach(var order in orders)
            {
                OrdersToShow.Add(order);
                AllOrders.Add(order);
            }

            this._userView.ContentControl.ItemsSource = OrdersToShow;
        }
        private bool CanShowOrders(object parameter)
        {
            return true;
        }

        private ObservableCollection<Product>_productsToShow = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }

        private ObservableCollection<Product>_allProducts = new ObservableCollection<Product>();
        public ObservableCollection<Product>AllProducts
        {
            get => _allProducts;
            set
            {
                _allProducts = value;
                OnPropertyChanged(nameof(AllProducts));
            }
        }

        private ICommand _showProductsCommand;
        public ICommand ShowProductsCommand => _showProductsCommand ??= new RelayCommand(ShowProducts,CanShowProducts);

        private void ShowProducts(object parameter)
        {
            ProductsToShow.Clear();
            ObservableCollection<Product>products = App.repository.GetAllProducts();
            foreach(var product in products)
            {
                ProductsToShow.Add(product);
                AllProducts.Add(product);
            }
            this._userView.ContentControl.ItemsSource = ProductsToShow;
        }
        private bool CanShowProducts(object parameter)
        {
            return true;
        }


        private ObservableCollection<Review>_reviewsToShow = new ObservableCollection<Review>();
        public ObservableCollection<Review> ReviewsToShow
        {
            get => _reviewsToShow;
            set
            {
                _reviewsToShow = value;
                OnPropertyChanged(nameof(ReviewsToShow));
            }
        }

        private ObservableCollection<Review>_allReviews = new ObservableCollection<Review>();
        public ObservableCollection<Review> AllReviews
        {
            get => _allReviews;
            set
            {
                _allReviews = value;
                OnPropertyChanged(nameof(AllReviews));
            }
        }

        private ICommand _showReviewsCommand;
        public ICommand ShowReviewsCommand => _showReviewsCommand ??= new RelayCommand(ShowReviews,CanShowReviews);
        private void ShowReviews(object parameter)
        {
            ReviewsToShow.Clear();
            ObservableCollection<Review> reviews = EteredUser.IsAdmin ? App.repository.GetAllReviews() : App.repository.GetAllReviewsByUserId(EteredUser.UserId);
            foreach (var review in reviews)
            {
                ReviewsToShow.Add(review);
                AllReviews.Add(review);
            }
            
            this._userView.ContentControl.ItemsSource=ReviewsToShow;

        }
        private bool CanShowReviews(object parameter)
        {
            return true;
        }


        private ICommand _searchCommand;
        public ICommand SearchCommnand => _searchCommand ??= new RelayCommand(Search,CanSearch);
        private void RefreshCollections()
        {
            OrdersToShow.Clear();
            ProductsToShow.Clear();
            ReviewsToShow.Clear();
            UsersToShow.Clear();
            AllOrders.Clear();
            AllOrders = App.repository.GetAllOrders();
            AllProducts.Clear();
            AllProducts = App.repository.GetAllProducts();
            foreach (var order in AllOrders)
            {
                OrdersToShow.Add(order);
            }
            foreach (var user in AllUsers)
            {
                UsersToShow.Add(user);
            }
            foreach(var product in AllProducts)
            {
                ProductsToShow.Add(product);
            }
            foreach(var review in AllReviews)
            {
                ReviewsToShow.Add(review);
            }
           
           
        }
        private void Search(object parameter)
        {
            RefreshCollections();

            if (FilterText != null||!string.IsNullOrEmpty(FilterText))
            {
                if (this._userView.ContentControl.ItemsSource == ProductsToShow)
                {
                    ObservableCollection<Product> filteredProducts = new ObservableCollection<Product>();
                    foreach (var product in ProductsToShow)
                    {
                        if (product.ProductName.ToLower().Contains(FilterText.ToLower()) || product.ProductDescription.ToLower().Contains(FilterText.ToLower()))
                        {
                            filteredProducts.Add(product);
                        }
                    }

                    ProductsToShow.Clear();
                    foreach (var prod in filteredProducts)
                    {
                        ProductsToShow.Add(prod);
                    }
                    filteredProducts.Clear();
                }
                else if (this._userView.ContentControl.ItemsSource == OrdersToShow)
                {
                    ObservableCollection<Order> filteredOrders = new ObservableCollection<Order>();
                    foreach (var order in OrdersToShow)
                    {
                        if (order.OrderStatus.ToLower().Contains(FilterText.ToLower()) || order.TotalPrice.ToString().Contains(FilterText) || order.User.UserName.ToLower().Contains(FilterText.ToLower()))
                        {
                            filteredOrders.Add(order);
                        }
                    }
                    OrdersToShow.Clear();
                    foreach (var order in filteredOrders)
                    {
                        OrdersToShow.Add(order);
                    }
                    filteredOrders.Clear();
                }
                else if (this._userView.ContentControl.ItemsSource == UsersToShow)
                {
                    ObservableCollection<User> filteredUsers = new ObservableCollection<User>();
                    foreach (var user in UsersToShow)
                    {
                        if (user.UserName.ToLower().Contains(FilterText.ToLower()) || user.UserSurename.ToLower().ToLower().Contains(FilterText.ToLower()) || user.Email.ToLower().Contains(FilterText.ToLower()))
                        {
                            filteredUsers.Add(user);
                        }
                    }
                    UsersToShow.Clear();
                    foreach (var user in filteredUsers)
                    {
                        UsersToShow.Add(user);
                    }
                    filteredUsers.Clear();
                }
                else if (this._userView.ContentControl.ItemsSource == ReviewsToShow)
                {
                    ObservableCollection<Review> filteredReview = new ObservableCollection<Review>();
                    foreach (var review in ReviewsToShow)
                    {
                        if (review.ReviewText.ToLower().ToLower().Contains(FilterText.ToLower()) || review.CreationDate.ToString().Contains(FilterText))
                        {
                            filteredReview.Add(review);
                        }
                    }
                    ReviewsToShow.Clear();
                    foreach(var review in filteredReview)
                    {
                        ReviewsToShow.Add(review);
                    }
                    filteredReview.Clear();
                }
            }
            else 
            {
                MessageBox.Show("Nothing to search", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CanSearch(object parameter)
        {
            return true;
        }



        private ICommand _showAddUserCommand;
        public ICommand ShowAddUserCommand => _showAddUserCommand ??= new RelayCommand(ShowAddUser,CanShowAdd);

        private void ShowAddUser(object parameter)
        {
            AddNewUser addView = new AddNewUser();
            addView.DataContext = new AddUserViewModel();
            addView.ShowDialog();
        }
        private bool CanShowAdd(object parameter)
        {
            return true;
        }


        private ICommand _showAddProductCommand;
        public ICommand ShowAddProductCommand => _showAddProductCommand ??= new RelayCommand(ShowAddProduct,CanShowAddProduct);

        private void ShowAddProduct(object parameter)
        {
            AddNewProductView addPView = new AddNewProductView();
            addPView.DataContext = new AddProductViewModel();
            addPView.ShowDialog();
        }

        private bool CanShowAddProduct(object parameter)
        {
            return true;
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

        private ICommand _showCartCommand;
        public ICommand ShowCartCommand => _showCartCommand ??= new RelayCommand(ShowCart, CanShowCart);
        private void ShowCart(object parameter)
        {
            if (Cart.Count == 0)
            {
                MessageBox.Show("Cart is empty","Info",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                CartView cartView = new CartView();
                cartView.DataContext = new CartViewModel(Cart,this);
                cartView.ShowDialog();
            }
        }

        private bool CanShowCart(object parameter)
        {
            return true;
        }


        private ICommand _addToCartCommand;
        public ICommand AddToCartCommand => _addToCartCommand ??= new GenericRelayCommand<Product>(AddToCart,CanAddToCart);
        private void AddToCart(Product product)
        {
            if (product.IsAvailable)
            {
                Cart.Add(product);
                MessageBox.Show("Added to cart","Info",MessageBoxButton.OK,MessageBoxImage.Information); 
            }
            else
            {
                MessageBox.Show("Can't add to cart", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private bool CanAddToCart(Product product)
        {
            return true;
        }

        private ICommand _showOrderDetailsCommand;
        public ICommand ShowOrderDetailsCommand => _showOrderDetailsCommand ??= new GenericRelayCommand<Order>(ShowOrderDetails,CanShowOrderDetails);
        private void ShowOrderDetails(Order order)
        {
            OrderDetailsView detailsView = new OrderDetailsView(EteredUser);
            detailsView.DataContext = new OrderDetailsViewModel(order,EteredUser);
            detailsView.ShowDialog();
        }

        private bool CanShowOrderDetails(Order order)
        {
            return true;
        }

        private ICommand _deleteOrderCommand;
        public ICommand DeleteOrderCommand => _deleteOrderCommand ??= new GenericRelayCommand<Order>(DeleteOrder,CanDeleteOrder);
        private void DeleteOrder(Order order)
        {
            if (App.repository.DeleteOrder(order))
            {
                MessageBox.Show("Order deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to delete","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private bool CanDeleteOrder(Order order)
        {
            return true;
        }


        private ICommand _showMoreProduct;
        public ICommand ShowMoreProduct => _showMoreProduct ?? new GenericRelayCommand<Product>(ShowMoreProd, CanShowMoreProd);
        private void ShowMoreProd(Product product)
        {
            MoreProductView prodview = new MoreProductView(EteredUser);
            prodview.DataContext = new ProductMoreViewModel(product,EteredUser);
            prodview.ShowDialog();
        }

        private bool CanShowMoreProd(Product product)
        {
            return true;
        }


        private int _chosenAmount;
        public int ChosenAmount
        {
            get => _chosenAmount;
            set
            {
                if (_chosenAmount != value)
                {
                    _chosenAmount = value;
                    OnPropertyChanged(nameof(ChosenAmount));
                }
            }
        }

        private ICommand _increment;
        public ICommand IncrementCommand => _increment ??= new RelayCommand(Incr,CanIncr);
        private void Incr(object parameter)
        {
            ChosenAmount +=1;
        }
        private bool CanIncr(object parameter)
        {
            return true;
        }


        private ICommand _decrement;
        public ICommand DecrementCommand => _decrement ??= new RelayCommand(Decr,CanDecr);

        private void Decr(object parameter)
        {
            if(ChosenAmount-1> 0)
            {
                ChosenAmount -= 1;
            }
          
        }
        private bool CanDecr(object parameter)
        {
            return true;
        }


        private ICommand _moreReviewCommand;
        public ICommand MoreReviewCommand => _moreReviewCommand ??= new GenericRelayCommand<Review>(ShowMoreReview,CanShowMoreReview);

        private void ShowMoreReview(Review review)
        {
            ReviewMoreWindow _reviewMore = new ReviewMoreWindow();
            _reviewMore.DataContext = new ReviewMoreViewModel(review,_reviewMore,EteredUser);
            _reviewMore.ShowDialog();
        }

        private bool CanShowMoreReview(Review review)
        {
            return true;
        }

        private decimal _fromPrice = 0;
        public decimal FromPrice
        {
            get=> _fromPrice;
            set
            {
                if(_fromPrice != value)
                {
                    _fromPrice = value;
                    OnPropertyChanged(nameof(FromPrice));
                }
            }
        }

        private decimal _toPrice = 0; 
        public decimal ToPrice
        {
            get=> _toPrice;
            set
            {
                if(_toPrice != value)
                {
                    _toPrice = value; OnPropertyChanged(nameof(ToPrice));
                }
            }
        }

        private ICommand _searchPriceCommand;
        public ICommand SearchPriceCommand => _searchPriceCommand ??= new RelayCommand(SearchPrice,CanSearchPrice);
        private void SearchPrice(object parameter)
        {
            bool validSearch = true;
            if (FromPrice <= 0 || ToPrice <= 0)
            {
                MessageBox.Show("Incorrect Price Range","Fail",MessageBoxButton.OK, MessageBoxImage.Error);
                validSearch = false;
            }
            if (validSearch)
            {
                ObservableCollection<Product> filteredProducts = new ObservableCollection<Product>();
                foreach (var prod in ProductsToShow)
                {
                    if (prod.Price >= FromPrice && prod.Price <= ToPrice)
                    {
                        filteredProducts.Add(prod);
                    }
                }
                ProductsToShow.Clear();
                foreach (var prod in filteredProducts)
                {
                    ProductsToShow.Add(prod);
                }
            }
           
        }
        private bool CanSearchPrice(object parameter)
        {
            return true;
        }
    }

}
