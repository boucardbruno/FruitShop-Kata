using System.Collections.Generic;
using CashRegister;
using NUnit.Framework;

namespace FruitShop
{
    [TestFixture]
    public class BasicLoopTests
    {
        private Store _store;
        private Basket _basket;

        private readonly Dictionary<string, decimal> _products = new Dictionary<string, decimal>
        {
            {"Pommes", 100},
            {"Bananes", 150},
            {"Cerises", 75},
        };
                
        private void SupportLocalization()
        {
            _store.AddSynonymous("Pommes", "Apples");
            _store.AddSynonymous("Pommes", "Mele");
        }

        [SetUp]
        public void Setup()
        {
            _store = new Store(_products);
            _basket = new Basket(_store);
        }

        [Test]
        public void Should_compute_the_expected_price_when_a_customer_buys_few_articles()
        {
            // Iteration 1 - Vérifications
            _basket.AddProducts("Cerises", 2);
            _basket.AddProducts("Pommes", 2);
            _basket.AddProducts("Bananes", 1);

            Assert.AreEqual(500, _basket.Price());
        }

        [Test]
        public void Should_apply_20_cents_discount_for_2_batches_of_cerises_when_a_customer_buys_some_articles()
        {
            // Iteration 2 - Vérifications
            _store.RegisterDiscountRebateForMoreProducts("Cerises", 2, 20);
            _basket.AddProducts("Cerises", 4);
            _basket.AddProducts("Pommes", 2);
            _basket.AddProducts("Bananes", 1);
 
            Assert.AreEqual(610, _basket.Price());
        }

        [Test]
        public void Should_support_new_CSV_input_when_we_price_some_articles()
        {
            // Iteration 3 - Tests
            _store.RegisterDiscountRebateForMoreProducts("Cerises", 2, 20);
            _basket.AddBatch("Pommes, Cerises, Bananes");
            _basket.AddBatch("Pommes");

            Assert.AreEqual(425, _basket.Price());
        }

       
        [Test]
        public void Should_implement_new_reductions_when_we_price_some_articles()
        {
            // Iteration 3' - Vérifications
            _store.RegisterDiscountRebateForMoreProducts("Cerises", 2, 30);
            _store.RegisterDiscountOnFreeProductWhenBuysSameProducts("Bananes", 2, 1);
         
            _basket.AddProducts("Cerises", 3);            
            _basket.AddProducts("Pommes", 2);         
            _basket.AddProducts("Bananes", 2);
             
            Assert.AreEqual(545, _basket.Price());
        }

        [Test]
        public void Should_support_new_localization_when_we_price_some_product_name_in_italian_and_english()
        {
            // Iteration 4 - Vérifications
            SupportLocalization();

            _store.RegisterDiscountRebateForMoreProducts("Cerises", 2, 20);
            _store.RegisterDiscountOnFreeProductWhenBuysSameProducts("Bananes", 2, 1);

            _basket.AddProducts("Cerises", 2);
            _basket.AddProducts("Apples", 1);
            _basket.AddProducts("Bananes", 1);
            _basket.AddProducts("Pommes", 1);
            _basket.AddProducts("Mele", 1);

            Assert.AreEqual(580, _basket.Price());
        }
        
        [Test]
        public void Should_add_new_discounts_about_Apples_and_about_Mele_when_we_price()
        {
            // Iteration 5' - Vérifications
            SupportLocalization();

            _store.RegisterDiscountRebateForMoreProducts("Cerises", 2, 20);
            _store.RegisterDiscountOnFreeProductWhenBuysSameProducts("Bananes", 2, 1);

            _store.RegisterRebateOnMoneyWhenBuysSameProducts("Apples", 3, 200);
            _store.RegisterRebateOnMoneyWhenBuysSameProducts("Mele", 2, 100);
          
            _basket.AddBatch("Cerises, Apples");
            _basket.AddBatch("Cerises");
            _basket.AddBatch("Apples, Pommes, Bananes");
            _basket.AddBatch("Apples, Pommes");
            _basket.AddBatch("Mele");
            _basket.AddBatch("Pommes");

            Assert.AreEqual(880, _basket.Price());
        }

        [Test]
        public void Should_add_new_great_discounts_about_fruits_and_about_Pommes_family_when_price_the_total_bill()
        {
            // Iteration 6 - Vérifications
            SupportLocalization();

            _store.RegisterRebateOnMoneyWhenBuysQuantityfProducts("Fruits", 5, 200);
            _store.RegisterRebateOnMoneyWhenBuysQuantityfProducts("Pommes", 4, 100);
            
            _store.RegisterRebateOnMoneyWhenBuysSameProducts("Cerises", 2, 20);
            _store.RegisterDiscountOnFreeProductWhenBuysSameProducts("Bananes", 2, 1);  
       
            _store.RegisterRebateOnMoneyWhenBuysSameProducts("Apples", 3, 200);
            _store.RegisterRebateOnMoneyWhenBuysSameProducts("Mele", 2, 100);

            _basket.AddBatch("Mele, Apples, Apples, Pommes, Mele");
            _basket.AddBatch("Bananes");

            Assert.AreEqual(250, _basket.Price());
        }
    }
}