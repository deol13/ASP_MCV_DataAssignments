using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static int idCounter = 0;

        public Person Create(string name, string city, int phoneNumber) //id   sent in from controller or just send in a Person
        {
            //Remember to remove id from Person constructor and from here because with [Key] the database set it automaticly.
            Person person = null;//= new Person(name, phoneNumber, city, idCounter);
            idCounter++;

            _personList.Add(person);

            return person;
        }

        public bool Delete(Person person)
        {
            bool deleted = _personList.Remove(person);

            return deleted;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public Person Read(int id)
        {
            foreach (Person item in _personList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public Person Update(Person person)
        {
            foreach (Person item in _personList)
            {
                if (item.Id == person.Id)
                {
                    item.Name = person.Name;
                    item.Phone = person.Phone;
                    item.City = person.City;
                }
            }

            return person;
        }

        public void GetAllPeopleFromDatabase() //Get a _context as paramter
        {
            //list = _context.allpeople
            //foreach list {
            //idCounter++;
            //_personList.Add(person);
            //}
        }
    }
}
