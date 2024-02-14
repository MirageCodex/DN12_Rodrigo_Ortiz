using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.MembershipTypes
{
    public class MembershipTypesAppService : IMembershipTypesAppService
    {
        private static List<MembershipType> Memberships = new List<MembershipType>();
        public int AddMembershipTypes(MembershipType membershiptype)
        {
            Random random = new Random();
            membershiptype.idMembership = random.Next();

            Memberships.Add(membershiptype);
            return membershiptype.idMembership;
        }

        public void DeleteMembershipType(int membershipId)
        {
            var m = Memberships.Where(x => x.idMembership == membershipId).FirstOrDefault();
            Memberships.Remove(m);
        }

        public void EditMembershipType(MembershipType membershiptype)
        {
            var m = Memberships.Where(x => x.idMembership == membershiptype.idMembership).FirstOrDefault();
            m.name = membershiptype.name;
            m.cost = membershiptype.cost;
            m.duration = membershiptype.duration;
        }

        public MembershipType GetMembershipType(int membershipId)
        {
            var m = Memberships.FirstOrDefault(x => x.idMembership == membershipId);
            return m;
        }

        public List<MembershipType> GetMembershipTypes()
        {
            return Memberships;
        }
    }
}
