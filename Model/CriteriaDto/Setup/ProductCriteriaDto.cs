using Model.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CriteriaDto.Setup
{
    public class ProductCriteriaDto
    {
        public ProductCriteriaDto()
        {
            PageParams = new PageParams();
        }
        public PageParams PageParams { get; set; }
    }
}
