using System;
using System.Collections.Generic;


namespace desafio_invest
{
    public class Wallet
    {
        private Dictionary<string, Asset> assets = new Dictionary<string, Asset>();
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