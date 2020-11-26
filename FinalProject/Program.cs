using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Infrastructor.Services;
using FinalProject.Infrastructor.Enums;
using FinalProject.Infrastructor.Models;
using ConsoleTables;
namespace FinalProject
{
    class Program
    {
        private static readonly  MarketableService marketableService = new MarketableService();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int selectInt;

            do
            {
                #region Menu 
                Console.WriteLine("---------mehsullar ve satiwlar uzerinde emeliyyatlarlar---------\n");
                Console.WriteLine("1.Mehsullar uzerinde emeliyyat aparmaq");
                Console.WriteLine("2.Satiwlar uzerinde emeliyyat aparmaq");
                Console.WriteLine("0. Sistemden cixmaq");
                #endregion

                Console.WriteLine();
                #region Menu Selection


                Console.WriteLine("Seciminizi daxil edin!");

                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt))
                {

                    Console.WriteLine("reqem daxil etmelisiz");
                    select = Console.ReadLine();
                }

                #endregion

                switch (selectInt)
                {
                    case 0:
                        continue;
                    case 1:

                        Console.WriteLine("----Mehsullar uzerinde emeliyyat aparilacaq Secimler--\n");
                        Console.WriteLine("1.Yeni mehsul elave et ");
                        Console.WriteLine("2.Mehsul uzerinde duzelis et");
                        Console.WriteLine("3. Mehsulu sil");
                        Console.WriteLine("4. Butun mehsullari goster ");
                        Console.WriteLine("5. Categoriyasina gore mehsullari goster ");
                        Console.WriteLine("6.Qiymet araligina gore mehsullari goster");
                        Console.WriteLine("7.Mehsullar arasinda ada gore axtaris et \n");
                        ProductOperations();
                        break;
                    case 2:
                        Console.WriteLine("----Satiwlar uzerinde emeliyyat apara bilersiz ");
                        Console.WriteLine("1.Yeni satiw elave etmek");
                        Console.WriteLine("2. Satisdaki hansisa mehsulun geri qaytarilmasi(satisdan cixarilmasi) ");
                        Console.WriteLine("3. Satisin silinmesi - satisin nomresine esasen silinmesi");
                        Console.WriteLine("4. Butun satislarin ekrana cixarilmasi(nomresi, meblegi, mehsul sayi, tarixi)");
                        Console.WriteLine("5. Verilen tarix araligina gore satislarin gosterilmesi");
                        Console.WriteLine("6. Verilen mebleg araligina gore satislarin gosterilmesi");
                        Console.WriteLine("7. Verilmis bir tarixde olan satislarin gosterilmesi ");
                        Console.WriteLine("8. Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi\n");
                        SalesOperations();
                         break;
                    default:
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Yalniw secim daxil etdiniz.0-2 araliginda secim ede bilersiz");
                        Console.WriteLine("--------------------------------");
                        break;
                }

            } while (selectInt != 0);

               
               void ProductOperations()
               {   
                int SelectInt;
                do
                {
                    Console.WriteLine("seciminizi daxil edin:");
                    string Select = Console.ReadLine();
                    while (!int.TryParse(Select, out SelectInt))
                    {
                        Console.WriteLine("Yalniz reqem daxil ede bilersiz!");
                        Select = Console.ReadLine();
                    }
                    switch (SelectInt)
                    {
                        case 1:
                            ShowProductAdd();
                            break;
                        case 2:
                            ShowUpdateProduct();
                            break;
                        case 3:
                            ShowRenameProduct();
                                break;
                        case 4:
                            GetallProducts();
                            break;
                        case 5:
                            GetProductsByCategory();
                            break;
                        case 6:
                            GetProductsByAmountRange();
                            break;
                        case 7:
                            ProductSearching();
                            break;
                        default: Console.WriteLine("Yalnis sechim daxil etdiniz.1-7 araliginda secim daxil edin!");
                            break;

                    }
                    #region product methods
                    static void ShowProductAdd()           //product added  
                    {
                        Console.WriteLine("------yeni Product elave et-----\n");
                        Products products = new Products();               
                        Console.WriteLine(" adini daxil edin:");
                        products.Name = Console.ReadLine();
                        Console.WriteLine("qiymetini daxil edin:");
                        double Price;
                        string price = Console.ReadLine();
                        while (! double.TryParse(price,out Price))
                        {
                            Console.WriteLine("Reqem daxil et!");
                            price = Console.ReadLine();
                        }
                        products.price = Price;
                        Console.WriteLine("Kateqoriyani daxil edin:");
                        Array array = Enum.GetValues(typeof(Category));
                        foreach (var item in array)
                        {
                            Console.WriteLine(Array.IndexOf(array, item)+1 + " - " + item);
                        }
                        Console.WriteLine("----------------------------------------------------------");


                    }     //1

                static    void ShowUpdateProduct()
                    {
                        Console.WriteLine("------Mehsullar uzerinde duzelis et-----");

                    }  //2

                static  void ShowRenameProduct()
                    {
                     

                    }   //3

                static   void GetallProducts()       //Get All products 
                    { Console.WriteLine("------ Butun mehsullari goster-----");
                      marketableService.GetAllProducts();
                    }   //4

                static void GetProductsByCategory()
                    { Products prod = new Products();
                        Console.WriteLine("------ Categoriyasina gore mehsullari goster-----\n");
                        Array array = Enum.GetValues(typeof(Category));
                        foreach (var item in array)
                        {
                            Console.WriteLine(Array.IndexOf(array, item) + 1 + " - " + item);
                        }
                        //((Category)category       
                        
                        Console.WriteLine("Categoriyani daxil edin:");
                        int category = Convert.ToInt32(Console.ReadLine());
                        switch (category)
                        {
                            case  1:
                                prod.category = Category.Un_Mehsullari;            
                                break;
                            case 2:
                                prod.category = Category.Terevez;
                                break;
                            case 3:
                                prod.category = Category.Cherezler;
                                break;
                            case 4:
                                prod.category = Category.Ichkiler;
                                break;
                            case 5:
                                prod.category = Category.Et_mehsullari;
                                break;
                            case 6:
                                prod.category = Category.Gigyeniya_mehsullari;
                                break;
                            default:
                              Console.WriteLine("sehv daxil etmisiz.1-6 araliginda reqem daxil edin:");
                                break;
                        }

                        marketableService.GetProductsByCategory((Category)category);

                    }   //5


                static void GetProductsByAmountRange()
                    {
                        Console.WriteLine("------ Qiymet araligina gore mehsullari goster-----");
                        Console.WriteLine("minimum mebleg daxil edin:");
                        double startAmout = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("maksimum mebleg daxil edin :");
                        double endAmount = Convert.ToDouble(Console.ReadLine());
                        marketableService.GetProductsByAmountRange(startAmout, endAmount);

                    }   //6


                static void ProductSearching()
                    {
                        Console.WriteLine("------ mehsulun adin yaz-----");
                        string text = Console.ReadLine();
                        marketableService.ProductSearching(text);

                    }      //7
                
                }
                #endregion

                while (SelectInt != 0);
            }


               static void SalesOperations()
            {
                int SelectInt;
                do
                {
                    Console.WriteLine("seciminizi daxil edin:");
                    string select = Console.ReadLine();
                    while (!int.TryParse(select, out SelectInt))
                    {
                        Console.WriteLine("yalniz reqem daxil ede bilersiz:");
                        select = Console.ReadLine();
                    }
                    switch (SelectInt)
                    {
                        case 1:
                            Console.WriteLine();
                            break;
                        default:
                            break;
                    }



                }
                while (SelectInt != 0);

    

                
            }
        }
    }
} 
           



   












   


        
    

