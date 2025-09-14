using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace flower.View
{
    public partial class MoreProductView : Window
    {
        public MoreProductView(User user)
        {
            InitializeComponent();
            if (user.IsAdmin)
            {
                this.controlButtons.Visibility = Visibility.Visible;
                this.GetName.IsEnabled = true;
                this.GetDec.IsEnabled = true;
                this.GetPrice.IsEnabled = true;
                this.GetAmount.IsEnabled = true;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MoreCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
