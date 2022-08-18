using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models.ViewModels
{
    public class IndexViewModel
    {
        public CarCategory CarCategory { get; set; }
        public CarVendor CarVendor { get; set; }
        public Car Car { get; set; }
    }
}
