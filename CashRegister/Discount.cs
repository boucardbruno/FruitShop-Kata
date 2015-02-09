using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    internal sealed class Discount
    {
        private readonly Dictionary<string, Discountable> _rulesDiscountedProducts = new Dictionary<string, Discountable>();
        private readonly Dictionary<string, Discountable> _rulesDiscountedMetaProducts = new Dictionary<string, Discountable>();

        internal void RegisterRebateOnMoneyWhenBuysQuantityfProducts(string productName, uint quantity, decimal rebate)
        {
            _rulesDiscountedMetaProducts.Add(productName, new DiscountRebateForMoreProducts(quantity, rebate));
        }

        internal void RegisterRebateOnMoneyWhenBuysSameProducts(string product, uint quantity, decimal rebate)
        {
            _rulesDiscountedProducts.Add(product, new DiscountRebateForMoreProductsForThisPrice(quantity, rebate));
        }

        internal void RegisterDiscountRebateForMoreProducts(string productName, uint quantity, decimal rebate)
        {
            _rulesDiscountedProducts.Add(productName, new DiscountRebateForMoreProducts(quantity, rebate));
        }

        internal void RegisterDiscountOnFreeProductWhenBuysSameProducts(string productName, uint quantity, uint freeProductsQuantity)
        {
            _rulesDiscountedProducts.Add(productName, new DiscountPayLessForMoreProducts(quantity, freeProductsQuantity));
        }
              
        internal decimal HandlePriceMetaProductNameDiscounted(decimal defaultPrice = 0)
        {
            return _rulesDiscountedMetaProducts.Values.Sum(strategy => strategy.Price(defaultPrice));
        }
       
        internal decimal HandleDiscountPrice(string productName, decimal defaultPrice)
        {
            return _rulesDiscountedProducts[productName].Price(defaultPrice);
        }

        internal bool IsDiscounted(string productName)
        {
            return _rulesDiscountedProducts.ContainsKey(productName);
        }

        public void Reset()
        {
            foreach (var rule in _rulesDiscountedProducts.Values)
            {
                rule.Reset();
            }
        }
    }
}


   