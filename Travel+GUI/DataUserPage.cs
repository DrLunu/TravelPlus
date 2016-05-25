using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_GUI
{

    /// <summary>
    /// Клас для передачі даних про користувача
    /// 
    /// version: 1.0
    /// last update: 02.05.2015, 13:12
    /// </summary>
    public class DataUserPage
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        private int id;

        /// <summary>
        /// Ім'я
        /// </summary>
        private String name;

        /// <summary>
        /// Прізвище
        /// </summary>
        private String surname;

        /// <summary>
        /// Дата народження
        /// </summary>
        private double date;

        /// <summary>
        /// Місце проживання
        /// </summary>
        private String city;

        /// <summary>
        /// Контакти
        /// </summary>
        private String contacts;

        /// <summary>
        /// Код категорій
        /// </summary>
        private int categories;

        /// <summary>
        /// Список друзів
        /// </summary>
        private List<DataMini> friends;

        /// <summary>
        /// Список запланованих подій
        /// </summary>
        private List<DataMini> events;

        /// <summary>
        /// Фотографії запланованих подій
        /// </summary>
        private List<Bitmap> eventsPictures;

        /// <summary>
        /// Створює новий об'єкт класу із заданою інформацією за виключенням списку друзів
        /// (для перегляду користувачем сторінки будь-якого користувача, крім себе)
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Ім'я</param>
        /// <param name="surname">Прізвище</param>
        /// <param name="date">Дата народження</param>
        /// <param name="city">Місце проживання</param>
        /// <param name="contacts">Контакти</param>
        /// <param name="categories">Код категорій</param>
        /// <param name="events">Список запланованих подій</param>
        /// <param name="eventsPictures">Фотографії запланованих подій</param>
        public DataUserPage(int id, string name, string surname, double date, string city, string contacts,
            int categories, List<DataMini> events, List<Bitmap> eventsPictures)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Date = date;
            this.City = city;
            this.Contacts = contacts;
            this.Categories = categories;
            this.Events = events;
            this.EventPictures = eventsPictures;
    }

        /// <summary>
        /// Створює новий об'єкт класу із заданою інформацією (для перегляду користувачем своєї сторінки)
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Ім'я</param>
        /// <param name="surname">Прізвище</param>
        /// <param name="date">Дата народження</param>
        /// <param name="city">Місце проживання</param>
        /// <param name="contacts">Контакти</param>
        /// <param name="categories">Код категорій</param>
        /// <param name="friends">Список друзів</param>
        /// <param name="events">Список запланованих подій</param>
        /// <param name="eventsPictures">Фотографії запланованих подій</param>
        public DataUserPage(int id, string name, string surname, double date, string city, string contacts,
            int categories, List<DataMini> friends, List<DataMini> events, List<Bitmap> eventPictures)
            : this(id, name, surname, date, city, contacts, categories, events, eventPictures)
        {
            this.Friends = friends;
        }

        /// <summary>
        /// Властивість - ідентифікатор
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Властивість - ім'я
        /// </summary>
        public String Name
        {
            set { name = (String)value.Clone(); }
            get { return (String)name.Clone(); }
        }

        /// <summary>
        /// Властивість - прізвище
        /// </summary>
        public String Surname
        {
            set { surname = (String)value.Clone(); }
            get { return (String)surname.Clone(); }
        }

        /// <summary>
        /// Властивість - код категорій
        /// </summary>
        public int Categories
        {
            set { categories = value; }
            get { return categories; }
        }

        /// <summary>
        /// Властивість - місце проживання
        /// </summary>
        public String City
        {
            set { city = (String)value.Clone(); }
            get { return (String)city.Clone(); }
        }

        /// <summary>
        /// Властивість - контакти
        /// </summary>
        public String Contacts
        {
            set { contacts = (String)value.Clone(); }
            get { return (String)contacts.Clone(); }
        }

        /// <summary>
        /// Властивість - дата народження
        /// </summary>
        public double Date
        {
            set { date = value; }
            get { return date; }
        }

        /// <summary>
        /// Властивість - список друзів
        /// </summary>
        public List<DataMini> Friends
        {
            set { friends = value; }
            get { return friends; }
        }

        /// <summary>
        /// Властивість - список запланованих подій
        /// </summary>
        public List<DataMini> Events
        {
            set { events = value; }
            get { return events; }
        }

        /// <summary>
        /// Властивість - фотографії запланованих подій
        /// </summary>
        public List<Bitmap> EventPictures
        {
            set { eventsPictures = value; }
            get { return eventsPictures; }
        }

        /// <summary>
        /// Отримує текстове представлення об'єкту
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().ToString() + " [" + Id + ", " + Name + ", " +
                Surname + ", " + Categories + ", " + City + ", " + Contacts +
                ", " + Date + ", " + (friends == null ? "[null]" : friends.Count.ToString()) + 
                " friends, " + (events == null ? "[null]" : events.Count.ToString()) + " events, " + 
                (eventsPictures == null ? "[null]" : eventsPictures.Count.ToString()) + " pictures]";
        }
    }
}
