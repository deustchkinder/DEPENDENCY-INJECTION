using DI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Services.ServiceRepository
{
    public interface IServiceRepository
    {
        Userx? GetByID(int id);
        IEnumerable<Userx> GetAll();
        Userx Add(Userx userx);


    }
}
