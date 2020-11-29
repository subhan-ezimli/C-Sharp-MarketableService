using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Infrastructor.Models;
namespace FinalProject.Infrastructor.Interfaces               
{     
    public interface ISales
    {
    //+1 Yeni satis elave etmek - istifadeciden satis yaradilmasi ucun lazimi melumatlarin daxil edilmesi istenilir(mehsullarin kodlari)
    //- 2 Satisdaki hansisa mehsulun geri qaytarilmasi(satisdan cixarilmasi) - userden satisin, cixarilacaq mehsulun ve sayinin daxil edilmesi istenilir
    //- 3 Satisin silinmesi - satisin nomresine esasen silinmesi
    //+ 4 Butun satislarin ekrana cixarilmasi(nomresi, meblegi, mehsul sayi, tarixi)
    //+ 5 Verilen tarix araligina gore satislarin gosterilmesi - userden qebul edilen iki tarix araligindaki satislarin gosterilmesi(nomresi, meblegi, mehsul sayi, tarixi)
    //+ 6 Verilen mebleg araligina gore satislarin gosterilmesi - userden qebul edilen iki mebleg araligindaki satislarin gosterilmesi(nomresi, meblegi, mehsul sayi, tarixi)
    //+ 7 Verilmis bir tarixde olan satislarin gosterilmesi  - userden qebul edilmis bir tarixde olan satislarin gosterilmesi(nomresi, meblegi, mehsul sayi, tarixi)
    //- 8 Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi - userden qebul edilmis nomdereye esasen hemin nomreli satisin melumatlarinin gosterilmesi(nomresi, meblegi, mehsul sayi, tarixi, satis itemlari (nomresi, mehsul adi, sayi))

       
        void AddSale(string productCode,int productCount); //1
        void DeleteProductByItemId(int id,string product,int count); //2
        void DeleteSaleById(int id); //3

        void  GetAllSales(); //4
        void GetSalesByDateRange(DateTime startDate, DateTime endDate); //5
        void GetSalesByAmountRange(double minAmount, double maxAmount);//6
       void GetSalesByDate(DateTime date); //7
       void GetSaleById(int id);//8


    }
}
