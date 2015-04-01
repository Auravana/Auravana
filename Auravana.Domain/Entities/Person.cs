using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool DisplayDateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }
    }
}
