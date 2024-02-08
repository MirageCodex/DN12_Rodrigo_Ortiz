using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.Members
{
    public class MembersAppService : IMembersAppService
    {
        private static List<Member> Members = new List<Member>();
        public int AddMember(Member member)
        {
            Random random = new Random();
            member.Id = random.Next();

            Members.Add(member);
            return member.Id;
        }

        public List<Member> GetMembers()
        {
            
            return Members;
        }
    }
}
