using Microsoft.EntityFrameworkCore;
using RESTful.API.Entity.Context;
using RESTful.API.Entity.Models;
using RESTful.API.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTful.API.Repository.Concrete
{
    public class Repositories : IRepository
    {
        private readonly DatabaseContext _databaseContext;

        public Repositories(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Add(Student entity)
        {

            _databaseContext.Students.Add(entity);
            _databaseContext.SaveChanges();
            return true;


        }

        public bool Delete(int id)
        {
            var student = _databaseContext.Students.FirstOrDefault(x => x.Id == id);

            _databaseContext.Students.Remove(student);
            _databaseContext.SaveChanges();
            return true;


        }

        public List<Student> GetAll()
        {
            return _databaseContext.Students.ToList();

        }

        public Student GetByID(int id)
        {
            return _databaseContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Student entity)
        {
            _databaseContext.Students.Update(entity);
            _databaseContext.SaveChanges();
            return true;

        }
    }
}
