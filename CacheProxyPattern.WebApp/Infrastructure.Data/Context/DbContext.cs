using CacheProxyPattern.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheProxyPattern.WebApp.Infrastructure.Data.Context
{
    public class DbContext
    {

        public DbContext()
        {
            Students = new List<Student>
            {
                new Student()
            };
        }
        public List<Student> Students;
    }
}
