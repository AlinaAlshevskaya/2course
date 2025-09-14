using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7 { 
        public class Exceptions
        {
            public static void Handle(Exception ex)
            {
                if (ex is NotValid notValid) { Console.WriteLine($"Тип Ошибки: {notValid.Type}"); }
                if (ex is NotExecute notExecute) { Console.WriteLine($"Тип Ошибки: {notExecute.Type}"); }
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");

            }
        }

        public class NotValid : Exception
        {
            public readonly string Type = "Not Valid";
            public NotValid() { }
            public NotValid(string message) : base(message) { }
        }
        public class NotValidVersionName : NotValid
        {

            public NotValidVersionName() { }
            public NotValidVersionName(string message) : base(message) { }
        }
        public class NotValidElement : NotValid
        {
            public readonly string Type = "Not Execute";
            public NotValidElement() { }
            public NotValidElement(string message) : base(message) { }
        }

        public class NotValidTextLength : NotValid
        {

            public NotValidTextLength() { }
            public NotValidTextLength(string message) : base(message) { }
        }
    public class NotExecute : Exception
    {
        public readonly string Type = "Not Execute";
        public NotExecute() { }
        public NotExecute(string message) : base(message) { }
    }

}
