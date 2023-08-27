using RESTful.API.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTful.API.Repository.Abstract
{
    public interface IRepository
    {
        bool Add(Student entity);
        bool Update(Student entity);
        bool Delete(int id);
        List<Student> GetAll();
        Student GetByID(int id);

    }
}
