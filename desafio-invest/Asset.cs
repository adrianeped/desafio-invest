
namespace desafio_invest
{
    public class Asset
    {
        string Cod;
        int Quantity;
        int Price;

    

        public Asset (string cod, int quantity, int price)
        {
            Cod = cod;
            Quantity = quantity;
            Price = price;
        }

        public int CalculateTotal()
        {
            return Price * Quantity;
        }

        public void Add(int quantity, int price) {
            Quantity += quantity;
            Price = price;
        }
    }
}