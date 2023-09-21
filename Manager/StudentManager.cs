using Manager.Base;
using ManagerAbstructions.Contracts;
using Model.Entities;
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
    }
}
