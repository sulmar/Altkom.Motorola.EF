using Altkom.Motorola.EF.DbServices.Interceptors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.DbServices
{
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            this.AddInterceptor(new MyInterceptor());
        }
    }
}
