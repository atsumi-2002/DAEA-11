using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}