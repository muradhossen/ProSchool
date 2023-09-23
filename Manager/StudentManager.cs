using Manager.Base;
using ManagerAbstructions.Contracts;
using Microsoft.EntityFrameworkCore;
using Model.CriteriaDto;
using Model.Entities;
using Model.Pagging;
using Model.ReturnDtos;
using RepositoryAbstruction.Contracts;

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

        public async Task<IList<StudentReturnDto>> GetAllStudentsAsync()
        {
          return await  _repository.GetQueryable()
                .Include(s => s.Class) 
                .Select(s => new StudentReturnDto
                {
                   StudentName = s.StudentName,
                   StudentId = s.StudentId,
                   ClassName = s.Class.ClassName,
                   ClassId = s.ClassId
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
