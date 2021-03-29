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
            History newHistory = new History (cod, price, quantity, DateTime.Now);
            history.Add(newHistory);
            
        }

        public List<History> ViewAsset() {
            return this.history;
        }

        public string SellAsset(string cod, int quantity){
            if(assets.ContainsKey(cod)){
                if(assets[cod].Quantity >= quantity){
                    assets[cod].Remove(quantity);
                } else {
                    return ("Não possui quantidade");
                }
            } else {
                return ("Não possui asset");
            }

            History sellHistory = new History (cod, assets[cod].Price, quantity, DateTime.Now);
            history.Add(sellHistory);

            return ("Venda efetuada");
        }

        public void ResumeAsset(){
            int total = 0;

            foreach (KeyValuePair<string, Asset> asset in assets) {
                total = asset.Value.CalculateTotal();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Asset Cod: ", asset.Value.Cod);
                Console.WriteLine("Total Asset {asset.Value.Cod}: ", asset.Value.CalculateTotal());
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine("Total Wallet:", total);
        }
        
    }
}