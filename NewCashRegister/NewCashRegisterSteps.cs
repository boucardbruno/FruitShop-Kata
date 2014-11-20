using System;
using System.Linq;
using CashRegister;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NewCashRegister
{
    [Binding]
    internal sealed class NewCashRegisterSteps
    {
        private readonly SupportBusinessCode _supportBusinessCode = new SupportBusinessCode();

       [Given(@"the store sells these products:")]
        internal void GivenTheStoreSellsTheseProducts(Table table)
        {
            _supportBusinessCode.FillTheStore(table.Rows.ToDictionary(row => row["Product name"], row => Convert.ToDecimal(row["Price in cents"])));
        }

        [Given(@"the localization of ""(.*)"" in ""(.*)""")]
        public void GivenTheLocalizationOfIn(string productName, string synonymous)
        {
            _supportBusinessCode.AddSynonymous(productName, synonymous);
        }

        [Given(@"a discount on (.*) ""(.*)"" for the price of (.*)")]
        internal void GivenADiscountForThePriceOf(uint quantity, string productName, uint freeProductsQuantity)
        {
            _supportBusinessCode.RegisterDiscountBasedOnFreeProductWhenCustomerBuysSeveralSameProducts(productName, quantity, freeProductsQuantity);
        }
        [Given(@"a rebate of ([0-9]+.[0-9]*) cents for (.*) ""(.*)""")]
        public void GivenARebateOfCentsFor(decimal rebate, uint quantity, string productName)
        {
            _supportBusinessCode.RegisterRebateBasedOnMoneyWhenCustomerBuysSeveralSameProducts(productName, quantity, rebate);
        }

        [Given(@"a rebate of ([0-9]+.[0-9]*) cents when we buy (.*) ""(.*)""")]
        internal void GivenRebateWhenWeBuy(decimal rebate, uint howMany, string productName)
        {
            RegisterDiscountRuleRebate(productName, howMany, rebate);
        }

        [Given(@"these rebates in cents:")]
        internal void GivenThisRebates(Table rebates)
        {
            foreach (var row in rebates.Rows)
            {
                RegisterDiscountRuleRebate(row["Product name"], Convert.ToUInt32(row["Quantity"]), Convert.ToDecimal(row["Rebate in cents"]));
            }           
        }
    
        [When(@"the customer buys these products:")]
        public void WhenTheCustomerBuysTheseProducts(Table products)
        {
            foreach (var row in products.Rows)
            {
                _supportBusinessCode.BuyProducts(row["Product name"], Convert.ToUInt32(row["Quantity"]));
            }
        }

        [When(@"the customer buys (.*) ""(.*)""")]
        internal void WhenTheCustomerBuysSomeProducts(uint howMany, string productName)
        {
            _supportBusinessCode.BuyProducts(productName, howMany);
        }

        [Then(@"the total price should be ([0-9]+.[0-9]*) cents")]
        internal void ThenTheAmountIs(decimal totalPrice)
        {         
            Assert.AreEqual(Convert.ToDecimal(totalPrice), _supportBusinessCode.Price);
        }

        private void RegisterDiscountRuleRebate(string productName, uint howMany, decimal rebate)
        {
            if (!productName.IsProductNameRegular()) _supportBusinessCode.RegisterRebateOnMoneyWhenBuysQuantityfProducts(BuildProductName(productName), howMany, rebate);
            else  _supportBusinessCode.RegisterDiscountRuleRebateOnRegularProductName(productName, howMany, rebate);
        }

        private static string BuildProductName(string productName)
        {
            return productName.IsProductNameFamily() ? productName.Substring(MetaConstants.Any.Length + 1) : productName;
        }
    }
}
