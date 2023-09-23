using Database;
using Model.Entities;
using Repository.Base;
using RepositoryAbstruction.Contracts;

namespace Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClassRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
