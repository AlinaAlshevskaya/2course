
using Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DAL
{

    public interface IRepository : IDisposable
    {
        public ObservableCollection<User> GetAllUsers();
        public User? GetUserById(int id);
        public ObservableCollection<Order> GetAllOrdersByUserId(int UserId);
        public ObservableCollection<Review> GetAllReviewsByUserId(int UserId);
        public bool AddUser(User user);
        public bool UpdateUser(User updUser, int id);
        public bool DeleteUser(int id);

        //---------//
        public ObservableCollection<Product> GetAllProducts();


        //----------//
        public ObservableCollection<Review> GetAllReviews();
        public ObservableCollection<Review> GetReviewsByUserId(int id);
        public bool DeleteReviewsByUserId(int id);

        //----------//
        public ObservableCollection<Order> GetAllOrders();
        public ObservableCollection<Order> GetOrdersByUserId(int UserId);
        public bool AddOrder(Order order);
        public bool DeleteOrder(Order order);

        public bool DeleteOrdersByUserId(int id);
        //----------//
        public ObservableCollection<Category> GetAllCategories();
        public Category? GetCategoryById(int id);

        //----------//
        public ObservableCollection<Color> GetAllColors();

        public bool AddOrderDetails(OrderDetails orderDetails);
    }
    public class Repository : IRepository
    {
        Context _context { get; set; }
        public Repository(Context context) { this._context = context; }


        public ObservableCollection<User> GetAllUsers()
        {
            return new ObservableCollection<User>(this._context.Users.ToList());
        }

        public User? GetUserById(int id)
        {
            return this._context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public ObservableCollection<Order> GetAllOrdersByUserId(int UserId)
        {
            return new ObservableCollection<Order>(this._context.Orders.Where(o => o.UserId == UserId));
        }

        public ObservableCollection<Review> GetAllReviewsByUserId(int UserId)
        {
            return new ObservableCollection<Review>(this._context.Reviews.Where(r => r.UserId == UserId));
        }


        public bool AddUser(User user)
        {
            if (this._context.Users.Add(user) is not null)
            {
                this._context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool UpdateUser(User updUser, int id)
        {
            User? userToUpdate = this._context.Users.FirstOrDefault(u => u.UserId == id);
            if (userToUpdate is not null)
            {
                userToUpdate.UserName = updUser.UserName;
                userToUpdate.UserSurename = updUser.UserSurename;
                userToUpdate.Email = updUser.Email;
                userToUpdate.PhoneNumber = updUser.PhoneNumber;
                this._context.Update(userToUpdate);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteUser(int id)
        {
            User? userToDelete = this._context.Users.FirstOrDefault(u => u.UserId == id);
            if (userToDelete is not null)
            {
                DeleteReviewsByUserId(id);
                DeleteOrdersByUserId(id);
                this._context.Users.Remove(userToDelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //--------------//
        public ObservableCollection<Product> GetAllProducts()
        {
            return new ObservableCollection<Product>(this._context.Products.ToList());
        }
        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            // Добавляем продукт в контекст
            this._context.Products.Add(product);
            // Сохраняем изменения в базе данных
            int changes = this._context.SaveChanges();
            return changes > 0; // Возвращаем true, если изменения были сохранены
        }

        public ObservableCollection<Review> GetAllReviews()
        {
            return new ObservableCollection<Review>(this._context.Reviews.ToList());
        }
        public ObservableCollection<Review> GetReviewsByUserId(int id)
        {
            return new ObservableCollection<Review>(this._context.Reviews.Where(r => r.UserId == id));
        }

        public bool DeleteReviewsByUserId(int id)
        {
            Review? reviewToDelete = this._context.Reviews.FirstOrDefault(r => r.UserId == id);
            if (reviewToDelete is not null)
            {
                this._context.Reviews.Remove(reviewToDelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //----------//
        public ObservableCollection<Order> GetAllOrders()
        {
            return new ObservableCollection<Order>(this._context.Orders.ToList());
        }
        public ObservableCollection<Order> GetOrdersByUserId(int UserId)
        {
            return new ObservableCollection<Order>(this._context.Orders.Where(o => o.UserId == UserId).ToList());
        }

        public bool AddOrder(Order order)
        {
            if (this._context.Orders.Add(order) is not null)
            {
                try
                {
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteOrder(Order order)
        {
            DeleteReviewByOrderId(order.OrderId);
            DeleteOrderDetailByOrderId(order.OrderId);
            if (this._context.Orders.Remove(order) is not null)
            {

                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdOrderStatus(string status, int id)
        {
            Order? toUpd = this._context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (toUpd is not null)
            {
                toUpd.OrderStatus = status;
                this._context.Update(toUpd);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteOrderDetailByOrderId(int OrderId)
        {
            OrderDetails? details = this._context.OrderDetails.FirstOrDefault(o => o.OrderId == OrderId);
            if (details is not null)
            {

                try
                {
                    this._context.OrderDetails.Remove(details);
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.Write(ex);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteReviewByOrderId(int OrderId)
        {
            Review? reviw = this._context.Reviews.FirstOrDefault(r => r.OrderId == OrderId);
            if (reviw is not null)
            {
                this._context.Reviews.Remove(reviw);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteOrdersByUserId(int id)
        {
            Order? orderToDelete = this._context.Orders.FirstOrDefault(o => o.UserId == id);
            if (orderToDelete is not null)
            {
                this._context.Orders.Remove(orderToDelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //----------//
        public ObservableCollection<Category> GetAllCategories()
        {
            return new ObservableCollection<Category>(this._context.Categories.ToList());
        }

        public ObservableCollection<string> GetAllCategoryNames()
        {
            return new ObservableCollection<string>(this._context.Categories.Select(c => c.CategoryName).ToList());
        }
        public Category? GetCategoryById(int id)
        {
            return this._context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
        //----------//
        public ObservableCollection<Color> GetAllColors()
        {
            return new ObservableCollection<Color>(this._context.Colors.ToList());
        }
        public ObservableCollection<string> GetAllColorsNames()
        {
            return new ObservableCollection<string>(this._context.Colors.Select(c => c.ColorName).ToList());
        }
        public Category? GetCategoryByName(string categoryName)
        {

            return this._context.Categories.FirstOrDefault(c => c.CategoryName.ToLower() == categoryName.ToLower());
        }

        public Color? GetColorByName(string colorName)
        {
            return this._context.Colors.FirstOrDefault(c => c.ColorName.ToLower() == colorName.ToLower());
        }


        public bool AddOrderDetails(OrderDetails orderDetails)
        {
            if (this._context.OrderDetails.Add(orderDetails) is not null)
            {
                try
                {
                    this._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool AddReview(Review review)
        {
            if (this._context.Reviews.Add(review) is not null)
            {
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product, int id)
        {
            Product? toUpdate = this._context.Products.FirstOrDefault(p => p.ProductId == id);
            if (toUpdate is not null)
            {
                toUpdate.ProductName = product.ProductName;
                toUpdate.ProductDescription = product.ProductDescription;
                toUpdate.Amount = product.Amount;
                toUpdate.Price = product.Price;
                this._context.Products.Update(toUpdate);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            Product? todelete = this._context.Products.FirstOrDefault(p => p.ProductId == id);

            if (todelete is not null)
            {
                this._context.Products.Remove(todelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Order?GetOrderByReviewOrderId(int revOrdId)
        {
            return this._context.Orders.FirstOrDefault(o=>o.OrderId==revOrdId);
        }

        public bool DeleteReviewByReviewId(int id)
        {
            Review?toDelete = this._context.Reviews.FirstOrDefault(o=>o.ReviewId==id);
            if(toDelete is not null)
            {
                this._context.Reviews.Remove(toDelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Dispose() { }
    }
}
