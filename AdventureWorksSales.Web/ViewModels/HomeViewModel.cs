using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.ViewModels
{
    public class HomeViewModel
    {
        public int TotalOrders { get; set; }
        public decimal HigestLineTotal { get; set; }
        public int FrontBrakeSalesTotal { get; set; }
    }
}