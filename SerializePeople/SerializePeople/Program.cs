using System;
using System.IO;
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
            person.Serialize(@"C:\Users\matra\OneDrive\Asztali gép\codecool\SI_assignments\3rd_week\Serialization\SerializePeople\data.txt");
            Person person1 = Person.Deserialize(@"C:\Users\matra\OneDrive\Asztali gép\codecool\SI_assignments\3rd_week\Serialization\SerializePeople\data.txt");
            Console.WriteLine(person1);
            Console.ReadKey();
        }
    }
}
