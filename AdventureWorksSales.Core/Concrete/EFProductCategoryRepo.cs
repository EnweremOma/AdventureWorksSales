using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Concrete
{
    public class EFProductCategoryRepo : GenericRepostory<ProductCategory>, IProductCategoryRepo
    {
        public EFProductCategoryRepo(AdventureWorksSalesEntities context)
        : base(context)
        { }
    }
}
