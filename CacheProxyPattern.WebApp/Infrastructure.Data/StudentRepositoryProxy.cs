using CacheProxyPattern.WebApp.Domain.Contracts;
using CacheProxyPattern.WebApp.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CacheProxyPattern.WebApp.Startup;

namespace CacheProxyPattern.WebApp.Infrastructure.Data
{
    public class StudentRepositoryProxy : IStudentRepository
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "WebDevs";
        public StudentRepositoryProxy(ServiceResolver serviceAccessor, IMemoryCache memoryCache)
        {
            _studentRepository = serviceAccessor("GetBasicObject");
            _memoryCache = memoryCache;
        }


        public IEnumerable<Student> GetAll()
        {
            if (_memoryCache.TryGetValue(CacheKey, out object temp))
            {
                return _memoryCache.Get<IEnumerable<Student>>(CacheKey);
            }
            else
            {
                var students = _studentRepository.GetAll();

                _memoryCache.Set(CacheKey, students);

                return students;
            }
        }
    }
}
