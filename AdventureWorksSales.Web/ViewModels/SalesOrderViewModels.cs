using AdventureWorksSales.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.ViewModels
{
    public class SalesOrderListingViewModels
    {
        public IEnumerable<SalesOrder> SalesOrders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}