﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Travel_GUI
{
    class HomePageEngine : UserPageEngine
    {
        private DataUserPage data;
        private Random r;

        public HomePageEngine(DataUserPage data) : base(data) { }

        public override void UserIconSet(Grid grid, Control icon)
        {
            icon = new UserIcon(data.Name, data.Surname, r);
            base.UserIconSet(grid, icon);
            icon.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        }

        public override void FillByData(Label nameLabel, Label contentDate, Label contentCity, TextBlock contentCategorys)
        {
            base.FillByData(nameLabel, contentDate, contentCity, contentCategorys);
            nameLabel.Content += " " + data.Surname;
        }
        
        public MiniUserIcon[] MakeMiniUserIcons()
        {
            MiniUserIcon[] result = new MiniUserIcon[data.Friends.Count];
            for (int i = 0; i < data.Friends.Count; i++)
            {
                result[i] = new MiniUserIcon(data.Friends[i], r);
            }
            return result;
        }
        
        public void CreateFriendlist(StackPanel panel)
        {
            MiniUserIcon[] friends = this.MakeMiniUserIcons();
            for (int i = 0; i < friends.Length; i++)
            {
                panel.Children.Add(friends[i]);
            }
        }
    }
}
