using System;

namespace CheckoutService
{
    public class Checkout : ICheckout
    {
        public void Scan(string item)
        {
            CheckoutLogic.Checkout.ScanItem(item);
        }

        public int GetTotalPrice()
        {
            return CheckoutLogic.Checkout.GetTotal();
        }
    }
}
