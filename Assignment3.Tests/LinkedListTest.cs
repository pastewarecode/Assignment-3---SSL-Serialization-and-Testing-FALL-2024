using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        //• The linked list is empty.
        [Test]
        public void TestEmptyList()
        {
            SLL list = new SLL();
            Assert.IsTrue(list.IsEmpty(), "List should be empty.");
        }

        //• An item is prepended.
        [Test]
        public void TestPrependItem()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            list.AddFirst(user1);

            Assert.IsFalse(list.IsEmpty(), "List should not be empty after adding an item.");
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("user1", list.GetValue(0).Name);
        }

        //• An item is appended.
        [Test]
        public void TestAppendItem()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual("user1", list.GetValue(0).Name);
            Assert.AreEqual("user2", list.GetValue(1).Name);
        }

        //• An item is inserted at index.
        [Test]
        public void TestInsertItemAtIndex()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");
            User user3 = new User(3, "user3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.Add(user3, 1);

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual("user1", list.GetValue(0).Name);
            Assert.AreEqual("user3", list.GetValue(1).Name);
            Assert.AreEqual("user2", list.GetValue(2).Name);
        }

        //• An item is replaced.
        [Test]
        public void TestReplaceItemAtIndex()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);
            User user3 = new User(3, "user3", "user3@example.com", "password3");

            list.Replace(user3, 1);

            Assert.AreEqual("user3", list.GetValue(1).Name);
        }

        //• An item is deleted from beginning of list.
        [Test]
        public void TestRemoveFirstItem()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveFirst();

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("user2", list.GetValue(0).Name);
        }

        //• An item is deleted from end of list.
        [Test]
        public void TestRemoveLastItem()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveLast();

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("user1", list.GetValue(0).Name);
        }

        //• An item is deleted from middle of list.
        [Test]
        public void TestRemoveItemFromMiddle()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");
            User user3 = new User(3, "user3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Remove(1);

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual("user1", list.GetValue(0).Name);
            Assert.AreEqual("user3", list.GetValue(1).Name);
        }

        //• An existing item is found and retrieved.
        [Test]
        public void TestFindAndRetrieveItem()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            int index = list.IndexOf(user2);
            Assert.AreEqual(1, index);
            Assert.AreEqual("user2", list.GetValue(index).Name);
        }

        //• The additional functionality is working.
        [Test]
        public void TestReverseFunctionality()
        {
            SLL list = new SLL();
            User user1 = new User(1, "user1", "user1@example.com", "password1");
            User user2 = new User(2, "user2", "user2@example.com", "password2");
            User user3 = new User(3, "user3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            list.Reverse();

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual("user3", list.GetValue(0).Name);
            Assert.AreEqual("user2", list.GetValue(1).Name);
            Assert.AreEqual("user1", list.GetValue(2).Name);
        }
    }
}
