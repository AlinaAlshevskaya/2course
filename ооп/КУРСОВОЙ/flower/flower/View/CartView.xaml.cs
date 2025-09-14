using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace flower.View
{

    public partial class CartView : Window
    {
        public CartView()
        {
            InitializeComponent();
        }

        private void MoreCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
