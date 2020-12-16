﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge3BadgesRepo
{
    public class BadgeRepo
    {
        public Dictionary<int, Badge> _dictionaryBadges = new Dictionary<int, Badge>();

        //Create a new Badge
        //Update Doors on Existing Badge
        //Delete All Doors on Existing Badge
        //Show a list with all badge numbers and door access


        //Create
        public void CreateNewBadge(int badgeID, Badge badgeItem)
        {
            _dictionaryBadges.Add(badgeID, badgeItem);
        }

        //Read
        public Dictionary<int, Badge> GetBadges()
        {
            return _dictionaryBadges;
        }

        //Update
        public bool UpdateDoorsOnBadge(int badgeNumber, string doorsString)
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }

            List<string> doorNames = new List<string>();
            string[] doorArray = doorsString.Split(',');

            foreach (string door in doorArray)
            {
                doorNames.Add(door.Trim());
            }

            badgeItem.DoorNamesList = doorNames;
            return true;
        }

        //Update - Adding Doors to List without Deleting Existing Doors -- IN PROGRESS
        public bool AddDoorsToBadge(int badgeNumber, string doorsString) //-- IN PROGRESS
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }

            List<string> doorNames = new List<string>();
            string[] doorArray = doorsString.Split(',');

            foreach (string door in doorArray)
            {
                badgeItem.DoorNamesList.Add(door.Trim());
            }

            return true;
        }

        //Delete All Doors on Existing Badge
        public bool RemoveDoorsFromBadge(int badgeNumber)
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null)
            {
                return false;
            }

            badgeItem.DoorNamesList.Clear();
            return true;
        }

        //Delete Single Door on Existing Badge
        public bool RemoveSingleDoorFromBadge(int badgeNumber, string doorNumber)
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeItem == null || badgeItem.DoorNamesList.Contains(doorNumber) == false)
            {
                return false;
            }

            //if (badgeItem.DoorNamesList.Contains(doorNumber))
            
                badgeItem.DoorNamesList.Remove(doorNumber);
                return true;
            

        }

        //Delete Badge -- not required
        public bool RemoveBadge(int badgeNumber) // -- may not need this, but the functionality is here
        {
            Badge badgeItem = GetBadgeByIDNumberTryGetValue(badgeNumber);
            if (badgeNumber == null)
            {
                return false;
            }

            int initialMenuItemCount = _dictionaryBadges.Count;
            _dictionaryBadges.Remove(badgeNumber);

            if (initialMenuItemCount > _dictionaryBadges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get By Number -- May be able to delete this... replaced with GetBadgeByIDNumberTryGetValue
        public Badge GetBadgeByIDNumber(int badgeNumber)
        {
            Badge badgeItem = _dictionaryBadges[badgeNumber];
            return badgeItem;
        }

        //Get By Number -- using TryGetValue
        public Badge GetBadgeByIDNumberTryGetValue(int badgeNumber)
        {
            Badge badge;
            _dictionaryBadges.TryGetValue(badgeNumber, out badge);
            return badge;
        }
    }
}
