using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Contracts
{
    public interface ICrudService
    {
        void Add(BaseEntity baseEntity);
        void Update(int id, BaseEntity baseEntity);
        void Delete(int id);
        BaseEntity Get(int id);
        BaseEntity[] GetAll();

    }
}
