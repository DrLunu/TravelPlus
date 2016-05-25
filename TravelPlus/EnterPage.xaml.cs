using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
    public delegate void RegistrationDelegate(RegistrationData data);
    public delegate void EnterDelegate(String[] data);

    public partial class EnterPage : UserControl
    {
        EnterPageEngine engine;

        private bool regIsDown = false;
        private Random r;

        public event RegistrationDelegate Registration;
        public event EnterDelegate Enter;

        public EnterPage()
        {
            InitializeComponent();

            engine = new EnterPageEngine();
            r = new Random();

            this.arrow.Visibility = System.Windows.Visibility.Hidden;
            this.labelForm.Foreground = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];
            
        }

        private void labelReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (regIsDown)
            {
                if (Registration != null)
                {
                    Registration(engine.RegistrationDeal(passwordTB1, passwordTB2, nameTB, surnameTB, 
                                                            dayTB, monthTB, yearTB, contactTB, cityTB, e_mailTB));
                }
            }
            else
            {
                engine.GridDown(upGrid);
                regIsDown = true;
                arrow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void enterButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Enter != null)
            {
                Enter(engine.EnterDeal(enterE_mailTB, enterPasswordTB));
            }
        }

        private void upButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (regIsDown)
            {
                engine.GridUp(upGrid);
                regIsDown = false;
                arrow.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void c_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Foreground = MyStaticData.fontPalette[r.Next(MyStaticData.fontPalette.Length)];
        }

        private void c_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 60, 60, 60));
        }

        private void c_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryTB.Text += engine.CategorySelect(sender);
        }

        private void clear_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!categoryTB.Text.Equals(""))
            {
                categoryTB.Text = categoryTB.Text.Replace(categoryTB.Text.Substring(categoryTB.Text.LastIndexOf("[")), "");
            }
        }

    }
}
