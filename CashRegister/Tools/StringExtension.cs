using System.Collections.Generic;

namespace CashRegister
{
    static public class StringExtension
    {
        public static string ToProductName(this string productName, Dictionary<string, string> productsSynonymous)
        {
            if (productsSynonymous != null && productsSynonymous.ContainsKey(productName))
            {
                return productsSynonymous[productName];
            }
            return productName;
        }

        public static bool IsProductNameFamily(this string productName)
        {
            return productName.Contains(MetaConstants.Any);
        }

        public static bool IsProductNameCaterory(this string productName)
        {
            return productName.Equals(MetaConstants.Fruits);
        }

        public static bool IsProductNameRegular(this string productName)
        {
            return !productName.IsProductNameCaterory() && ! productName.IsProductNameFamily();
        }
    }
}