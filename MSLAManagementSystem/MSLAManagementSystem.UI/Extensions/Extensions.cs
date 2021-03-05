using MSLAManagementSystem.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.UI.Extensions
{
    public static class Extensions
    {
        private static int[] pageKindValuesSet = (int[])Enum.GetValues(typeof(PageKind));

        public static PageKind ConvertToPageKind(this string value)
        {
            PageKind result;
            return (Enum.TryParse(value, out result) && Array.BinarySearch(pageKindValuesSet, (int)result) >= 0)
                ? result
                : PageKind.Unknown;
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
        {
            return new ObservableCollection<T>(col);
        }
    }
}
