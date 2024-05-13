using DI.Application.Repository;
using DI.Domain.Entities;
using DI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Services.ServiceRepository;

public class ServiceRepositoryConcrete(IUserxRepo userxRepo) : IServiceRepository
{
    public Userx Add(Userx userx) //DTO olarak istek gelmeli
    {
        return userxRepo.Add(userx);
    }

    public IEnumerable<Userx> GetAll()
    {
        return userxRepo.GetAll();
    }

    public Userx? GetByID(int id)
    {
        return userxRepo.GetByID(id);
    }
}
