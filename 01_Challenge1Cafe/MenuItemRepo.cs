using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge1Cafe
{
    public class MenuItemRepo
    {
        private readonly List<MenuItem> _menuItemDirectory = new List<MenuItem>();

        //Create
        public void AddMenuItemToList(MenuItem menuItem)
        {
            _menuItemDirectory.Add(menuItem);
        }

        //Read
        public List<MenuItem> GetMenuList()
        {
            return _menuItemDirectory;
        }

        //Update -- not needed
        //public bool UpdateMenuItemInfo(int existingMenuNumber, MenuItem newMenuItem)
        //{
        //    //find the menu item to update
        //    MenuItem oldInfo = GetMenuItemByNumber(existingMenuNumber);

        //    //update menu item
        //    if (oldInfo != null)
        //    {
        //        oldInfo.MealNumber = newMenuItem.MealNumber;
        //        oldInfo.MealName = newMenuItem.MealName;
        //        oldInfo.Description = newMenuItem.Description;
        //        oldInfo.Ingredients = newMenuItem.Ingredients;
        //        oldInfo.Price = newMenuItem.Price;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Delete
        public bool RemoveMenuItemFromList(int mealNumber)
        {
            MenuItem menuItem = GetMenuItemByNumber(mealNumber);
            if (menuItem == null)
            {
                return false;
            }

            int initialMenuItemCount = _menuItemDirectory.Count;
            _menuItemDirectory.Remove(menuItem);

            if (initialMenuItemCount > _menuItemDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get By Number
        public MenuItem GetMenuItemByNumber(int mealNumber)
        {
            foreach (MenuItem menuItem in _menuItemDirectory)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}

