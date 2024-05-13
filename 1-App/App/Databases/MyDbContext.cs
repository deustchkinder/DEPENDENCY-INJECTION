using App.Models;
using App.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Databases
{
    public class MyDbContext(UsersTbl usersTbl)
    {
        public Userx Add(Userx user)
        {
            usersTbl.Users.Add(user);
            return user;
        }
        public Userx? Get(int id)
        {
            return usersTbl.Users.FirstOrDefault(u => u.Id == id);
        }
        public List<Userx> GetAll() { return usersTbl.Users; }
    }
}
