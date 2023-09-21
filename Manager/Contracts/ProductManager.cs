using Manager.Base;
using ManagerAbstructions.Contracts;
using Model.CriteriaDto.Setup;
using Model.Entities;
using Model.Pagging;
using RepositoryAbstruction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Contracts
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private readonly IProductRepo _repository;

        public ProductManager(IProductRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<Product>> GetByCriteria(ProductCriteriaDto criteria)
        {
            var data = _repository.GetQueryable()
                .OrderByDescending(c => c.Id)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(criteria.PageParams.SearchKey))
            {
                string searchKey = criteria.PageParams.SearchKey.Replace("--", " ").Trim().ToLower();

                data = data.Where(c => c.Name.ToLower().Contains(searchKey));
            }

            return await PagedList<Product>.CreateAsync(data, criteria.PageParams.PageNumber, criteria.PageParams.PageSize);

        }

    }
}
