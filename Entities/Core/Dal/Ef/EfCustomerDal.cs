using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;
using Entities.Concrete.EntityFrameWork.Context;
using Entities.Core.Dal;
using EntitiesAndCore.Core.DataAcccess.EfCore;

namespace EntitiesAndCore.Core.Dal.Ef
{
    public class EfCustomerDal :EfEntityRepositoryBase<Customer,ExampleDbContext>, ICustomerDal
    {

    }
}
