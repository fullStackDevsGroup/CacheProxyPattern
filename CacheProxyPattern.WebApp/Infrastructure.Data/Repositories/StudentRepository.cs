using CacheProxyPattern.WebApp.Domain.Contracts;
using CacheProxyPattern.WebApp.Domain.Entities;
using CacheProxyPattern.WebApp.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheProxyPattern.WebApp.Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContext _dbContext;

        public StudentRepository()
        {
            _dbContext = new DbContext();
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }
    }
}
