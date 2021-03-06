﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Travel_GUI
{
    public abstract class UserPageEngine
    {
        protected DataUserPage data;
        protected Random r;
        public MiniEventIcon[] events;

        public UserPageEngine(DataUserPage data)
        {
            this.data = data;

            r = new Random();
            
        }

        public MiniEventIcon[] MakeMiniEventIcons()
        {
            events = new MiniEventIcon[data.Events.Count];
            for (int i = 0; i < data.Events.Count; i++)
            {
                events[i] = new MiniEventIcon(data.Events[i], data.EventPictures[i]);
            }
            return events;
        }

        public virtual void UserIconSet(Grid grid, Control icon)
        {
            Thickness iconPosition = new Thickness(10, 10, 10, 10);
            icon.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            icon.Margin = iconPosition;
            grid.Children.Add(icon);
        }

        public virtual void FillByData(Label nameLabel, Label contentDate, Label contentCity, TextBlock contentCategorys)
        {
            contentDate.Content = DateTime.FromOADate(data.Date).ToShortDateString();
            contentCity.Content = data.City;
            contentCategorys.Text = MyStaticData.IntToCategories(data.Categories);
            nameLabel.Content = data.Name;
        }

        public void CreateEventlist(StackPanel panel)
        {
            for (int i = 0; i < events.Length; i++)
            {
                panel.Children.Add(events[i]);
            }
        }
    }
}
