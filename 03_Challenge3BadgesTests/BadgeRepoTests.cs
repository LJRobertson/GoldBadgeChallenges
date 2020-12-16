using System;
using System.Collections.Generic;
using _03_Challenge3BadgesRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge3BadgesTests
{
    [TestClass]
    public class BadgeRepoTests
    {

        private BadgeRepo _repo; //declare
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo(); //initializing 
            _badge = new Badge(101);

            _repo.CreateNewBadge(101, _badge);
        }

        //create a new badge -- Done
        //Read
        //Update doors on a badge -- Done
        //Delete Doors
        //delete badge
        //get methdod -- DONE


        //Create Test -- DONE
        [TestMethod]
        public void CreateNewBadge_ShouldGetNotNull() //-- DONE
        {
            //Arrange

            //Act
            _repo.CreateNewBadge(102,_badge);
            Badge badgeFromRepo = _repo.GetBadgeByIDNumber(102);

            //Assert
            Assert.IsNotNull(badgeFromRepo);
        }

        //Read Method Test -- DONE
        [TestMethod]
        public void ReturnBadgeDictionary_ShouldBeNotNull() // -- DONE
        {
            //Arrange
            Dictionary<int, Badge> testDictionary = new Dictionary<int, Badge>();
            //Act
            testDictionary = _repo.GetBadges();

            //Assert
            Assert.IsNotNull(testDictionary);
        }

        //Update Doors on a Badge Test -- DONE
        [TestMethod]
        public void UpdateDoorsOnBadgeShouldBeEqual() //-- DONE
        {
            //Arrange
           
            //Act
            _repo.UpdateDoorsOnBadge(101, "12,14,16,18");

            //Assert
            Assert.AreEqual(4, _badge.DoorNamesList.Count);
        }

        //Update -- Add Doors on a Badge w/o deleting Test -- DONE
        [TestMethod]
        public void AddDoorsToBadgeShouldBeEqual() //-- DONE
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
        public void DeleteDoorsFromBadgeTestShouldReturnTrue()// -- DONE
        {
            //Arrage
            _repo.UpdateDoorsOnBadge(101, "2,3,4");
            //Act
            _repo.RemoveDoorsFromBadge(101);

            bool doorsOnBadge = _badge.DoorNamesList.Count == 0;

            //Assert
            Assert.IsTrue(doorsOnBadge = true);
        }


        //Get By Number Method Test -- DONE
        [TestMethod]
        public void GetBadgeByID_ShouldBeEqual() //-- DONE
        {
            //Arrange

            //Act
            Badge badge = _repo.GetBadgeByIDNumber(101);
            int badgeNumber = badge.BadgeID;

            //Assert
            Assert.AreEqual(101, badgeNumber);
        }

        //Get By Number Method Using Try Get Value Test -- DONE
        [TestMethod]
        public void GetBadgeByIDTryGetValue_ShouldBeEqual() //--DONE 
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
