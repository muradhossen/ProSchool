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
    public class ClassManager : Manager<Class>,IClassManager
    {
        private readonly IClassRepository _repository;

        public ClassManager(IClassRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
