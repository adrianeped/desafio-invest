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

            public string Action;

            public History (string action, string cod, int price, int quantity, DateTime boughtAt) {
                Action = action;
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
            History newHistory = new History ("Add", cod, price, quantity, DateTime.Now);
            history.Add(newHistory);
            
        }

        public void ViewAsset() {
            foreach (History h in history ) {
                Console.WriteLine("------------Assets------------");
                Console.WriteLine($"Action: {h.Action}");
                Console.WriteLine($"Cod: {h.Cod}");
                Console.WriteLine($"Price: R${h.Price}");
                Console.WriteLine($"Quantity: {h.Quantity}");
                Console.WriteLine($"Total value: R${h.InvestedValue}");
                Console.WriteLine($"Date: {h.BoughtAt}");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("");
            }
        }

        public void SellAsset(string cod, int quantity){
            if(assets.ContainsKey(cod)){
                if(assets[cod].Quantity >= quantity){
                    assets[cod].Remove(quantity);
                    History sellHistory = new History ("Sell",cod, assets[cod].Price, quantity, DateTime.Now);
                    history.Add(sellHistory);

                    Console.WriteLine("Sale made");
                } else {
                    Console.WriteLine("There is no quantity");
                }

            } else {
                Console.WriteLine("Has no asset");
            }
        }

        public void ResumeAsset(){
            int total = 0;

            foreach (KeyValuePair<string, Asset> asset in assets) {
                total = asset.Value.CalculateTotal();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Asset Cod: {asset.Value.Cod}");
                Console.WriteLine($"Total Asset: R${asset.Value.CalculateTotal()}");
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine($"Total Wallet: R${total}");
            Console.WriteLine("-------------------------------------");
        }
        
    }
}