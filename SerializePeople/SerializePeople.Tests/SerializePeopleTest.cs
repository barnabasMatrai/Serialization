using System;
using System.IO;
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

        [Test]
        public void Serialize_CheckIfFileIsCreatedAutomatically()
        {
            string filePath = @"C:\Users\matra\OneDrive\Asztali gép\codecool\SI_assignments\3rd_week\Serialization\SerializePeople\data.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            Person person = new Person();
            person.Serialize(filePath);
            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void Deserialize_GivenDefaultPerson_ShouldReturnCorrectString()
        {
            string filePath = @"C:\Users\matra\OneDrive\Asztali gép\codecool\SI_assignments\3rd_week\Serialization\SerializePeople\data.txt";
            Person person = new Person();
            person.Serialize(filePath);
            Person person1 = Person.Deserialize(filePath);
            Assert.AreEqual("Name:  BirthDate: 1 Age: 2018 Gender: MALE", person1.ToString());
        }
    }
}
