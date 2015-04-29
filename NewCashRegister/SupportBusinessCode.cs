using System.Collections.Generic;
using CashRegister;

namespace NewCashRegister
{
    internal sealed class SupportBusinessCode
    {
        private Basket _basket;
        private Store _store;

        internal void FillTheStore(Dictionary<string, decimal> products)
        {
            _store = new Store(products);
            _basket = new Basket(_store);
        }

        internal decimal Price 
        {
            get { return _basket.Price(); } 
        }

        internal void BuyProducts(string productName, uint quantity)
        {
            _basket.Add(productName, quantity);         
        }

        internal void RegisterDiscountBasedOnFreeProductWhenCustomerBuysSeveralSameProducts(string productName, uint quantity, uint freeProductsQuantity)
        {
            _store.RegisterDiscountOnFreeProductWhenBuysSameProducts(productName, quantity, freeProductsQuantity);
        }
       
        internal void RegisterRebateBasedOnMoneyWhenCustomerBuysSeveralSameProducts(string productName, uint quantity, decimal rebate)
        {
            _store.RegisterRebateOnMoneyWhenBuysSameProducts(productName, quantity, rebate);
        }

        internal void RegisterRebateOnMoneyWhenBuysQuantityfProducts(string productName, uint quatity, decimal rebate)
        {
            _store.RegisterRebateOnMoneyWhenBuysQuantityfProducts(productName, quatity, rebate);
        }

        internal void RegisterDiscountRuleRebateOnRegularProductName(string productName, uint quantity, decimal rebate)
        {
            _store.RegisterDiscountRebateForMoreProducts(productName, quantity, rebate);
        }

        public void AddSynonymous(string productName, string synonymous)
        {          
            _store.AddSynonymous(productName, synonymous);            
        }
    }
}