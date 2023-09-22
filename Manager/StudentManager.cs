using Manager.Base;
using ManagerAbstructions.Contracts;
using Model.CriteriaDto;
using Model.CriteriaDto.Setup;
using Model.Entities;
using Model.Pagging;
using RepositoryAbstruction.Base;
using RepositoryAbstruction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class StudentManager : Manager<Student>, IStudentManager
    {
        private readonly IStudentRepository _repository;

        public StudentManager(IStudentRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<Student>> GetByCriteria(StudentCriteriaDto criteria)
        {
            var query = _repository
                .GetQueryable()
                .OrderByDescending(c => c.StudentId)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(criteria.SearchKey))
            {
                string searchKey = criteria.SearchKey.Replace("--", " ").Trim().ToLower();

                query = query.Where(c => c.StudentName.ToLower().Contains(searchKey));
            }

            return await PagedList<Student>.CreateAsync(query, criteria.PageNumber, criteria.PageSize);

        }
    }
}
