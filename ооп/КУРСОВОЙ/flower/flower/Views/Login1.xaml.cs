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
using flower.ViewModels;

namespace flower.Views
{
    /// <summary>
    /// Логика взаимодействия для Login1.xaml
    /// </summary>
    public partial class Login1 : Window
    {
        public Login1()
        {
            InitializeComponent();
            var vm = new LoginWindowViewModel();
            DataContext = vm;

            vm.RequestClose += () => this.Close();
        }

        private string currentCulture = "ru";
        private void LanguageToggleButton_Click(object sender, RoutedEventArgs e)
        {
            // Переключаем между "ru" и "en"
            currentCulture = currentCulture == "ru" ? "en" : "ru";

            // Применяем новый язык
            LocalizationService.SetLanguage(currentCulture);

            // Можно обновить текст кнопки, если нужно
            if (sender is Button btn)
            {
                btn.Content = currentCulture == "ru" ? "English" : "Русский";
            }
        }
    }
}
