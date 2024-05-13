using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SatisSistemi
{
    internal class Program
    {
        class Item
        {
            public string Name { get; set; }
            public int Stock { get; set; }
            public int Price { get; set; }
        }

        class Sale
        {
            
        }

        static string Ask(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        static List<Item> items = new List<Item>();
       
        static void TxtStokVerileriYukle()
        {
            using StreamReader reader = new StreamReader("stok.txt");
            string stockTxt = reader.ReadToEnd();

            string[] stockItems = stockTxt.Split('\n');
            foreach (string stockItem in stockItems)
            {
                string[] stockItemsArr = stockItem.Split('|');
                Item item = new Item();
                item.Name = stockItemsArr[0];
                item.Stock = int.Parse(stockItemsArr[1]);
                item.Price = int.Parse(stockItemsArr[2]);

                items.Add(item);
            }
        }

        static void Listele()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {items[i].Name} - stok: {items[i].Stock} fiyat: {items[i].Price} tl.");
            }
        }

        static void Purchase()
        {   
            int inputChoice = int.Parse(Ask("Hangi ürünü satın almak istersiniz?: "));
            Console.WriteLine(inputChoice);
            int quantity = int.Parse(Ask("Kaç adet ürün almak istersiniz?: "));
            TxtStokVerileriYukle();

            var secilenUrun = items[inputChoice - 1];
            int tutar = secilenUrun.Price * quantity;
            Console.WriteLine($"Tutar:  {tutar}TL");
        }

        static void Menu()
        {
            Console.WriteLine("1-Satın al");
            Console.WriteLine("2-Satış göster");

            int inputMenuChoice = int.Parse(Console.ReadLine());

            if (inputMenuChoice == 1)
            {
                Listele();
                Purchase();
            }
        }

        static void Main(string[] args)
        {
            //TxtStokVerileriYukle();
            Listele();
            //Console.WriteLine("");
            Menu();
        }
    }
}
