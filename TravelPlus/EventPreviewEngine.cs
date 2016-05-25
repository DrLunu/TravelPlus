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
    public class EventPreviewEngine
    {
        private DataEventPreview data;
        private Random r;
        public int eventID;

        public EventPreviewEngine(DataEventPreview data)
        {
            this.data = data;
            r = new Random();
            this.eventID = data.EventID;
        }

        public void FillByData(Label LabelEventName, Label contentCategory, Label contentPlace, 
                                TextBlock contentDescription, Label number, Label dateLabel)
        {
            //try
            //{
                LabelEventName.Content = data.EventName;
                contentCategory.Content = MyStaticData.IntToCategories(data.Category);
                contentPlace.Content = data.Place;
                contentDescription.Text = data.Description;
                number.Content = data.SubscribersCount;
                dateLabel.Content = DateTime.FromOADate(data.Date).ToString();
            //}
            //catch (Exception)
            //{
            //}
        }

        public void FillByColor(Ellipse PhotoPlace)
        {
            PhotoPlace.Fill = new LinearGradientBrush((MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)]).Color, Colors.White, 90);
        }

        public void FillByPhotos(Ellipse FullSizePhotoPlace, Ellipse MiniPhoto1, Ellipse MiniPhoto2,
                                    Ellipse MiniPhoto3, Ellipse MiniPhoto4)
        {
            try
            {
                FullSizePhotoPlace.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[0]));
                MiniPhoto1.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[1]));
                MiniPhoto2.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[2]));
                MiniPhoto3.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[3]));
                MiniPhoto4.Fill = new ImageBrush(MainWindow.CreateBitmapSourceFromGdiBitmap(data.EventPictures[4]));

                ((ImageBrush)FullSizePhotoPlace.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto1.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto2.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto3.Fill).Stretch = Stretch.UniformToFill;
                ((ImageBrush)MiniPhoto4.Fill).Stretch = Stretch.UniformToFill;
            }
            catch (Exception)
            {
            }
        }

        public void PhotoShift(Object sender, Ellipse FullSizePhotoPlace)
        {
            if (((Ellipse)sender).Fill is ImageBrush)
            {
                System.Windows.Media.Brush photoBrush = FullSizePhotoPlace.Fill;
                FullSizePhotoPlace.Fill = ((Ellipse)sender).Fill;
                ((Ellipse)sender).Fill = photoBrush;
            }
        }
    }
}
