using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_GUI.Models
{
    class User
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Contacts { get; set; }

    }
}
