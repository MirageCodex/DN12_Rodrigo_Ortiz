using DataAccess.GymManager.Core;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GymManager.EntityFramework
{
    public class QuerrysGymManager : IQuerrysGymManager
    {
        private readonly GymManagerDataContext _context;

        public QuerrysGymManager(GymManagerDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetMembersLastWeek()
        {
            return _context.Members.FromSqlInterpolated($"CALL GetMembersLastWeek()").ToList();
        }

        public IEnumerable<ProductTypes> GetProductsInStockByType()
        {
            return _context.ProductTypes.FromSqlRaw("CALL GetProductsInStockByType()").ToList();
        }

        public void RegisterSale(int productId, int userId)
        {
            _context.Database.ExecuteSqlRaw("CALL RegisterSale({0}, {1})", productId, userId);
        }
    }
}