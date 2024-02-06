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
        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();

            members.Add(new Member
                {
                name = "Israel",
                lastName= "Pérez",
                birth = new DateTime(1986, 9, 24),
                allowNewsLetter = true,
                cityId = 1,
                email = "isra@prueba.com"
            });
            members.Add(new Member
            {
                name = "Ana",
                lastName = "García",
                birth = new DateTime(1990, 5, 15),
                allowNewsLetter = false,
                cityId = 2,
                email = "ana@example.com"
            });

            members.Add(new Member
            {
                name = "Juan",
                lastName = "López",
                birth = new DateTime(1985, 7, 3),
                allowNewsLetter = true,
                cityId = 3,
                email = "juan@example.com"
            });

            members.Add(new Member
            {
                name = "María",
                lastName = "Martínez",
                birth = new DateTime(1988, 11, 8),
                allowNewsLetter = true,
                cityId = 1,
                email = "maria@example.com"
            });

            members.Add(new Member
            {
                name = "Pedro",
                lastName = "Gómez",
                birth = new DateTime(1993, 3, 21),
                allowNewsLetter = false,
                cityId = 2,
                email = "pedro@example.com"
            });

            members.Add(new Member
            {
                name = "Laura",
                lastName = "Hernández",
                birth = new DateTime(1982, 12, 10),
                allowNewsLetter = true,
                cityId = 3,
                email = "laura@example.com"
            });

            members.Add(new Member
            {
                name = "Carlos",
                lastName = "Ruiz",
                birth = new DateTime(1995, 8, 28),
                allowNewsLetter = true,
                cityId = 1,
                email = "carlos@example.com"
            });
            return members;
        }
    }
}
