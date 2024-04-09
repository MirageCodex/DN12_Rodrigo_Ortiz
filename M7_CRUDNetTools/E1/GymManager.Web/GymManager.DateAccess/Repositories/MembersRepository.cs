using GymManager.Core.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public class MembersRepository : Repository<int, Member>
    {
        public MembersRepository(GymManagerContext context) : base(context) 
        { 
        }
        public override async Task<Member> AddAsync(Member entity) 
        {
            var city = Context.Cities.Find(entity.CityId);
            await Context.Members.AddAsync(entity);
            await Context.SaveChangesAsync();
            city.Members.Add(entity);

            return entity;
        }
        public override async Task<Member> GetAsync(int id)
        {
            var member = await Context.Members.FirstOrDefaultAsync(x => x.Id == id);
            return member;
        }


    }
}
