using System;
using System.Collections.Generic;
using _03_Challenge3BadgesRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge3BadgesTests
{
    [TestClass]
    public class BadgeRepoTests
    {

        private BadgeRepo _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo(); 
            _badge = new Badge(101);

            _repo.CreateNewBadge(101, _badge);
        }

        //Create Test
        [TestMethod]
        public void CreateNewBadge_ShouldGetNotNull()
        {
            //Arrange

            //Act
            _repo.CreateNewBadge(102,_badge);
            Badge badgeFromRepo = _repo.GetBadgeByIDNumberTryGetValue(102);

            //Assert
            Assert.IsNotNull(badgeFromRepo);
        }

        //Read Method Test
        [TestMethod]
        public void ReturnBadgeDictionary_ShouldBeNotNull()
        {
            //Arrange
            Dictionary<int, Badge> testDictionary = new Dictionary<int, Badge>();
            //Act
            testDictionary = _repo.GetBadges();

            //Assert
            Assert.IsNotNull(testDictionary);
        }

        //Update Doors on a Badge Test
        [TestMethod]
        public void UpdateDoorsOnBadgeShouldBeEqual()
        {
            //Arrange
           
            //Act
            _repo.UpdateDoorsOnBadge(101, "12,14,16,18");

            //Assert
            Assert.AreEqual(4, _badge.DoorNamesList.Count);
        }

        //Update Select Doors
        [TestMethod]
        public void AddDoorsToBadgeShouldBeEqual()
        {
            //Arrange
            _repo.UpdateDoorsOnBadge(101, "12,14,16,18");

            //Act
            _repo.AddDoorsToBadge(101, "1, 2, 3");

            //Assert
            Assert.AreEqual(7, _badge.DoorNamesList.Count);
        }

        //Delete Method Test
        [TestMethod]
        public void DeleteDoorsFromBadgeTestShouldReturnTrue()
        {
            //Arrage
            _repo.UpdateDoorsOnBadge(101, "2,3,4");
            //Act
            _repo.RemoveDoorsFromBadge(101);

            bool doorsOnBadge = _badge.DoorNamesList.Count == 0;

            //Assert
            Assert.IsTrue(doorsOnBadge = true);
        }

        //Delete Selected Door Method Test
        [TestMethod]
        public void RemoveSelectedDoorsFromBadgeTestShouldReturnTrue()
        {
            //Arrage
            _repo.UpdateDoorsOnBadge(101, "2,3,4");
            int initialCount = _badge.DoorNamesList.Count;
            //Act
            _repo.RemoveSelectedDoorsFromBadge(101, "2,4");
            int resultCount = _badge.DoorNamesList.Count;

            //Assert
            Assert.IsTrue(initialCount > resultCount);
        }

        //Get By Number Method Using Try Get Value Test
        [TestMethod]
        public void GetBadgeByIDTryGetValue_ShouldBeEqual() 
        {
            //Arrange

            //Act
            Badge badge = _repo.GetBadgeByIDNumberTryGetValue(101);
            int badgeNumber = badge.BadgeID;

            //Assert
            Assert.AreEqual(101, badgeNumber);
        }

    }
}
