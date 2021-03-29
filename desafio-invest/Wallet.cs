using System;
using System.Collections.Generic;


namespace desafio_invest
{
    public class Wallet
    {
        public class History {
            public string Cod;
            public int Price;
            public int Quantity;
            public DateTime BoughtAt;
            public int InvestedValue;

            public History (string cod, int price, int quantity, DateTime boughtAt) {
                Cod = cod;
                Price = price;
                Quantity = quantity;
                BoughtAt = boughtAt;
                InvestedValue = quantity * price;
            }
        }
        private Dictionary<string, Asset> assets = new Dictionary<string, Asset>();

        private List<History> history = new List<History>();
        public void AddAsset(string cod, int price, int quantity) {
            if(assets.ContainsKey(cod)){
                assets[cod].Add(quantity, price);
            } else {
                Asset newAsset = new Asset(cod, price, quantity);
                assets.Add(cod, newAsset);
            }
        }
    }
}