using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Concrete
{
    public class EFSalesOrderRepo : GenericRepostory<SalesOrder>, ISalesOrderRepo
    {
        public EFSalesOrderRepo(AdventureWorksSalesEntities context) : base(context) { }

        public async Task<IEnumerable<decimal>> GetLineTotal()
        {
            var saleOrdersLinetotal = (await GetAllAsync()).Select(x => x.LineTotal);
            return saleOrdersLinetotal;
        }

        public async Task<IEnumerable<SalesOrder>> GetProductSales(int prodId)
        {
            var model = (await GetAllAsync()).Where(x => x.ProductID == prodId);
            return model;
        }
    }
}
