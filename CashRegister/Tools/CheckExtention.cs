using System;
using System.Collections.Generic;

namespace CashRegister
{
    public static class CheckExtention
    {
        public static void Check(this object instance, string message)
        {
            if (instance == null) throw new ArgumentNullException(message);
        }

        public static void Check(this string instance, string message)
        {
            if (string.IsNullOrEmpty(instance)) throw new ArgumentNullException(message);
        }

       
        public static void Check(this Dictionary<string, decimal> instance, string message)
        {
            if (instance == null) throw new ArgumentNullException(message);   
        }
    }
    


}