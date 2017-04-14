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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Window3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window3 : Window
    {
        static private DispatcherTimer dispatcherTimer;
        private Sprite mSprite;
        
        private void InitTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10); 
        }
        private void StartTimer()
        {
            dispatcherTimer.Start();
        }

        private void stopTimer()
        {
            dispatcherTimer.Stop();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //mSprite.Visible(true);
            mSprite.Move(100, 15);
        }

        public Window3()
        {
            InitializeComponent();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();

            InitTimer();

            stopTimer();
            StartTimer();
        }

        private void Init()
        {
            double dScreenWidth = System.Windows.SystemParameters.WorkArea.Width;
            double dScreenHeight = System.Windows.SystemParameters.WorkArea.Height;
            double dWidht = (dScreenWidth - this.Width);
            double dHeight = (dScreenHeight - this.Height);
            this.Left = (dWidht / 2);
            this.Top = (dHeight / 2);

            var img = new BitmapImage(new Uri("pack://application:,,,/Image/sprite.png"));
            mSprite = new Sprite(img);
            //mSprite.Visible(false);
            mSprite.Move(0, 10);
            canvas.Children.Remove(mSprite.Image);
            canvas.Children.Add(mSprite.Image);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

    }
}
