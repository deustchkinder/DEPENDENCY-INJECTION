using DI.Application.Databases;
using DI.Domain.Entities;
using DI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Application.Repository;

public class UserxRepo(MyDbContext db) : IUserxRepo
{
    public Userx Add(Userx userx)
    {
        db.Users.Add(userx);
        db.SaveChanges();
        return userx;
    }

    public IEnumerable<Userx> GetAll()
    {
        return db.Users;
    }

    public Userx? GetByID(int id)
    {
        return db.Users.Find(id);
    }
}
