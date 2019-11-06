using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Maria", new DateTime(1998, 01, 01), "FEMALE");
            person.Serialize("something");
            Person person1 = Person.Deserialize();
            Console.WriteLine(person1);
            Console.ReadKey();
        }
    }
}
