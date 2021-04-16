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
    public class TeacherRepository:ISchoolRepository<Teacher>
    {
     
        
            private SchoolDb _db;
            public TeacherRepository(SchoolDb db)
            {
                _db = db;
            }
            public async Task<Teacher> Create(Teacher _object)
            {
                _db.Teachers.Add(_object);
                await _db.SaveChangesAsync();
                return _object;
            }

            public async Task Delete(int Id)
            {
                var delteacher = await GetById(Id);
                _db.Teachers.Remove(delteacher);
                await _db.SaveChangesAsync();
            }

            public async Task<List<Teacher>> GetAll()
            {
                return await _db.Teachers.ToListAsync();
            }

            public async Task<Teacher> GetById(int Id)
            {
                return await _db.Teachers.FindAsync(Id);
            }

            public async Task<Teacher> Update(Teacher _object)
            {
                _db.Teachers.Update(_object);
                await _db.SaveChangesAsync();
                return _object;

            }

            public async Task<Teacher> GetByName(string name)
            {
                return await _db.Teachers.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
       
    }
}
