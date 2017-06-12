using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CheckoutLogic
{
    public static class Checkout
    {
        public static Dictionary<char, int> ITEMS = new Dictionary<char, int>();

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
            return 0;
        }

        private static List<Price> GetPriceList()
        {
            List<Price> priceList = new List<Price>();

            using (StreamReader reader = new StreamReader("prices.json"))
            {
                priceList = JsonConvert.DeserializeObject<List<Price>>(reader.ReadToEnd());
            }

            return priceList;
        }
    }
}
