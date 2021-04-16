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
    public class ClassRepository : ISchoolRepository<ClassName>
    {
        private SchoolDb _db;
        public ClassRepository(SchoolDb db)
        {
            _db = db;
        }
        public  async Task<ClassName> Create(ClassName _object)
        {
            _db.ClassNames.Add(_object);
            await _db.SaveChangesAsync();
            return _object;
        }

        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.ClassNames.Remove(clas);
            await _db.SaveChangesAsync();

        }

        public async Task<List<ClassName>> GetAll()
        {
            return await _db.ClassNames.ToListAsync();
        }
    
        public async Task<ClassName> GetById(int Id)
        {
           return await _db.ClassNames.FindAsync(Id);
            
        }

        public async Task<ClassName> GetByName(string name)
        {
            return await _db.ClassNames.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public  async Task<ClassName> Update(ClassName _object)
        {
            _db.ClassNames.Update(_object);
            await _db.SaveChangesAsync();
            return _object;
        }
    }
}
