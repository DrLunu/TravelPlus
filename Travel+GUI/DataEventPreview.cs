using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travel_GUI
{ 
    /// <summary>
    /// Клас для передачі інформації для попередньго перегляду події
    /// 
    /// version: 1.1
    /// last update: 03.05.2015, 14:42
    /// </summary>
    public class DataEventPreview
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        protected int id;

        /// <summary>
        /// Назва
        /// </summary>
        protected string name;

        /// <summary>
        /// Опис
        /// </summary>
        protected string descr;

        /// <summary>
        /// Місце проведення
        /// </summary>
        protected string place;

        /// <summary>
        /// Кількість учасників
        /// </summary>
        protected int subscr_count;

        /// <summary>
        /// Дата проведення
        /// </summary>
        protected double oaDate;

        /// <summary>
        /// Код категорій події
        /// </summary>
        protected int categories;

        /// <summary>
        /// Фотографії
        /// </summary>
        protected List<Bitmap> photos;

        /// <summary>
        /// Створює новий об'єкт з певними даними
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="name">Назва</param>
        /// <param name="descr">Опис</param>
        /// <param name="place">Місце проведення</param>
        /// <param name="subscr_count">Кількість учасників</param>
        /// <param name="oaDate">Дата проведення</param>
        /// <param name="categories">Код категорій події</param>
        /// <param name="photos">Фотографії</param>
        public DataEventPreview(int id, string name, string descr, 
            string place, int subscr_count, double oaDate, 
            int categories, List<Bitmap> photos)
        {
            this.id = id;
            this.name = name;
            this.descr = descr;
            this.place = place;
            this.subscr_count = subscr_count;
            this.oaDate = oaDate;
            this.categories = categories;
            this.photos = photos;
        }

        /// <summary>
        /// Отримує код категорій в залежності від обраних та всіх можливих категорій
        /// </summary>
        /// <param name="categories">Обрані категорії</param>
        /// <param name="allCategories">Всі категорії</param>
        /// <returns></returns>
        public int getBitMask(string[] categories, string[] allCategories)
        {
            var sb = new StringBuilder(allCategories.Length);
            bool found;
            foreach (var anyC in allCategories)
            {
                found = false;
                foreach (var selC in categories)
                {
                    if (selC.Equals(anyC))
                    {
                        sb.Append("1");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    sb.Append("0");
                }
            }
            return Convert.ToInt32(sb.ToString(), 2);
        }

        /// <summary>
        /// Властивість - ідентифікатор
        /// </summary>
        public int EventID
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
        /// Властивість - назва
        /// </summary>
        public string EventName
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
        /// Властивість - опис
        /// </summary>
        public string Description
        {
            get
            {
                return descr;
            }

            set
            {
                descr = value;
            }
        }

        /// <summary>
        /// Властивість - місце проведення
        /// </summary>
        public string Place
        {
            get
            {
                return place;
            }

            set
            {
                place = value;
            }
        }

        /// <summary>
        /// Властивість - кількість учасників
        /// </summary>
        public int SubscribersCount
        {
            get
            {
                return subscr_count;
            }

            set
            {
                subscr_count = value;
            }
        }

        /// <summary>
        /// Властивість - дата проведення
        /// </summary>
        public double Date
        {
            get
            {
                return oaDate;
            }

            set
            {
                oaDate = value;
            }
        }

        /// <summary>
        /// Властивість - код категорій події
        /// </summary>
        public int Category
        {
            get
            {
                return categories;
            }

            set
            {
                categories = value;
            }
        }

        /// <summary>
        /// Властивість - фотографії
        /// </summary>
        public List<Bitmap> EventPictures
        {
            get
            {
                return photos;
            }

            set
            {
                photos = value;
            }
        }

        /// <summary>
        /// Отрмує текстове представлення об'єкту
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.GetType().ToString() + " [" + EventID + ", " + EventName +
                ", " + Description + ", " + Place + ", " + SubscribersCount + ", " +
                Date + ", " + Category + ", " + EventPictures.Count + " photos.]");
        }

    }
}
