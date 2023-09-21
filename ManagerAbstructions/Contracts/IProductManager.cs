using ManagerAbstructions.Base;
using Model.CriteriaDto.Setup;
using Model.Entities;
using Model.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAbstructions.Contracts
{
    public interface IProductManager:IManager<Product>
    {
        Task<PagedList<Product>> GetByCriteria(ProductCriteriaDto criteria);
    }
}
