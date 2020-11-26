using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Infrastructor.Enums;
using FinalProject.Infrastructor.Models;
namespace FinalProject.Infrastructor.Interfaces
{
  public interface IProducts
    {         
   //+ 1 Yeni mehsul elave et  - userden yeni mehsul yaradilmasi ucun lazim olan melumatlari daxil edilmelidir
   // + 2 Mehsul uzerinde duzelis et -  duzelis edilecek mehsulun code-u ve duzelis melumatlari daxil edilmelidir
   // + 3 Mehsulu sil - mehsulun kodu daxil edilmelidir  
   // + 4 Butun mehsullari goster - butun mehsullar gosterilecek(kodu, adi, categoriyasi, sayi, qiymeti)
   // + 5 Categoriyasina gore mehsullari goster - usere var olan kateqoriyalar gosteilecek ve onlar arasinda bir secim etmelidir ve secilmis kateqoriyadan olan butun mehsullar gosterilir(kodu, adi, categoriyasi, sayi, qiymeti)
   // + 6 Qiymet araligina gore mehsullari goster - userden minimum ve maximum qiymetleri daxil etmesi istenilir ve hemin qiymet araliginda olan mehsullar gosterilir(kodu, adi, categoriyasi, sayi, qiymeti)
   // + 7 Mehsullar arasinda ada gore axtaris et - userden text daxil etmesi istenilir ve adinda hemin text olan butun mehsullar gosterilir(kodu, adi, categoriyasi, sayi, qiymeti)
    
        void AddProduct(Products products); //1
        void UpdateProductByCode(int code);  //2
        void RenameProductByCode(int code); //3
        void GetAllProducts();  //4
        void GetProductsByCategory(Category category); //5
        void GetProductsByAmountRange(double minAmount, double maxAmount);     //6
        void ProductSearching(string text); //7
      

    }
}
