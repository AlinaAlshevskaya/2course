using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace flower.Helpers
{
    public static class ValidationPatterns

    {

        // Pattern for names and surnames (Russian and Latin letters)

        public const string NamePattern = @"^[A-Za-zА-Яа-яЁё\s'-]+$";

        // Pattern for email validation

        public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Pattern for password validation (at least 4 characters and at least one uppercase letter)

        public const string PasswordPattern = @"^(?=.*[A-Z]).{4,}$";

        public const string numberPattern = @"^[0-10]";

        public const string phonePattern = @"^\+375\d{9}$";
    }
    public class Validator
    {
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, ValidationPatterns.NamePattern);
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, ValidationPatterns.EmailPattern);
        }

        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, ValidationPatterns.PasswordPattern);
        }


        public static bool IsValidNumber(string number)
        {
            return Regex.IsMatch(number,ValidationPatterns.numberPattern);
        }
    }
}
