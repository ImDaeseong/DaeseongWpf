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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private int nLocation = 0;
        private bool bChange = true;
         
        public MainWindow()
        {
            InitializeComponent();

            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            this.ShowInTaskbar = false;

            ChangeBackImage();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MoveLocationDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

        private void ChangeBackImage(bool bWType = true)
        {
            if(bWType)
            {
                this.Height = 137;
                this.Width = 353;

                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Image/mobilebox_w.png"));
                this.Background = imgBrush;                
            }
            else
            {
                this.Height = 353;
                this.Width = 137;

                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Image/mobilebox_h.png"));
                this.Background = imgBrush;
            }

            MoveLocationButton(bWType);
        }

        private void MoveLocationButton(bool bWType = true)
        {
            if (bWType)
            {
                imageButton1.Margin = new Thickness(10, 22, 231, 34);
                imageButton2.Margin = new Thickness(119, 22, 122, 34);
                imageButton3.Margin = new Thickness(225, 22, 11, 34);
            }
            else
            {
                imageButton1.Margin = new Thickness(30, 25, 25, 247);
                imageButton2.Margin = new Thickness(33, 120, 22, 152);
                imageButton3.Margin = new Thickness(36, 214, 19, 58);
            }
        } 

        private void MoveLocationDialog()
        {  
            if (nLocation == 0)
            {
                this.Left = System.Windows.SystemParameters.WorkArea.Left + 5;
                this.Top = System.Windows.SystemParameters.WorkArea.Top + 5;
            }
            else if (nLocation == 1)
            {
                double dScreenWidth = System.Windows.SystemParameters.WorkArea.Width;
                double dWidht = (dScreenWidth - this.Width);
                this.Left = (dWidht / 2);
                this.Top = System.Windows.SystemParameters.WorkArea.Top + 5;
            }
            else if (nLocation == 2)
            {
                double dScreenHeight = System.Windows.SystemParameters.WorkArea.Height;
                this.Left = System.Windows.SystemParameters.WorkArea.Left + 5;
                this.Top = (dScreenHeight - this.Height - 5);
            }
            else if (nLocation == 3)
            {
                double dScreenWidth = System.Windows.SystemParameters.WorkArea.Width;
                double dWidht = (dScreenWidth - this.Width);
                double dScreenHeight = System.Windows.SystemParameters.WorkArea.Height;
                this.Left = (dWidht / 2);
                this.Top = (dScreenHeight - this.Height - 5);
            }
            else if (nLocation == 4)
            {
                double dScreenWidth = System.Windows.SystemParameters.WorkArea.Width;
                double dScreenHeight = System.Windows.SystemParameters.WorkArea.Height;
                this.Left = (dScreenWidth - this.Width - 5);
                this.Top = (dScreenHeight - this.Height - 5);
            }
            else
            {
                this.Left = System.Windows.SystemParameters.WorkArea.Left + 5;
                this.Top = System.Windows.SystemParameters.WorkArea.Top + 5;
            }
        }
        
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState != WindowState.Normal && WindowState != WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_DISPLAYCHANGE = 0x007e;
            if (msg == WM_DISPLAYCHANGE)
            {
                MoveLocationDialog();
            }
            return IntPtr.Zero;
        }

        private void RandomImage()
        {
            Random rand = new Random();
            nLocation = rand.Next(0, 5);

            if (bChange)
                bChange = false;
            else
                bChange = true;

            ChangeBackImage(bChange);
            MoveLocationDialog();
        }


        private void imageButton1_Click(object sender, RoutedEventArgs e)
        {
            RandomImage();
        }

        private void imageButton2_Click(object sender, RoutedEventArgs e)
        {
            RandomImage();
        }

        private void imageButton3_Click(object sender, RoutedEventArgs e)
        {
            RandomImage();
        }
    }
}
