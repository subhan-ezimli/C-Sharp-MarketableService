using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Infrastructor.Interfaces;
using FinalProject.Infrastructor.Models;
using ConsoleTables;
using FinalProject.Infrastructor.Enums;
   
namespace FinalProject.Infrastructor.Services
{
    public class MarketableService : IProducts, ISales
    {
        private readonly List<SaleItems> _saleItems;
        public List<SaleItems> SaleItems => _saleItems;
        private readonly List<Sales> _sales;
        public List<Sales> Sale => _sales;
        private readonly List<Products> _product;
        public List<Products> Product => _product;
        public MarketableService()
        {
            _sales = new List<Sales>();
            _product = new List<Products>();

            _product.Add(
                new Products
                {
                    Code = "a11",
                    category = Enums.Category.Un_Mehsullari,
                    price = 0.40,
                    Name = "Chorek",
                    Quantity = 10
                }
            );
            _product.Add(new Products
            {
                Code = "a12",
                Name = "Nivea night",
                Quantity = 30,
                price = 3.90,
                category = Enums.Category.Gigyeniya_mehsullari
            });
            _product.Add(new Products
            { Code = "a13",
                Name = "Cola",
                Quantity = 4,
                price = 1,
                category = Enums.Category.Ichkiler
            });
            _product.Add(new Products
            {
                Code = "a14",
                Name = "Fanta",
                price = 1,
                Quantity = 12,
                category = Enums.Category.Ichkiler


            }); ;
            _product.Add(new Products
            {
                Code = "a15",
                Name = "Nivea night",
                Quantity = 35,
                price = 3.90,
                category = Enums.Category.Gigyeniya_mehsullari
            });
        }

        public void AddProduct(Products products) //1
        { }

        public void UpdateProductByCode(string code) //2
        {
            Products pro = new Products();
            pro = Product.Find(p => p.Code == code);
            
            if (pro != null)
            {
                Console.Write("Mehsulun adi:  ");
                Console.WriteLine(pro.Name);
                Console.Write("yeni adi daxil edin:   ");
                pro.Name = Console.ReadLine();

                Console.Write("Mehsulun qiymeti:  ");
                Console.WriteLine(pro.price);
                Console.Write("yeni qiymet daxil edin:   ");

                double priceDouble;
                string price = Console.ReadLine();
                while (!double.TryParse(price, out priceDouble))
                {
                    Console.WriteLine("tam eded daxil ede bilersiz!");
                    price = Console.ReadLine();
                }
                pro.price = priceDouble;

                Console.Write("mehsulun kateqoriyasi:");
                Console.WriteLine(pro.category);
                Console.Write("yeni kateqoriyani bu kateqoriyalar arasindan seche bilersiz:");
                Console.WriteLine("1.Un mehsullari");
                Console.WriteLine("2.Terevez");
                Console.WriteLine("3.cherezler");
                Console.WriteLine("4.Ichkiler");
                Console.WriteLine("5.Et mehsullari");
                Console.WriteLine("6.Gigiyena mehsullari\n");

                int categoryNumberInt;
                string categoryNumber = Console.ReadLine();
                while (!int.TryParse(categoryNumber, out categoryNumberInt))
                {
                    Console.WriteLine("reqem daxil edin:");
                    categoryNumber = Console.ReadLine();
              
                } 

                switch (categoryNumberInt)
                {
                    case 1:
                        pro.category = Category.Un_Mehsullari;
                        break;
                    case 2:
                        pro.category = Category.Terevez;
                        break;
                    case 3:
                        pro.category = Category.Cherezler;
                        break;
                    case 4:
                        pro.category = Category.Ichkiler;
                        break;
                    case 5:
                        pro.category = Category.Et_mehsullari;
                        break;
                    case 6:
                        pro.category = Category.Gigyeniya_mehsullari;
                        break;
                    default:
                        Console.WriteLine("1-6 araliginda secim ede bilersiz!!");
                        break;
                }
                if (categoryNumberInt >= 1 && categoryNumberInt <= 6)
                {
                    Console.WriteLine("Kateqoriya elave olundu");

                }
                Console.Write("mehsulun sayi:");
                Console.WriteLine(pro.Quantity);
                Console.WriteLine("mehsulun yeni sayini daxil edin :");
                int countInt;
                string count = Console.ReadLine();
                while (!int.TryParse(count, out countInt))
                {
                    Console.WriteLine("yalniz reqem daxil ede bilersiz");
                    count = Console.ReadLine();

                }
                pro.Quantity = countInt;

                

                 


            }
        }
        public void RemoveProductByCode(string code) //3
        {
            Products pro = Product.Find(p => p.Code == code);
            if (pro!=null)
            {
                Product.Remove(pro);
                Console.WriteLine("verdiyiniz koda uygun mehsul silindi");

            }
            else
            {
                Console.WriteLine("daxil edilen koda uygun mehsul yoxdur");
            }


        }
        public void GetAllProducts() //4
        {

            ConsoleTable table = new ConsoleTable("adi", "nomresi", "Categoriyasi", "sayi", "qiymeti");

            foreach (var item in Product)
            {
                table.AddRow(item.Name, item.Code, item.category, item.Quantity, item.price);

            }
            table.Write();

        }
        public void GetProductsByCategory(Category category) //5
        {
            List<Products> pro = Product.FindAll(p => p.category == category).ToList();
            ConsoleTable table = new ConsoleTable("adi", "nomresi", "Categoriyasi", "sayi", "qiymeti");
           
            foreach (var item in pro)
            {
                table.AddRow(item.Name, item.Code, item.category, item.Quantity, item.price);

            }
            table.Write();

        }

