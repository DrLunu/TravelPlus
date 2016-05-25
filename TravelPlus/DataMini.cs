using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_GUI
{
    /// <summary>
    /// Клас для передачі невеликої кількості інформації про користувача або подію
    /// 
    /// version: 1.1
    /// last update: 03.05.2015, 14:32
    /// </summary>
    public class DataMini
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        private int id;

        /// <summary>
        /// Ім'я користувача або назва події
        /// </summary>
        private string name;

        /// <summary>
        /// Прізвище користувача
        /// </summary>
        private string surname;

        /// <summary>
        /// Створює об'єкт для передачі інформації про користувача
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Ім'я</param>
        /// <param name="surname">Прізвище</param>
        public DataMini(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        /// <summary>
        /// Створює об'єкт для передачі інформації про подію
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Назва</param>
        public DataMini(int id, string name)
        {
            this.id = id;
            this.Name = name;
            surname = null;
        }

        /// <summary>
        /// Індексатор для полегшеного зчитування даних
        /// </summary>
        /// <param name="i">Індекс</param>
        /// <returns>Ідентифікатор, ім'я (назва) або прізвище, в залежності від індексу</returns>
        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return name;
                    case 1:
                        return surname;
                    case 2:
                        return id.ToString();
                    default:
                        return null;

                }
            }

            set
            {
                switch (i)
                {
                    case 0:
                        name = value;
                        break;
                    case 1:
                        surname = value;
                        break;
                    case 2:
                        id = Convert.ToInt32(value);
                        break;
                    default:
                        break;

                }
            }
        }

        /// <summary>
        /// Повертає ідентифікатор
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Повертає ім'я користувача або назву події
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Повертає прізвище користувача
        /// </summary>
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        /// <summary>
        /// Отримує текстове представлення об'єкту
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.GetType().ToString() + " [" + Id + ", " + Name +
                ", " + Surname + "]");
        }
    }
}
