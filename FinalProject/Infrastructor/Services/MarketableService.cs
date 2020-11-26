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
    public class MarketableService : IProducts
    {
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
                Code = "a13",
                Name = "Nivea night",
                Quantity = 35,
                price = 3.90,
                category = Enums.Category.Gigyeniya_mehsullari
            });
        }
        public void AddProduct(Products products) //1
        {
           
        }
        public void UpdateProductByCode(int code) //2
        {
            throw new NotImplementedException();
        }

        public void RenameProductByCode(int code) //3
        {
            throw new NotImplementedException();
        }


        public void  GetAllProducts() //4
        {
           
            ConsoleTable table = new ConsoleTable("adi", "nomresi", "Categoriyasi", "sayi", "qiymeti");
            int i = 1;
            foreach (var item in Product)
            {
                table.AddRow(item.Name, item.Code, item.category, item.Quantity, item.price);
                i++;
            }
            table.Write();

        }
        public void GetProductsByCategory(Category category) //5
        {
            List<Products> pro = Product.FindAll(s => s.category == category).ToList();
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name, item.Code, item.category, item.Quantity, item.price);
            }
          

        }

        public void GetProductsByAmountRange(double minAmount, double maxAmount) //6
        {
            List<Products> pro = new List<Products>();
            pro = Product.Where(s => s.price >= minAmount && s.price <= maxAmount).ToList();
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name, item.Code, item.category, item.Quantity, item.price);
            }
        }


        public void ProductSearching(string text) //7
        {
            List<Products> pro = new List<Products>();
         pro=   Product.FindAll(s => s.Name.Contains(text)).ToList();
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
        }
      
    } 
}
    
     
    

