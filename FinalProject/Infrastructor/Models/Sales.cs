using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace FinalProject.Infrastructor.Models
{    
    public class Sales
    {      
        public int Id { get; set; }
        public double Amount { get; set; }
        public SaleItems saleItems { get; set; }
        public DateTime Date { get; set; }

    }
}
