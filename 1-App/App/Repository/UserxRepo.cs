using App.Databases;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class UserxRepo(MyDbContext myDbContext1) : IUserxRepo
    {
        public Userx Add(Userx user)
        {
            return myDbContext1.Add(user);        
        }

        public List<Userx> GetAll()
        {
            return myDbContext1.GetAll();
        }

        public Userx? GetUserx(int id)
        {
            return myDbContext1.Get(id);
        }
    }
}
