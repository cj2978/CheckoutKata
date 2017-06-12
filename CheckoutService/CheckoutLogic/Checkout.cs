using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CheckoutLogic
{
    public static class Checkout
    {
        private static Dictionary<char, int> ITEMS = new Dictionary<char, int>();
        private static List<Price> priceList = new List<Price>();

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

            return total;
        }

        private static void GetPriceList()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Christopher\Documents\GitHub\CheckoutKata\CheckoutService\CheckoutService\bin\prices.json"))
            {
                priceList = JsonConvert.DeserializeObject<List<Price>>(reader.ReadToEnd());
            }
        }
    }
}
