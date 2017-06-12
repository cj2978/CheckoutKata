using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CheckoutLogic
{
    public static class Checkout
    {
        public static void ScanItem(string items)
        {
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