        public void GetProductsByAmountRange(double minAmount, double maxAmount) //6
        {
            List<Products> pro = new List<Products>();
            pro = Product.Where(s => s.price >= minAmount && s.price <= maxAmount).ToList();
            ConsoleTable table = new ConsoleTable("adi", "qiymeti");

            foreach (var item in pro)
            {
                table.AddRow(item.Name, item.price);

            }
            table.Write();
        }
        public void ProductSearching(string Text) //7
        {      
            Products pro = Product.Find(p => p.Name.Contains(Text));

            if (pro !=null)
            {
                Console.WriteLine(pro.Name+""+pro.price+""+pro.Code);  //nese problem oldu burda.iwlemedi
            }
 
        }


        #region _Sale Methods



        public void AddSale(string productCode, int productCount)
        {
            List<SaleItems> items = new List<SaleItems>();
            var saleitem = new SaleItems();
            Sales sales = new Sales();
            var sale = sales;

            var product = _product.Where(p => p.Code == productCode).FirstOrDefault();

            saleitem.Products = product;
            saleitem.Number = items.Count + 1;
            items.Add(saleitem);
            sale.Id = _sales.Count + 1; ;
            sale.Amount += productCount * product.price;
            sale.Date = DateTime.Now;
            sale.saleItems = items;
            _sales.Add(sale);
        }

      public    void DeleteProductByItemId(int id, string product, int count)
        { 

        }
        public void DeleteSaleById(int id)
        {
            throw new NotImplementedException();
        }      
         public void GetAllSales()
        {
            ConsoleTable table = new ConsoleTable( "satis id", "mebleg", "mehsul sayi", "tarix");
            
            foreach (var item in _sales)
            {
                table.AddRow( item.Id, item.Amount,item.saleItems.Count,item.Date);
               
            }
            table.Write();
        }


        public void GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Sales> sales = _sales.FindAll(s => s.Date <= endDate && s.Date >= startDate).ToList();
            ConsoleTable table = new ConsoleTable("satis id", "mebleg", "mehsul sayi", "tarix");

            foreach (var item in sales)
            {
                table.AddRow(item.Id, item.Amount, item.saleItems.Count, item.Date);
               
            }
            table.Write();
        }

        public void GetSalesByAmountRange(double minAmount, double maxAmount)
        {
            List<Sales> sales = _sales.FindAll(s => s.Amount >= minAmount && s.Amount <= maxAmount).ToList();
            ConsoleTable table = new ConsoleTable("satis id", "mebleg", "mehsul sayi", "tarix");

            foreach (var item in sales)
            {
                table.AddRow(item.Id, item.Amount, item.saleItems.Count, item.Date);

            }
            table.Write();
        }

        public void GetSalesByDate(DateTime date)
        {
            List<Sales> sales = _sales.FindAll(s => s.Date == date ).ToList();
            ConsoleTable table = new ConsoleTable("satis id", "mebleg", "mehsul sayi", "tarix");

            foreach (var item in sales)
            {
                table.AddRow(item.Id, item.Amount, item.saleItems.Count, item.Date);

            }
            table.Write();
        }

        public void GetSaleById(int id)
        {
           
            foreach (var item in _sales)
            {
                if (item.Id==id)
                {
                    
                }
            }
            
        }
    }

    #endregion


}




