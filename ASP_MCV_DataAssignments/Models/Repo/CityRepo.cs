﻿using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public class CityRepo : ICityRepo
    {
        private readonly PeopleDbContext _context;

        public CityRepo(PeopleDbContext context)
        {
            _context = context;
        }

        public City Create(string name)
        {
            City city = new City(name);

            _context.Cities.Add(city);
            _context.SaveChanges();

            return city;
        }

        public bool Delete(City city)
        {
            _context.Cities.Remove(city);
            int nrOfChanges = _context.SaveChanges();

            bool deleted = false;
            if (nrOfChanges == 1)
                deleted = true;

            return deleted;
        }

        public List<City> Read()
        {
            List<City> cities = _context.Cities.ToList();

            return cities;
        }

        public City Read(int id)
        {
            City city = _context.Cities.Find(id);

            return city;
        }

        public City Update(CreateCityViewModel cityViewModel)
        {
            City city = new City(cityViewModel.Name);
            city.CityId = cityViewModel.CityId;

            List<Person> people = new List<Person>();
            foreach (var item in cityViewModel.PeopleIds)
            {
                people.Add(_context.People.Find(item));
            }
            city.PeopleInCity = people;

            _context.Cities.Update(city);
            _context.SaveChanges();

            return city;
        }
    }
}
