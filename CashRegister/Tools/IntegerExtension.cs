namespace CashRegister
{
    public static class IntegerExtension
    {
        public static bool IsDiscountable(this uint value, uint module)
        {
            return value%module == 0;
        }
    }
}