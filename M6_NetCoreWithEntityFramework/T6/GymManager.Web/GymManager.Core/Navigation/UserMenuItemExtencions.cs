using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Navigation
{
    public static class UserMenuItemExtencions
    {
        public static bool IsMenuActive(this UserMenuItem menuItem, string currentPageName)
        {
            if (menuItem.Name == currentPageName)
            {
                return true;
            }
            if (menuItem.Items != null)
            {
                foreach (var subMenuItems in menuItem.Items)
                {
                    if (subMenuItems.IsMenuActive(currentPageName)) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
