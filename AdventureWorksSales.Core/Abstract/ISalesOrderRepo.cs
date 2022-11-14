using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Abstract
{
    public interface ISalesOrderRepo: IGenericRepository<SalesOrder>
    {
        Task<IEnumerable<decimal>> GetLineTotal();
        Task<IEnumerable<SalesOrder>> GetProductSales(int id);
    }
}
