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

        public Person Create(string name, string city, int phoneNumber)
        {
            Person person = new Person(name, phoneNumber, city, idCounter);
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
    }
}
