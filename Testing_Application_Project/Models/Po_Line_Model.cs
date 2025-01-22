using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing_Application_Project.Models
{
    public class Po_Line_Model
    {
        public int line_id { get; set; }
        public int hedar_id { get; set; }
        public int product_id { get; set; }
        public int item_id { get; set; }
        public decimal line_qty { get; set; }
        public decimal line_rate { get; set; }
        public int GSTid { get; set; }
        public decimal Get_Amount { get; set; }
        public decimal Basic_Amount { get; set; }
        public decimal Total_Amount { get; set; }
    }
}