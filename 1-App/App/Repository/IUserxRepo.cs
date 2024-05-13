using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository;
public interface IUserxRepo
{
    Userx Add(Userx user);
    Userx? GetUserx(int id);
    List<Userx> GetAll();
}
