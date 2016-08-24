using System;
using System.Linq;
using Common.Ioc;
using CommonTests.ExampleTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.Ioc
{
    /// <summary>
    /// Todo: Ekrem Ayça ile bu test methodları doldurun.
    /// </summary>
    [TestClass()]
    public class ContainerTests
    {
        public ContainerTests()
        {

        }


        [TestMethod()]
        public void ResolveTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ResolveTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ResolveTest2()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ResolveTest3()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void RegisterTest()
        {
            IContainer container = new Container();
            container.Register<Person>("ayca", null);
            var person = container.Resolve<Person>("ayca");
            Assert.IsNotNull(person);
            Assert.IsNotNull(container.RegisteredObjects);
            Assert.AreEqual(container.RegisteredObjects.Any(),true);

        }

        [TestMethod()]
        public void RegisterTest1()
        {

            IContainer container = new Container();
            container.Register<Person>("ayca", new object[] { "Ayça", "ÖNAY" });
            var person = container.Resolve<Person>("ayca");
            Assert.IsNotNull(person);

            Assert.AreEqual(person.Name, "Ayça");
            Assert.AreEqual(person.LastName, "ÖNAY");
        }
        [TestMethod()]
        public void RegisterTest2()
        {

            IContainer container = new Container();
            container.Register("ayca",typeof(Person), new object[] { "Ayça", "ÖNAY" });
            var person = container.Resolve<Person>("ayca");
            Assert.IsNotNull(person);
            Assert.AreEqual(person.Name, "Ayça");
            Assert.AreEqual(person.LastName, "ÖNAY");
        }

        [TestMethod()]
        public void ResolveAllTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ResolveAllTest1()
        {
            throw new NotImplementedException();
        }
    }
}