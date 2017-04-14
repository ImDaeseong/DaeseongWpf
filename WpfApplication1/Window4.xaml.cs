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

namespace WpfApplication1
{
    /// <summary>
    /// Window4.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double dScreenWidth = System.Windows.SystemParameters.WorkArea.Width;
            double dScreenHeight = System.Windows.SystemParameters.WorkArea.Height;
            double dWidht = (dScreenWidth - this.Width);
            double dHeight = (dScreenHeight - this.Height);
            this.Left = (dWidht / 2);
            this.Top = (dHeight / 2);
        }
        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

        private void skinButton1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("skinButton1_Click");
        }
        private void skinButton2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("skinButton2_Click");
        }
        private void skinButton3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("skinButton3_Click");
        }
    }
}
