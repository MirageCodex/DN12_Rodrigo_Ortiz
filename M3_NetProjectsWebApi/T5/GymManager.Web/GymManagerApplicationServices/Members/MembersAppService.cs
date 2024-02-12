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

        public void DeleteMember(int memberId)
        {
            var m = Members.Where(x=> x.Id == memberId).FirstOrDefault();

            Members.Remove(m);
        }

        public void EditMember(Member member)
        {
            var m = Members.Where(x => x.Id == member.Id).FirstOrDefault();
            m.allowNewsLetter = member.allowNewsLetter;
            m.birth = member.birth;
            m.cityId = member.cityId;
            m.email = member.email;
            m.lastName = member.lastName;
            m.name = member.name;
        }

        public Member GetMember(int memberId)
        {
            var m = Members.Where(x => x.Id == memberId).FirstOrDefault();
            return m;
        }

        public List<Member> GetMembers()
        {
            
            return Members;
        }
    }
}
