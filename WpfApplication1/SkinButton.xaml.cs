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
    /// SkinButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SkinButton : Button
    {
        public static readonly DependencyProperty SkinProperty =
            DependencyProperty.Register(" SkinImage", typeof(string), typeof(SkinButton), new PropertyMetadata(new PropertyChangedCallback(OnSkinButtonChanged)));

        public static readonly DependencyProperty DefaultProperty =  DependencyProperty.Register("DefaultImage", typeof(CroppedBitmap), typeof(SkinButton));
        public static readonly DependencyProperty OverProperty =  DependencyProperty.Register("OverImage", typeof(CroppedBitmap), typeof(SkinButton));
        public static readonly DependencyProperty PressProperty = DependencyProperty.Register("PressImage", typeof(CroppedBitmap), typeof(SkinButton));
        public static readonly DependencyProperty DisableProperty = DependencyProperty.Register("DisableImage", typeof(CroppedBitmap), typeof(SkinButton));

        
        public string SkinImage
        {
            get { return (string)GetValue(SkinProperty); }
            set { SetValue(SkinProperty, value); }
        }

        public CroppedBitmap DefaultImage
        {
            get { return (CroppedBitmap)GetValue(DefaultProperty); }
            set { SetValue(DefaultProperty, value); }
        }

        public CroppedBitmap OverImage
        {
            get { return (CroppedBitmap)GetValue(OverProperty); }
            set { SetValue(OverProperty, value); }
        }

        public CroppedBitmap PressImage
        {
            get { return (CroppedBitmap)GetValue(PressProperty); }
            set { SetValue(PressProperty, value); }
        }

        public CroppedBitmap DisableImage
        {
            get { return (CroppedBitmap)GetValue(DisableProperty); }
            set { SetValue(DisableProperty, value); }
        }
        

        public static void OnSkinButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SkinButton btnSkin = d as SkinButton;

            var img = new BitmapImage(new Uri(e.NewValue as string, UriKind.RelativeOrAbsolute)) { BaseUri = BaseUriHelper.GetBaseUri(btnSkin) };
            var frame = BitmapFrame.Create(img);

            btnSkin.DefaultImage = new CroppedBitmap(img, new Int32Rect(0, 0, (int)frame.PixelWidth / 4, (int)frame.PixelHeight));
            btnSkin.OverImage = new CroppedBitmap(img, new Int32Rect((int)frame.PixelWidth / 4, 0, (int)frame.PixelWidth / 4, (int)frame.PixelHeight));
            btnSkin.PressImage = new CroppedBitmap(img, new Int32Rect((int)frame.PixelWidth / 4 * 2, 0, (int)frame.PixelWidth / 4, (int)frame.PixelHeight));
            btnSkin.DisableImage = new CroppedBitmap(img, new Int32Rect((int)frame.PixelWidth / 4 * 3, 0, (int)frame.PixelWidth / 4, (int)frame.PixelHeight));
       }             
        
        public SkinButton()
        {
            InitializeComponent();
        }
    }
}
