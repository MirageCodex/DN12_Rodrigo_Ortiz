using DataAccess.GymManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.GymManager.EntityFramework
{
    public interface IQuerrysGymManager
    {
        IEnumerable<Member> GetMembersLastWeek();
        void RegisterSale(int productId, int userId);
        IEnumerable<ProductTypes> GetProductsInStockByType();
    }
}
