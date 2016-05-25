using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Travel_GUI
{
    class MyStaticData
    {
        public static SolidColorBrush[] fontPalette = { Brushes.Coral, Brushes.DarkCyan, Brushes.IndianRed, Brushes.LightSeaGreen,
                                   Brushes.MediumSeaGreen, Brushes.SlateGray, Brushes.PaleTurquoise, 
                                   Brushes.Tomato, Brushes.RosyBrown, Brushes.PaleVioletRed, new SolidColorBrush(Color.FromArgb(255, 241, 73, 73))};

        public static SolidColorBrush[] roundPalette = {Brushes.AliceBlue, Brushes.AntiqueWhite, Brushes.BlanchedAlmond, Brushes.OldLace, Brushes.SeaShell,
                                       Brushes.Azure, Brushes.Cornsilk, Brushes.LemonChiffon, Brushes.MintCream, Brushes.Snow, Brushes.PapayaWhip};

        public static String[] Categories = { "Концерти і вистави", "Кіно", "Кафе і ресторани", "Подорожі", 
                                         "Музеї і вииставки", "Екстрим", "Пікніки і прогулянки", "Інше" };

        public static String IntToCategories(int category)
        {
            StringBuilder result = new StringBuilder();
            String c = Convert.ToString(category, 2);
            List<String> res = new List<string>();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[c.Length - 1 - i] == '1')
                {
                    res.Add("[" + MyStaticData.Categories[Categories.Length - 1 - i] + "] ");
                }
            }
            res.Reverse();
            foreach (var s in res)
            {
                result.Append(s);
            }
            return result.ToString();
        }

        public static void ColoredLabels(List<Control> elements, Random r)
        {
            foreach (var element in elements)
            {
                element.Foreground = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];
            }
        }
        
    }
}
