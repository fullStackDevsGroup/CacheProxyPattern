using CacheProxyPattern.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheProxyPattern.WebApp.Domain.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
    }
}
