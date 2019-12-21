using System;
using NUnit.Framework;
using System.Collections.Generic;
using AutoItX3Lib;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            //Data
            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            GroupDate group = oldGroups[1];
            
            //Actions
            app.Groups.RemovalGroup(group);
            
            //Verification
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
