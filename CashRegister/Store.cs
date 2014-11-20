using System.Collections.Generic;

namespace CashRegister
{
    public sealed class Store
    {        
        private readonly Dictionary<string, decimal> _products;
        private Dictionary<string, string> _productsSynonymous; 
        private readonly Discount _discount;
        
        public Store(Dictionary<string, decimal> products)
        {
            products.Check("products");

            _products = new Dictionary<string, decimal>(products);
            _discount = new Discount();          
        }

        public void AddSynonymous(string productName, string synonymous)
        {
            productName.Check("productName");
            synonymous.Check("synonymous");

            if(_productsSynonymous == null) _productsSynonymous = new Dictionary<string, string>();
                
            _productsSynonymous.Add(synonymous, productName);
        }

        public decimal ComputePrice(string productName)
        {
            productName.Check("productName");

            return IsDiscountedProduct(productName) ? 
                HandlePriceDiscounted(productName, HandlePriceMetaProductNameDiscounted())
              : HandlePrice(productName, HandlePriceMetaProductNameDiscounted());         
        }

        public void RegisterDiscountOnFreeProductWhenBuysSameProducts(string productName, uint quantity, uint freeProductsQuantity)
        {
            productName.Check("productName");
            
            _discount.RegisterDiscountOnFreeProductWhenBuysSameProducts(productName, quantity, freeProductsQuantity);
        }

        public void RegisterDiscountRebateForMoreProducts(string productName, uint quantity, decimal rebate)
        {
            productName.Check("productName");
            
            _discount.RegisterDiscountRebateForMoreProducts(productName, quantity, rebate);
        }

        public void RegisterRebateOnMoneyWhenBuysSameProducts(string productName, uint quantity, decimal rebate)
        {
            productName.Check("productName");
          
            _discount.RegisterRebateOnMoneyWhenBuysSameProducts(productName, quantity, rebate);
        }

        public void RegisterRebateOnMoneyWhenBuysQuantityfProducts(string productName, uint quantity, decimal rebate)
        {
            productName.Check("productName");
          
            _discount.RegisterRebateOnMoneyWhenBuysQuantityfProducts(productName, quantity, rebate);
        }

        private decimal HandlePriceDiscounted(string synonymous, decimal currentPrice)
        {
            return ComputetDiscountedProduct(synonymous, GetPriceFromProductName(synonymous)) + currentPrice;
        }
        
        private decimal HandlePrice(string productNameOrSynonymous, decimal currentPrice)
        {
            return GetPriceFromProductName(productNameOrSynonymous) + currentPrice;
        }

        private decimal GetPriceFromProductName(string productNameSynonymous)
        {
            return _products[productNameSynonymous.ToProductName(_productsSynonymous)];
        }

        private decimal HandlePriceMetaProductNameDiscounted()
        {
            return _discount.HandlePriceMetaProductNameDiscounted();
        }

        private decimal ComputetDiscountedProduct(string productName, decimal defaultPrice)
        {
            return _discount.HandleDiscountPrice(productName, defaultPrice);
        }

        private bool IsDiscountedProduct(string productName)
        {
            return _discount.IsDiscounted(productName);
        }        
    }
}