using Auravana.Domain.Abstract;
using Auravana.Domain.Entities;
using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Concrete
{
    public class EfPersonRepository : IPersonRepository
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Person> People
        {
            get { return _context.Persons; }
        }

        public void SavePerson(Person person)
        {
            if (person.PersonID == 0)
            {
                _context.Persons.Add(person);
            }
            else
            {
                var existingPerson = _context.Persons.Find(person.PersonID);
                if (existingPerson != null)
                {
                    existingPerson = Mapper.Map<Person>(person);
                }
            }

            _context.SaveChanges();

            log.Debug("Person:{0}{1}", Environment.NewLine, person);
        }

        public Person DeletePerson(int personID)
        {
            var existingPerson = _context.Persons.Find(personID);

            if (existingPerson != null)
            {
                _context.Persons.Remove(existingPerson);
                _context.SaveChanges();
            }

            return existingPerson;
        }
    }
}
