using System.Windows;



namespace flower.View
{
    public partial class ReviewMoreWindow : Window
    {
        public ReviewMoreWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
