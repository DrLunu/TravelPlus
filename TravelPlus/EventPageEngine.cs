using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Travel_GUI
{
    class EventPageEngine
    {
        private int index;
        private Random r;
        private EventPreview preview;
        private List<Bitmap> photos;
        private List<DataMini> subscribersList;
        private int categories;
        
        public EventPageEngine(EventPreview preview, List<Bitmap> photos, List<DataMini> subscribersList)
        {
            this.r = new Random();

            this.preview = preview;
            this.photos = new List<Bitmap>(photos);
            this.subscribersList = new List<DataMini>(subscribersList);
            this.categories = preview.data.Category;
            
        }

        public void FillByData(Label contentCategory, Label LabelEventName, Label contentPlace, Label number,
                                    TextBlock contentDescription, Label dateLabel)
        {
            try
            {
                contentCategory.Content = MyStaticData.IntToCategories(categories);
                LabelEventName.Content = preview.data.EventName.Clone();
                contentPlace.Content = preview.data.Place;
                contentDescription.Text = (String)preview.data.Description.Clone();
                number.Content = preview.data.SubscribersCount;
                dateLabel.Content = DateTime.FromOADate(preview.data.Date).ToString();
            }
            catch(Exception) { }
        }
        

        private MiniUserIcon[] MakeMiniUserIcons(List<DataMini> friendList)
        {
            MiniUserIcon[] result = new MiniUserIcon[friendList.Count];
            for (int i = 0; i < friendList.Count; i++)
            {
                result[i] = new MiniUserIcon(subscribersList[i], r);
            }
            return result;
        }

        public void MakeSubscribersList(StackPanel subscribersPanel)
        {
            MiniUserIcon[] friends = this.MakeMiniUserIcons(subscribersList);
            for (int i = 0; i < friends.Length; i++)
            {
                subscribersPanel.Children.Add(friends[i]);
            }
        }

        public void FillByPhotos(Ellipse mainPhotoPlace, Ellipse miniPhotoPlace1, Ellipse miniPhotoPlace2, Ellipse miniPhotoPlace3)
        {
            try
            {
                mainPhotoPlace.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[0]));
                miniPhotoPlace1.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[1]));
                miniPhotoPlace2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[2]));
                if (photos.Count >= 4)
                {
                    miniPhotoPlace3.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[photos.Count - 1]));
                }
            }
            catch (Exception) { }
        }

        public int NextPhoto(int i, Ellipse mainPhotoPlace, Ellipse miniPhotoPlace1, Ellipse miniPhotoPlace2, Ellipse miniPhotoPlace3)
        {
            if (i + 3 != this.photos.Count)
            {
                miniPhotoPlace3.Fill = mainPhotoPlace.Fill;
                mainPhotoPlace.Fill = miniPhotoPlace1.Fill;
                miniPhotoPlace1.Fill = miniPhotoPlace2.Fill;
                miniPhotoPlace2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[i + 3]));
            }
            else
            {
                if (i + 2 != this.photos.Count)
                {
                    if (i + 1 != this.photos.Count)
                    {
                        i = -3;
                        miniPhotoPlace3.Fill = mainPhotoPlace.Fill;
                        mainPhotoPlace.Fill = miniPhotoPlace1.Fill;
                        miniPhotoPlace1.Fill = miniPhotoPlace2.Fill;
                        miniPhotoPlace2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[i + 3]));
                    }
                    else
                    {
                        i = -2;
                        miniPhotoPlace3.Fill = mainPhotoPlace.Fill;
                        mainPhotoPlace.Fill = miniPhotoPlace1.Fill;
                        miniPhotoPlace1.Fill = miniPhotoPlace2.Fill;
                        miniPhotoPlace2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[i + 3]));
                    }
                }
                else
                {
                    i = -1;
                    miniPhotoPlace3.Fill = mainPhotoPlace.Fill;
                    mainPhotoPlace.Fill = miniPhotoPlace1.Fill;
                    miniPhotoPlace1.Fill = miniPhotoPlace2.Fill;
                    miniPhotoPlace2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(photos[i + 3]));
                }
            }
            i++;
            return i;
        }
    }
}
