using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Infrastructor.Enums;
namespace FinalProject.Infrastructor.Models
{
    public class Products
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public Category category{ get; set; }
        //
        // foreach (var item in marketableService.GetProductsByCategory(Category.Un_Mehsullari.ToString() ))
        // {
        //     consoleTable.AddRow(item.Code,item.Name);
        //}
        // Console.WriteLine(consoleTable);

        public int Quantity { get; set; }
    }
}
