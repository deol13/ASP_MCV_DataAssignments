using ASP_MCV_DataAssignments.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _context;

        public LanguageRepo(PeopleDbContext context)
        {
            _context = context;
        }

        public KnownLanguage AddPersonToLanguage(int id, Person person)
        {
            Language language = Read(id);

            KnownLanguage knownLanguage = new KnownLanguage();
            knownLanguage.Person = person;
            knownLanguage.PersonId = person.Id;
            knownLanguage.Language = language;
            knownLanguage.LanguageId = language.LanguageId;

            language.KnownLanguageList.Add(knownLanguage);

            _context.Languages.Update(language);
            _context.SaveChanges();

            return knownLanguage;
        }

        public Language Create(string name)
        {
            Language language = new Language(name);

            _context.Languages.Add(language);
            _context.SaveChanges();

            return language;
        }

        public bool Delete(Language language)
        {
            _context.Languages.Remove(language);
            int nrOfChanges = _context.SaveChanges();

            bool deleted = false;
            if (nrOfChanges == 1)
                deleted = true;

            return deleted;
        }

        public List<Language> Read()
        {
            List<Language> languages = _context.Languages.ToList();

            return languages;
        }

        public Language Read(int id)
        {
            Language language = _context.Languages.Find(id);

            return language;
        }

        public Language Update(Language language)
        {
            _context.Languages.Update(language);
            _context.SaveChanges();

            return language;
        }
    }
}
