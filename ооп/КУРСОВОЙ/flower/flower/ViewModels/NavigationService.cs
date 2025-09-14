using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using flower.Views;

namespace flower.ViewModels
{
   


    public static class NavigationService
    {
        public static void ShowLoginWindow()
        {
            var loginWindow = new Login1();
            loginWindow.Show();

        }


        public static void ShowMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

        }
    }

}
