using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public partial class Word
    {

        protected bool check = false;


        public Word(string SWversionname) { if (!checkNameVersion(SWversionname)) throw new NotValidVersionName("Такое имя версии не допустимо"); base.Version = SWversionname;  }
        public override void Execute()
        {
            base.Execute();
            check = true;
        }
        public override string ToString()
        {
            string inf = "Это приложение Word. ";
            if (check == true) inf += "Word запущен.";
            else inf += "Word не запущен. ";
            inf += "Текс внутри:\n";
            inf += text;
            return inf;
        }
    }
}
