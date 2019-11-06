using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SerializePeople.Tests
{
    [TestFixture]
    public class SerializePeopleTest
    {
        [Test]
        public void ToString_GivenNameBirthYearAndGender_ShouldReturnString()
        {
            Person person = new Person("Maria", new DateTime(1998, 01, 01), "FEMALE");
            Assert.AreEqual("Name: Maria BirthDate: 1998 Age: 21 Gender: FEMALE", person.ToString());
        }
    }
}
