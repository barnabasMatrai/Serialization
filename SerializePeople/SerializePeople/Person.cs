using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback, ISerializable
    {
        private string name;
        private DateTime birthDate;
        [NonSerialized]
        private int age;
        private Gender gender;

        public Person()
        {
            name = "";
            birthDate = new DateTime();
            gender = Gender.MALE;
        }

        public Person(string name, DateTime birthDate, string gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            age = DateTime.Today.Year - birthDate.Year;

            switch (gender)
            {
                case "MALE":
                    this.gender = Gender.MALE;
                    break;
                case "FEMALE":
                    this.gender = Gender.FEMALE;
                    break;
            }
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("name", typeof(string));
            birthDate = (DateTime)info.GetValue("birthDate", typeof(DateTime));
            gender = (Gender)info.GetValue("gender", typeof(Gender));
        }

        public override string ToString()
        {
            return "Name: " + name + " BirthDate: " + birthDate.Year + " Age: " + age + " Gender: " + gender;
        }

        public Stream Serialize(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this);
            stream.Close();

            return stream;
        }

        public static Person Deserialize(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            Person person = (Person)formatter.Deserialize(stream);
            stream.Close();
            
            return person;
        }

        public void OnDeserialization(object sender)
        {
            age = DateTime.Today.Year - birthDate.Year;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name);
            info.AddValue("birthDate", birthDate);
            info.AddValue("gender", gender);
        }
    }
}
