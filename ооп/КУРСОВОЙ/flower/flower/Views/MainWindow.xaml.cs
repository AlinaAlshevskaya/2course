using flower.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace flower.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string currentCulture = "ru";

    public MainWindow()
    {
        InitializeComponent();

        LocalizationService.SetLanguage("ru"); // Ваш сервис локализации, если есть. Если нет - можно убрать.

        var vm = new MainWindowViewModel();
        DataContext = vm;
        vm.RequestClose += () => this.Close();
    }

    private void LanguageToggleButton_Click(object sender, RoutedEventArgs e)
    {
        currentCulture = currentCulture == "ru" ? "en" : "ru";
        LocalizationService.SetLanguage(currentCulture); // если есть сервис локализации

        //if (DataContext is MainWindowViewModel vm)
        //    vm.ChangeLanguage(currentCulture);

        if (sender is Button btn)
            btn.Content = currentCulture == "ru" ? "English" : "Русский";
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm && sender is PasswordBox pb)
            vm.Password = pb.Password;
    }
}
