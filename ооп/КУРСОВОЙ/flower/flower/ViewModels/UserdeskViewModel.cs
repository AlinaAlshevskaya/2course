using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using flower.Data;
using flower.Models;

namespace flower.ViewModels
{
    public enum UserdeskSection { Products, Customers, Orders, Reviews }


    public class SelectableCategory : Category, INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected { get => _isSelected; set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } } }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public class SelectableColor : Color, INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected { get => _isSelected; set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } } }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public class UserdeskViewModel : INotifyPropertyChanged
    {
        private readonly Context _context;
        private UserdeskSection _currentSection = UserdeskSection.Products;

        public UserdeskSection CurrentSection
        {
            get => _currentSection;
            set
            {
                if (_currentSection != value)
                {
                    _currentSection = value;
                    OnPropertyChanged();
                    OnSectionChanged();
                }
            }
        }

        private decimal? _priceFrom;
        public decimal? PriceFrom
        {
            get => _priceFrom;
            set { if (_priceFrom != value) { _priceFrom = value; OnPropertyChanged(); RefreshProducts(); } }
        }

        private decimal? _priceTo;
        public decimal? PriceTo
        {
            get => _priceTo;
            set { if (_priceTo != value) { _priceTo = value; OnPropertyChanged(); RefreshProducts(); } }
        }

        public ObservableCollection<Product> Products { get; private set; } = new();
        public ObservableCollection<SelectableCategory> Categories { get; private set; } = new();
        public ObservableCollection<SelectableColor> Colors { get; private set; } = new();

        public ICommand ShowProductsCommand { get; }
        public ICommand ShowCustomersCommand { get; }
        public ICommand ShowOrdersCommand { get; }
        public ICommand ShowReviewsCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand ToggleMenuCommand { get; }

        private double _menuWidth = 200;
        public double MenuWidth
        {
            get => _menuWidth;
            set { if (_menuWidth != value) { _menuWidth = value; OnPropertyChanged(); } }
        }

        public UserdeskViewModel()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseSqlServer("Server=DESKTOP-T12FKAO\\SQLEXPRESS;Database=FlowerShop;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _context = new Context(options);

            ShowProductsCommand = new RelayCommand(_ => CurrentSection = UserdeskSection.Products);
            ShowCustomersCommand = new RelayCommand(_ => CurrentSection = UserdeskSection.Customers);
            ShowOrdersCommand = new RelayCommand(_ => CurrentSection = UserdeskSection.Orders);
            ShowReviewsCommand = new RelayCommand(_ => CurrentSection = UserdeskSection.Reviews);
            AddToCartCommand = new RelayCommand(param => AddToCart(param as Product));
            ToggleMenuCommand = new RelayCommand(_ => ToggleMenu());

            LoadFilters();
            RefreshProducts();
        }

        private void LoadFilters()
        {
            var cats = _context.Categories.AsNoTracking().ToList();
            Categories = new ObservableCollection<SelectableCategory>(cats.Select(c => new SelectableCategory { IdCategory = c.IdCategory, Category1 = c.Category1 }));
            var cols = _context.Colors.AsNoTracking().ToList();
            Colors = new ObservableCollection<SelectableColor>(cols.Select(c => new SelectableColor { IdColorName = c.IdColorName, ColorName = c.ColorName }));

            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(Colors));
        }

        private void RefreshProducts()
        {
            if (CurrentSection != UserdeskSection.Products) return;

            var query = _context.Products.AsNoTracking().Include(p => p.IdCategoryNavigation).Include(p => p.IdColorNameNavigation).AsQueryable();

            // Фильтр по цене
            if (PriceFrom.HasValue) query = query.Where(p => p.Price >= Convert.ToDouble(PriceFrom.Value));
            if (PriceTo.HasValue) query = query.Where(p => p.Price <= Convert.ToDouble(PriceTo.Value));

            // Фильтр по категориям
            var catsSelected = Categories.Where(c => c.IsSelected).Select(c => c.IdCategory).ToList();
            if (catsSelected.Any())
                query = query.Where(p => catsSelected.Contains(p.IdCategory));

            // Фильтр по цветам
            var colsSelected = Colors.Where(c => c.IsSelected).Select(c => c.IdColorName).ToList();
            if (colsSelected.Any())
                query = query.Where(p => colsSelected.Contains(p.IdColorName));

            Products = new ObservableCollection<Product>(query.ToList());
            OnPropertyChanged(nameof(Products));
        }

        private void OnSectionChanged()
        {
            if (CurrentSection == UserdeskSection.Products)
            {
                RefreshProducts();
                IsFilterVisible = true;
            }
            else
            {
                IsFilterVisible = false;
            }
            OnPropertyChanged(nameof(IsFilterVisible));
        }

        private void AddToCart(Product? product)
        {
            if (product == null) return;
            // TODO: Реализуйте добавление товара в корзину, уведомление и т.п.
            System.Windows.MessageBox.Show($"Добавлено в корзину: {product.Name}");
        }

        private void ToggleMenu()
        {
            MenuWidth = MenuWidth == 200 ? 50 : 200;
        }

        private bool _isFilterVisible = true;
        public bool IsFilterVisible
        {
            get => _isFilterVisible;
            set { if (_isFilterVisible != value) { _isFilterVisible = value; OnPropertyChanged(); } }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}