using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Data;
using SchoolWebApi.Interface;
using SchoolWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Concrate
{
    public class StudentRepository : ISchoolRepository<Student>
    {
         private SchoolDb _db;
        public StudentRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Student> Create(Student _object)
        {
            _db.Students.Add(_object);
            await _db.SaveChangesAsync();
            return _object;
        }

        public async Task Delete(int Id)
        {
            var delstudent= await GetById(Id);
            _db.Students.Remove(delstudent);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> GetById(int Id)
        {
            return await _db.Students.FindAsync(Id);
        }

        public async Task<Student> Update(Student _object)
        {
             _db.Students.Update(_object);
            await _db.SaveChangesAsync();
            return _object;

        }

        public async Task<Student> GetByName(string name)
        {
            return await _db.Students.FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());
        }
    }
}
