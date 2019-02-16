using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category
    {
        [ReadOnly(true)]
        public string CategoryCode  { get; set; }
        public string CategoryName { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        [ReadOnly(true)]
        public string SupplierId { get; set; }
        [ReadOnly(true)]
        public string SupplierName { get; set; }
    }
}
