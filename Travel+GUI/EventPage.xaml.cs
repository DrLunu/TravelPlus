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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_GUI
{

    public partial class EventPage : UserControl
    {
        public EventPageEngine engine;
        MainWindow mainWindow;
        int index;

        public EventPage(EventPreview preview, MainWindow mainWindow, List<Bitmap> photos, List<DataMini> subscribersList, bool reg)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            EventAnimation(true);
            engine = new EventPageEngine(preview, photos, subscribersList, this);

            if (!reg)
            {
                joinButton.Visibility = Visibility.Hidden;
                friendLabel.Visibility = Visibility.Hidden;
                scrollViewer.Visibility = Visibility.Hidden;
                bord.Visibility = Visibility.Hidden;
            }
            else
            {
                engine.MakeSubscribersList(subscribersPanel);
            }

            engine.FillByPhotos(mainPhotoPlace, miniPhotoPlace1, miniPhotoPlace2, miniPhotoPlace3);
            engine.FillByData(contentCategory, LabelEventName, contentPlace, number, contentDescription, dateLabel);

            List<Control> labels = new List<Control>();
            labels.Add(friendLabel);
            labels.Add(LabelCategory);
            labels.Add(LabelDescription);
            labels.Add(LabelPlace);
            MyStaticData.ColoredLabels(labels, new Random());
        }   

        private void miniPhotoPlace_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            index = engine.NextPhoto(index, mainPhotoPlace, miniPhotoPlace1, miniPhotoPlace2, miniPhotoPlace3);
        }

        private void ExitButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EventAnimation(false);
            ((Grid)this.Parent).Children.Remove(this);
        }

        private void JoinButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((Control)sender).ToolTip = (Object)"Перехід до реалізації функціоналу користувача учасника.";
        }

        private void EventAnimation(Boolean down)
        {
            Thickness from = new Thickness();
            from.Bottom = this.Height;
            Thickness to = new Thickness();
            to.Bottom = 0;
            ThicknessAnimation eventAnimation = new ThicknessAnimation();
            eventAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));

            if (down)
            {
                eventAnimation.From = from;
                eventAnimation.To = to;
            }
            else
            {
                eventAnimation.From = to;
                eventAnimation.To = from;
            }

            this.BeginAnimation(MarginProperty, eventAnimation);
        }

    }
}
