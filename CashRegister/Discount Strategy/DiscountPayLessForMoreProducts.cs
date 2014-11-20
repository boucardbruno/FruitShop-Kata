namespace CashRegister
{
    internal sealed class DiscountPayLessForMoreProducts : Discountable
    {
        private readonly uint _freeProducts;
        internal DiscountPayLessForMoreProducts(uint quantity, uint freeProducts)
            : base(quantity)
        {
            _freeProducts = freeProducts;
        }
        
        public override decimal ApplyDiscount(decimal defaultPrice)
        {
            Count = 0;
            return  - (_freeProducts - 1) * defaultPrice; ;
        }
    }
}