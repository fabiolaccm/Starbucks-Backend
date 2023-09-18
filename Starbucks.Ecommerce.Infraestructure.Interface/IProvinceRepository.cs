using Starbucks.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbucks.Ecommerce.Infraestructure.Interface
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> FindAll();
    }
}
