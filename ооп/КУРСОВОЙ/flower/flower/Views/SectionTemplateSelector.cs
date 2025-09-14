

using System.Windows;
using System.Windows.Controls;
using flower.ViewModels;

namespace flower.Views
{
    public class SectionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? ProductsTemplate { get; set; }
        public DataTemplate? CustomersTemplate { get; set; }
        public DataTemplate? OrdersTemplate { get; set; }
        public DataTemplate? ReviewsTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            if (item is UserdeskViewModel vm)
            {
                return vm.CurrentSection switch
                {
                    UserdeskSection.Products => ProductsTemplate,
                    UserdeskSection.Customers => CustomersTemplate,
                    UserdeskSection.Orders => OrdersTemplate,
                    UserdeskSection.Reviews => ReviewsTemplate,
                    _ => base.SelectTemplate(item, container),
                };
            }
            return base.SelectTemplate(item, container);
        }
    }
}
