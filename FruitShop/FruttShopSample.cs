using System;

namespace FruitShop
{
    class FruitShopSample
    {
        public void Run()
        {
            String input;
            Console.WriteLine("> ");
            while ((input = Console.ReadLine()) != null)
            {
                Console.WriteLine(Format(input));
                Console.WriteLine("> ");
            }
        }

        public String Format(String input)
        {
            return "> " + input;
        }
    }
}
