using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _context;

        public DatabasePeopleRepo(PeopleDbContext context)
        {
            _context = context;
        }

        public Person Create(string name, int cityId, List<int> languageIds, int phoneNumber)
        {
            City city = _context.Cities.Find(cityId);

            Person person = new Person(name, phoneNumber);
            person.City = city;

            List<KnownLanguage> knownLanguages = new List<KnownLanguage>();
            Language language;
            foreach (int item in languageIds)
            {
                language = null;
                language = _context.Languages.Find(item);

                KnownLanguage knownLanguage = new KnownLanguage();
                knownLanguage.Person = person;
                knownLanguage.PersonId = person.Id;
                knownLanguage.Language = language;
                knownLanguage.LanguageId = language.LanguageId;

                knownLanguages.Add(knownLanguage);
                _context.KnownLanguages.Add(knownLanguage);
            }
            person.KnownLanguageList = knownLanguages;

            _context.People.Add(person);
            _context.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            _context.People.Remove(person);
            int nrOfChanges = _context.SaveChanges();

            bool deleted = false;
            if (nrOfChanges == 1)
                deleted = true;

            return deleted;
        }

        public List<Person> Read()
        {
            return _context.People.ToList();
        }

        public Person Read(int id)
        {
            //LINQ expression
            // Define the query expression
            //IEnumerable<Person> personQuery =
            //    from person in _personList
            //    where person.Id == id
            //    select person;

            //return personQuery.First();
            Person person = _context.People.Find(id);

            return person;
        }

        public Person Update(CreatePersonViewModel createPersonViewModel)
        {
            Person person = _context.People.Find(createPersonViewModel.Id);
            person.Name = createPersonViewModel.Name;
            person.Phone = createPersonViewModel.Phone;
            person.City = _context.Cities.Find(createPersonViewModel.CityId);
            List<KnownLanguage> knownLanguages = new List<KnownLanguage>();

            foreach (var item in person.KnownLanguageList)
            {
                _context.KnownLanguages.Remove(item);
            }
            _context.SaveChanges();


            foreach (int id in createPersonViewModel.LanguageId)
            {
                KnownLanguage knownLanguage = new KnownLanguage();
                knownLanguage.Language = _context.Languages.Find(id);
                knownLanguage.LanguageId = id;
                knownLanguage.Person = person;
                knownLanguage.PersonId = person.Id;

                knownLanguages.Add(knownLanguage);
                _context.KnownLanguages.Add(knownLanguage);
            }
            person.KnownLanguageList = knownLanguages;

            _context.People.Update(person);
            _context.SaveChanges();

            return person;
        }
    }
}
