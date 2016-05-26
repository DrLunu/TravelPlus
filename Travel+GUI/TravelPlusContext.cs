using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_GUI.Models;

namespace Travel_GUI
{
    class TravelPlusContext : DbContext
    {

        public TravelPlusContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }


    }
}
