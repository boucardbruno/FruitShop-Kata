namespace CashRegister
{
    internal sealed class DiscountRebateForMoreProductsForThisPrice : Discountable
    {
        private readonly decimal _rebate;

        internal DiscountRebateForMoreProductsForThisPrice(uint quantity, decimal rebate)
            : base(quantity)
        {
            _rebate = rebate;
        }

        public override decimal ApplyDiscount(decimal defaultPrice)
        {         
            return _rebate - (Quantity - 1)*defaultPrice;
        }
    }
}