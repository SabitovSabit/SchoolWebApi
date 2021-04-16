using SchoolWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Interface
{
    public interface ISchoolRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> GetByName(string name);
        Task<T> Create(T _object);
        Task<T> Update(T _object);
        Task Delete(int Id);

    }
}
