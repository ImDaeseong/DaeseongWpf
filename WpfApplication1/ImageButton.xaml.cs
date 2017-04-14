using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// ImageButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageButton : Button
    {
        public static readonly DependencyProperty DefaultProperty = DependencyProperty.Register("DefaultImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, new PropertyChangedCallback(DefaultCallback)));
        public static readonly DependencyProperty OverProperty = DependencyProperty.Register("OverImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, new PropertyChangedCallback(OverCallback)));
        public static readonly DependencyProperty PressProperty = DependencyProperty.Register("PressImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, new PropertyChangedCallback(PressCallback)));
        public static readonly DependencyProperty DisableProperty = DependencyProperty.Register("DisableImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, new PropertyChangedCallback(DisableCallback)));

       
        public ImageSource DefaultImageSource
        {
            get
            {
                return this.GetValue(DefaultProperty) as ImageSource;
            }
            set
            {
                this.SetValue(DefaultProperty, value);
            }
        }
        
        private static void DefaultCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageButton)
            {
                ImageButton imgbutton = sender as ImageButton;
                imgbutton.OnDefaultChanged(e.OldValue, e.NewValue);
            }
        }

        protected void OnDefaultChanged(object oldValue, object newValue)
        {           
           this.DefaultImageSource = newValue as ImageSource;
        }




        public ImageSource OverImageSource
        {
            get
            {
                return this.GetValue(OverProperty) as ImageSource;
            }
            set
            {
                this.SetValue(OverProperty, value);
            }
        }
        
        private static void OverCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageButton)
            {
                ImageButton imgbutton = sender as ImageButton;
                imgbutton.OnOverChanged(e.OldValue, e.NewValue);
            }
        }

        protected void OnOverChanged(object oldValue, object newValue)
        {
            this.OverImageSource = newValue as ImageSource;
        }




        public ImageSource PressImageSource
        {
            get
            {
                return this.GetValue(PressProperty) as ImageSource;
            }
            set
            {
                this.SetValue(PressProperty, value);
            }
        }

        private static void PressCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageButton)
            {
                ImageButton imgbutton = sender as ImageButton;
                imgbutton.OnPressChanged(e.OldValue, e.NewValue);
            }
        }

        protected void OnPressChanged(object oldValue, object newValue)
        {
            this.PressImageSource = newValue as ImageSource;
        }



        public ImageSource DisableImageSource
        {
            get
            {
                return this.GetValue(DisableProperty) as ImageSource;
            }
            set
            {
                this.SetValue(DisableProperty, value);
            }
        }

        private static void DisableCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageButton)
            {
                ImageButton imgbutton = sender as ImageButton;
                imgbutton.OnDisableChanged(e.OldValue, e.NewValue);
            }
        }

        protected void OnDisableChanged(object oldValue, object newValue)
        {
            this.DisableImageSource = newValue as ImageSource;
        }



        public ImageButton()
        {
            InitializeComponent();
        }
    }
}
