using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }
    }
}