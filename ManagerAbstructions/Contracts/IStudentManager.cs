using ManagerAbstructions.Base;
using Model.CriteriaDto;
using Model.Entities;
using Model.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAbstructions.Contracts
{
    public interface IStudentManager : IManager<Student>
    {
        Task<PagedList<Student>> GetByCriteria(StudentCriteriaDto criteria);
    }
}
