﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        private string name;
        private DateTime birthDate;
        private int age;
        private Gender gender;

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

        public override string ToString()
        {
            return "Name: " + name + " BirthDate: " + birthDate.Year + " Age: " + age + " Gender: " + gender;
        }
    }
}