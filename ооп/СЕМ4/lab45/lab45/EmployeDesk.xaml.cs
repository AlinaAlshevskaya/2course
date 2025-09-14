using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab45
{
    /// <summary>
    /// Логика взаимодействия для UserDesk.xaml
    /// </summary>
    public partial class EmployeDesk : Window
    {
        bool isCollapsed;
        public List<object> products;
        private MainWindow regwin;
        private Autorisation vxodwin;

        public EmployeDesk()
        {
            InitializeComponent();
            filterpanel.Visibility = Visibility.Collapsed;


        }
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
                filterpanel.Visibility = Visibility.Visible;
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
                filterpanel.Visibility = Visibility.Collapsed;
                Gridfilterpanel.Width = new GridLength(0);

            }

        }

        private void backtoAu_Click(object sender, RoutedEventArgs e)
        {

            Autorisation AuthWind = new Autorisation
            {
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };
            AuthWind.Show();
            Close();
        }
         
        public void LoadProducts()
        {
            var json = File.ReadAllText("D:\\Documents\\ооп\\СЕМ4\\lab45\\pics\\products.json");
            var products = JsonConvert.DeserializeObject<List<Products>>(json);
            var grid = new Grid();
             

            for (int i = 0; i < (products.Count + 3) / 4; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 4; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int currentRow = 0, currentCol = 0;

            foreach (var product in products)
            {
                var border = new Border
                {
                    CornerRadius = new CornerRadius(8),
                    Background = Brushes.White,
                    BorderBrush = Brushes.LightGray,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(10)
                };

                var stack = new StackPanel();

                var image = new Image
                {
                    Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Absolute)),
                    Stretch = Stretch.Uniform,
                    Height = 100,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var name = new TextBlock
                {
                    Text = product.Name,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(10, 5, 10, 0),
                    Height = 40,
                    TextAlignment = TextAlignment.Right,
                    TextWrapping = TextWrapping.Wrap
                };

                var description = new TextBlock
                {
                    Text = product.Description,
                    Foreground = Brushes.Gray,
                    Margin = new Thickness(10, 5, 10, 5),
                    TextAlignment = TextAlignment.Right
                };
                var price = new TextBlock
                {
                    Text = product.Price.ToString(),
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(10, 5, 10, 0),
                    Height = 40,
                    TextAlignment = TextAlignment.Right,
                    TextWrapping = TextWrapping.Wrap
                };
                var stackForButtons = new StackPanel();
                stackForButtons.Orientation = Orientation.Horizontal;

                var buttonBye = new Button
                {
                    Content = "Купить",
                    Margin = new Thickness(5, 1, 5, 5),
                    Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#A578BB"),
                    Foreground = Brushes.White,
                    Height = 30,
                    BorderThickness = new Thickness(0)
                };
                var buttonAbout = new Button
                {
                    Content = "Подробнее",
                    Margin = new Thickness(5, 1, 5, 5),
                    Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#A578BB"),
                    Foreground = Brushes.White,
                    Height = 20,
                    BorderThickness = new Thickness(0)
                };
                stackForButtons.Children.Add(buttonBye);
                stackForButtons.Children.Add(buttonAbout);

                stack.Children.Add(image);
                stack.Children.Add(description);
                stack.Children.Add(name);
                stack.Children.Add(stackForButtons);

                border.Child = stack;

                Grid.SetRow(border, currentRow);
                Grid.SetColumn(border, currentCol);
                grid.Children.Add(border);

                currentCol++;
                if (currentCol >= 4)
                {
                    currentCol = 0;
                    currentRow++;
                }
            }


            CatalogPanel.Children.Clear();
            CatalogPanel.Children.Add(grid);
        }

        bool isckickedCategories = true;
        private void ButtonShowCategories_Click(object sender, RoutedEventArgs e)
        {
            if (isckickedCategories)
            {
                isckickedCategories = false;
                CatecoriesCatalog.Visibility = Visibility.Collapsed;
                iconforbuttonshow.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowDownBox;
            }
            else
            {
                isckickedCategories = true;
                CatecoriesCatalog.Visibility = Visibility.Visible;
                iconforbuttonshow.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowUpBox;
            }

        }
        bool isckickedColors = true;
        private void ButtonShowColors_Click(object sender, RoutedEventArgs e)
        {
            if (isckickedColors)
            {
                isckickedColors = false;
                ColorCatalog.Visibility = Visibility.Collapsed;
                iconforbuttonshowcolor.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowDownBox;
            }
            else
            {
                isckickedColors = true;
                ColorCatalog.Visibility = Visibility.Visible;
                iconforbuttonshowcolor.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowUpBox;
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts();
            filterpanel.Visibility = Visibility.Visible;
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
        }

        public void LoadCategories()
        {

        }
    }
}
