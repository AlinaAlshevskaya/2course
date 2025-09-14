
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        public string UserName { get; set; }
        public string UserSurename { get;set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }

        public string ImagePath { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();


        public User(string UserName,string UserSurename,string Password,string Email,string PhoneNumber,bool IsAdmin)
        {
            this.UserName = UserName;
            this.UserSurename = UserSurename;
            this.Password = Password;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.IsAdmin = IsAdmin;
            this.Address = "No";
            this.ImagePath = "No";
        }
        public User() { }
    }
}
