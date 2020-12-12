using System;
using _01_Challenge1Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge1CafeTests
{
    [TestClass]
    public class CafeRepoTests
    {
        private MenuItemRepo _repo;
        private MenuItem _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepo();
            _item = new MenuItem(1, "Sub Sandwhich", "sub sandwhich and chips", "bread, turkey, cheese, lettuce, tomato", 9.95);

            _repo.AddMenuItemToList(_item);
        }

        //Add Method Test
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
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

        //View Method Test
       // [TestMethod]
        //public void ReturnItemList_ShouldGetNotNull()
        //{
            //Arrange
            //MenuItemRepo repo = new MenuItemRepo();

            //Act
            //MenuItem itemFromRepo = repo.GetMenuList(1);

            //Assert
            //Assert.IsNotNull(itemFromRepo);
        //}


        //Delete Method Test
        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            //Arrange in in the initialize
            //Act
            bool deleteItem = _repo.RemoveMenuItemFromList(_item.MealNumber);

            //Assert
            Assert.IsTrue(deleteItem);
        }

        //Get By Number
        [DataTestMethod]
       [DataRow(1, "Turkey")]
       [DataRow(2, "burger")]
        public void GetMenuItemByNumber_ShouldBeEqual()
        {
            //Arrange
            //Act

            MenuItem item = _repo.GetMenuItemByNumber(1);
            int mealNumber = item.MealNumber;

            //Assert
            Assert.AreEqual(item, mealNumber);
        }
             
        
    }
}
