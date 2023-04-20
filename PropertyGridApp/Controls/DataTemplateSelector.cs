using System;
using System.Windows;
using System.Windows.Controls;

namespace PropertyGridApp.Controls
{
    public class PropertyGridValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate DateTimeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var propertyEntry = item as PropertyEntry;

            if (propertyEntry != null)
            {
                if (propertyEntry.PropertyDescriptor.PropertyType == typeof(DateTime))
                {
                    return DateTimeTemplate;
                }
            }

            return DefaultTemplate;
        }
    }

}
