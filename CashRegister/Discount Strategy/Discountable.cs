namespace CashRegister
{
    public abstract class Discountable
    {
        protected uint Count { get; set; }

        protected uint Quantity { get; set; }

        protected Discountable(uint quantity)
        {
            Quantity = quantity;
        }

        public virtual decimal Price(decimal defaultPrice)
        {       
            Count++;
            
            if (Count.IsDiscountable(Quantity))
            {
                Count = 0;
                return ApplyDiscount(defaultPrice);
            }
            return defaultPrice;
        }

        public abstract decimal ApplyDiscount(decimal defaultPrice);

        public void Reset()
        {
            Count = 0;
        }
    }
}