using System;
using System.Collections.Generic;
using _01_Challenge1Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge1CafeTests
{
    [TestClass]
    public class CafeRepoTests
    {
        private MenuItemRepo _repo; //declare
        private MenuItem _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepo(); //initializing 
            _item = new MenuItem(1, "Sub Sandwhich", "sub sandwhich and chips", "bread, turkey, cheese, lettuce, tomato", 9.95);
            
            _repo.AddMenuItemToList(_item);
        }

        //Create Method Test -- DONE
        [TestMethod]
        public void AddToList_ShouldGetNotNull()//passes
        {
            //Arrange
            MenuItem item = new MenuItem();
            item.MealNumber = 7;
            MenuItemRepo repo = new MenuItemRepo();

            //Act
            repo.AddMenuItemToList(item);
            MenuItem itemFromRepo = repo.GetMenuItemByNumber(7);

            //Assert
            Assert.IsNotNull(itemFromRepo);
        }

        
        //Read Method Test -- DONE
        [TestMethod]
        public void ReturnItemList_ShouldBeNotNull()// passes
        {
            //Arrange
            //Act

            List<MenuItem> testList = _repo.GetMenuList();
            
            //Assert
            Assert.IsNotNull(testList);
        }


        //Delete Method Test -- DONE
        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()//passes
        {
            //Arrange in in the initialize
            //Act
            bool deleteItem = _repo.RemoveMenuItemFromList(_item.MealNumber);

            //Assert
            Assert.IsTrue(deleteItem);
        }

        //Get By Number Method Test -- DONE

        [TestMethod]
        public void GetMenuItemByNumber_ShouldBeEqual()// passes
        {
            // Arrange
            //Act
            MenuItem item = _repo.GetMenuItemByNumber(1);
            int mealNumber = item.MealNumber;
            
            //Assert
            Assert.AreEqual(1, mealNumber);
        }

    }
}
