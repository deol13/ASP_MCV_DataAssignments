using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models.ViewModel;
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

        public Language Create(CreateLanguageViewModel createLanguageViewModel)
        {
            Language language = new Language(createLanguageViewModel.Name);

            List<KnownLanguage> knownLanguages = new List<KnownLanguage>();
            Person person;
            foreach (int item in createLanguageViewModel.PeopleIds)
            {
                person = null;
                person = _context.People.Find(item);

                KnownLanguage knownLanguage = new KnownLanguage();
                knownLanguage.Person = person;
                knownLanguage.PersonId = person.Id;
                knownLanguage.Language = language;
                knownLanguage.LanguageId = language.LanguageId;

                knownLanguages.Add(knownLanguage);
                _context.KnownLanguages.Add(knownLanguage);
            }
            language.KnownLanguageList = knownLanguages;

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

        public Language Update(CreateLanguageViewModel createLanguageViewModel)
        {
            Language language = _context.Languages.Find(createLanguageViewModel.Id);
            language.Name = createLanguageViewModel.Name;
            List<KnownLanguage> knownLanguages = new List<KnownLanguage>();

            foreach (var item in language.KnownLanguageList)
            {
                _context.KnownLanguages.Remove(item);
            }
            _context.SaveChanges();

            foreach (int id in createLanguageViewModel.PeopleIds)
            {
                KnownLanguage knownLanguage = new KnownLanguage();
                knownLanguage.Person = _context.People.Find(id);
                knownLanguage.PersonId = id;
                knownLanguage.Language = language;
                knownLanguage.LanguageId = language.LanguageId;

                knownLanguages.Add(knownLanguage);
                _context.KnownLanguages.Add(knownLanguage);
            }
            language.KnownLanguageList = knownLanguages;

            _context.Languages.Update(language);
            _context.SaveChanges();

            return language;
        }
    }
}
