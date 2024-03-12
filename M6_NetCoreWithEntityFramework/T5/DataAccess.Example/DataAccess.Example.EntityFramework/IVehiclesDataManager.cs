using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public interface IVehiclesDataManager
    {
        void Insert(Vehicles vehicle);

        void Update(Vehicles vehicle);

        Vehicles Get(int id);

        IList<Vehicles> GetAll();

        void Delete(int id);
    }
}