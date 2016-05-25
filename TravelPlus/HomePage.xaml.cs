using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_GUI
{

    public partial class HomePage : UserControl
    {
        HomePageEngine engine;

        public HomePage(DataUserPage data)
        {
            InitializeComponent();

            engine = new HomePageEngine(data);

            engine.UserIconSet(grid, new Control());
            engine.CreateFriendlist(this.friendPanel);
            engine.CreateEventlist(this.eventPanel);
            engine.FillByData(nameLabel, contentDate, contentCity, contentCategorys);

            List<Control> labels = new List<Control>();
            labels.Add(nameLabel);
            labels.Add(dateLabel);
            labels.Add(cityLabel);
            labels.Add(categoryLabel);
            labels.Add(friendLabel);
            labels.Add(eventLabel);
            MyStaticData.ColoredLabels(labels, new Random());
            
        }
        
    }
}
