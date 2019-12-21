using System;
using NUnit.Framework;
using System.Collections.Generic;
using AutoItX3Lib;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void TestGroupCreation()
        {
            //Save old list groups
            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            GroupDate newGroup = new GroupDate() { Name = "Test" };
            app.Groups.AddGroup(newGroup);
            //Save new list groups
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
