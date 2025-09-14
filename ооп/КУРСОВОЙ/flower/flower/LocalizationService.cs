using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows;

namespace flower
{
 

    public static class LocalizationService
    {
        private static ResourceDictionary _currentDictionary;

        public static void SetLanguage(string cultureCode)
        {
            string dictPath = $"Resources/StringResources.{cultureCode}.xaml";

            var dict = new ResourceDictionary()
            {
                Source = new Uri(dictPath, UriKind.Relative)
            };

            if (_currentDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(_currentDictionary);
            }

            Application.Current.Resources.MergedDictionaries.Add(dict);
            _currentDictionary = dict;
        }
    }

}
