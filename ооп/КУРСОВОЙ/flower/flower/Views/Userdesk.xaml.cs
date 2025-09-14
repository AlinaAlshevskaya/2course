using System.Windows;
using flower.Models;
using flower.ViewModels;

namespace flower.Views
{
    public partial class Userdesk : Window
    {
        private readonly UserdeskViewModel _viewModel;

        public Userdesk()
        {
            InitializeComponent();

            _viewModel = new UserdeskViewModel();

            DataContext = _viewModel;
        }
        private bool isCollapsed = false;
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (!isCollapsed)
            {

                isCollapsed = true;
                GridControlPanel.Width = new GridLength(50);
                controlPanel.Width = 50;
                foto.Visibility = Visibility.Hidden;
                userName.Visibility = Visibility.Collapsed;
                seporator.Visibility = Visibility.Collapsed;
                Customers.Visibility = Visibility.Collapsed;
                Orders.Visibility = Visibility.Collapsed;
                Feedbacks.Visibility = Visibility.Collapsed;
                Products.Visibility = Visibility.Collapsed;
                backtoAu.Width = 30;
                backtoAu.Height = 30;
                FilterPanel.Visibility = Visibility.Visible;
                Gridfilterpanel.Width = new GridLength(200);
            }
            else if (isCollapsed)
            {
                isCollapsed = false;

                GridControlPanel.Width = new GridLength(200);
                controlPanel.Width = 200;
                foto.Visibility = Visibility.Visible;
                userName.Visibility = Visibility.Visible;
                seporator.Visibility = Visibility.Visible;
                Customers.Visibility = Visibility.Visible;
                Orders.Visibility = Visibility.Visible;
                Feedbacks.Visibility = Visibility.Visible;
                Products.Visibility = Visibility.Visible;
                backtoAu.Width = 30;
                backtoAu.Height = 30;
                FilterPanel.Visibility = Visibility.Collapsed;
                Gridfilterpanel.Width = new GridLength(0);

            }

        }
    }
}