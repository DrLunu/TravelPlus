using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_GUI
{
    public class RegistrationData
    {
        private String name;
        private String surname;
        private double date;
        private String city;
        private String contacts;
        private int categories;
        private String password;
        private String e_mail;

        public String Name
        {
            set { name = (String)value.Clone(); }
            get { return (String)name.Clone(); }
        }

        public String Surname
        {
            set { surname = (String)value.Clone(); }
            get { return (String)surname.Clone(); }
        }

        public int Categories
        {
            set { categories = value; }
            get { return categories; }
        }

        public String City
        {
            set { city = (String)value.Clone(); }
            get { return (String)city.Clone(); }
        }

        public String Contacts
        {
            set { contacts = (String)value.Clone(); }
            get { return (String)contacts.Clone(); }
        }

        public double Date
        {
            set { date = value; }
            get { return date; }
        }

        public String Password
        {
            set { password = (String)value.Clone(); }
            get { return (String)password.Clone(); }
        }

        public String E_mail
        {
            set { e_mail = (String)value.Clone(); }
            get { return (String)e_mail.Clone(); }
        }
    }
}
