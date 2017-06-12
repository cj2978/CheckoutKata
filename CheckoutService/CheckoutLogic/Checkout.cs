using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CheckoutLogic
{
    public static class Checkout
    {
        private static Dictionary<char, int> ITEMS = new Dictionary<char, int>();
        private static List<Price> PRICELIST = new List<Price>();

        public static void ScanItem(string item)
        {
            foreach (char character in item.ToCharArray())
            {
                if (ITEMS.ContainsKey(character))
                {
                    var currentItems = ITEMS[character];
                    currentItems++;
                    ITEMS[character] = currentItems;
                }
                else
                {
                    ITEMS.Add(character, 1);
                }
            }
        }

        public static int GetTotal()
        {
            GetPriceList();

            var total = 0;

            foreach (char key in ITEMS.Keys)
            {
                total = total + GetItemTotal(key.ToString(), ITEMS[key]);
            }

            return total;
        }

        private static void GetPriceList()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Christopher\Documents\GitHub\CheckoutKata\CheckoutService\CheckoutService\bin\prices.json"))
            {
                PRICELIST = JsonConvert.DeserializeObject<List<Price>>(reader.ReadToEnd());
            }
        }

        private static int GetItemTotal(string sKU, int qty)
        {
            var itemTotal = 0;

            Price itemDetails = PRICELIST.Find(x => x.SKU == sKU);

            if (itemDetails != null)
            {
                int specialPriceMultiplier = itemDetails.SpecialPriceQty > 0 ? qty / itemDetails.SpecialPriceQty : 0;
                int standardPriceMultiplier = qty - (specialPriceMultiplier * itemDetails.SpecialPriceQty);

            }
            else
            {
                string message = string.Format("No Price Found For {0}, Please Check Items Again", sKU);
                throw new Exception(message);
            }
            
            return itemTotal;
        }
    }
}
