using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public interface IQueryExample
    {
        List<Make> GetMakes();

        List<Vehicles> GetVehiclesByPrice(decimal from, decimal to);
    }
}
