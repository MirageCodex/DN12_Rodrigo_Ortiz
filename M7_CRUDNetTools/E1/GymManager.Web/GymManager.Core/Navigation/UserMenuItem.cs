using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Navigation
{
    public class UserMenuItem
    {
        public String Name { get; set; }

        public String Icon { get; set; }

        public String DisplayName { get; set; }

        public int Order { get; set; }

        public String Url { get; set; }

        public IList<UserMenuItem> Items { get; set;}

        public UserMenuItem()
        {
            Items = new List<UserMenuItem>();
        }

        
    }
}
