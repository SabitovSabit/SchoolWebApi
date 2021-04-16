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
    public class SubjectRepository:ISchoolRepository<Subject>
    {
        private SchoolDb _db;
        public SubjectRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Subject> Create(Subject _object)
        {
            _db.Subjects.Add(_object);
            await _db.SaveChangesAsync();
            return _object;
        }

        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.Subjects.Remove(clas);
            await _db.SaveChangesAsync();

        }

        public async Task<List<Subject>> GetAll()
        {
            return await _db.Subjects.ToListAsync();
        }

        public async Task<Subject> GetById(int Id)
        {
            return await _db.Subjects.FindAsync(Id);

        }

        public async Task<Subject> GetByName(string name)
        {
            return await _db.Subjects.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<Subject> Update(Subject _object)
        {
            _db.Subjects.Update(_object);
            await _db.SaveChangesAsync();
            return _object;
        }
    
}
}
