using DAL;
using flower.Helpers;
using Microsoft.Win32;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace flower.ViewModel
{
    public class AddProductViewModel
    {
        public AddProductViewModel()
        {
            Categories = new ObservableCollection<string>(App.repository.GetAllCategoryNames());
            Colors = new ObservableCollection<string>(App.repository.GetAllColorsNames());
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        private string _productDescription;
        public string ProductDescription
        {
            get => _productDescription;
            set
            {
                if (_productDescription != value)
                {
                    _productDescription = value;
                    OnPropertyChanged(nameof(ProductDescription));
                }
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value; OnPropertyChanged(nameof(Price));
                }
            }
        }

        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }



        private string _photopath;
        public string PhotoPath
        {
            get => _photopath;
            set
            {
                if (_photopath != value)
                {
                    var dialog = new OpenFileDialog
                    {
                        Filter = "Изображения (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Все файлы (*.*)|*.*",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    };

                    if (dialog.ShowDialog() == true)
                    {
                        _photopath = dialog.FileName.Replace("\\", "/");
                        OnPropertyChanged(nameof(_photopath));
                    }

                }
            }
        }


        private ObservableCollection<string> _categories;
        public ObservableCollection<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        private ObservableCollection<string> _colors;
        public ObservableCollection<string> Colors
        {
            get => _colors;
            set
            {
                _colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }


        private ICommand _saveProductCommand;
        public ICommand SaveProductCommand => _saveProductCommand ??= new RelayCommand(SaveProject, CanSaveProject);
        private void SaveProject(object parameter)
        {
            string MessageBoxText = "Something went wrong";
            Product newProduct = new Product(ProductName, ProductDescription, Amount, Price, PhotoPath);
            bool passedChecks = true;
            if (Price == 0)
            {
                passedChecks = false;
                MessageBoxText = "Invalid Price";

            }
            if (Amount == 0)
            {
                passedChecks = false;
                MessageBoxText = "invalid Amount";
            }
            if (ProductName is null||ProductDescription is null)
            {
                passedChecks = false;
                MessageBoxText = "Not full data";
            }
            if(PhotoPath is null)
            {
                passedChecks = false;
                MessageBoxText = "Photo path missing";
            }
            if (passedChecks)
            {
                if (App.repository.AddProduct(newProduct))
                {
                    MessageBox.Show("Product added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Fail", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                foreach (var category in Categories)
                {

                    newProduct.ProductCategories.Add(new ProductCategory
                    {
                        CategoryId = App.repository.GetCategoryByName(category).CategoryId
                    });

                }
                // Добавляем выбранные цвета
                foreach (var color in Colors)
                {
                    newProduct.ProductColors.Add(new ProductColor
                    {
                        ColorId = App.repository.GetColorByName(color).ColorId
                    });
                }
            }
            else
            {
                MessageBox.Show($"{MessageBoxText}","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
           
           

        }

        private bool CanSaveProject(object parameter)
        {
            return true;
        }
    }
}
