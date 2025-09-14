using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace flower.View
{

    public partial class OrderDetailsView : Window
    {
        public OrderDetailsView(User user)
        {
            InitializeComponent();
            if (user.IsAdmin)
            {
                this.SetStatus.Visibility = Visibility.Visible;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
