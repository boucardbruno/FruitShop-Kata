namespace CashRegister
{
    internal sealed class DiscountRebateForMoreProducts : Discountable
    {
        private readonly decimal _rebate;

        internal DiscountRebateForMoreProducts(uint quantity, decimal rebate)
            : base(quantity)
        {
            _rebate = rebate;
        }
      
        public override decimal ApplyDiscount(decimal defaultPrice)
        {
            Count = 0;
            return defaultPrice - _rebate;
        }
    }
}