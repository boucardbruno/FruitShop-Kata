using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public sealed class Basket
    {
        private readonly List<string> _productsBought = new List<string>();
        private readonly Store _store;
        
        public Basket(Store store)
        {
            store.Check("store");
           
            _store = store;          
        }
     
        public decimal Price()
        {
            var price = _productsBought.Sum(productName => _store.ComputePrice(productName));
            _store.ResetDiscounts();
            return price;
        }

        public void AddProducts(string productName, uint quantity)
        {
            productName.Check("productName");
            
            for (var i = 0; i < quantity; i++)
            {
                _productsBought.Add(productName);
            }  
        }

        public void AddBatch(string batch)
        {
            batch.Check("batch");

            foreach (var productName in batch.Split(','))
            {
                _productsBought.Add(productName.Trim());
            }
        }
    }
} 