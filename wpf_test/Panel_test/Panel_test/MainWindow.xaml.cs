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

namespace Panel_test
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_Click(object sender, RoutedEventArgs e)
        {
            Canvas window = new Canvas();
            window.Show();
        }

        private void DockPanel_Click(object sender, RoutedEventArgs e)
        {
            DockPanel window = new DockPanel();
            window.Show();            
        }

        private void Expander_Click(object sender, RoutedEventArgs e)
        {
            Expander window = new Expander();
            window.Show();
        }
        private void GridSplitter_Click(object sender, RoutedEventArgs e)
        {
            GridSplitter window = new GridSplitter();
            window.Show();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            StackPanel window = new StackPanel();
            window.Show();
        }

        private void UniformGrid_Click(object sender, RoutedEventArgs e)
        {
            UniformGrid window = new UniformGrid();
            window.Show();
        }

        private void WrapPanel_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel window = new WrapPanel();
            window.Show();
        }

        private void TabControl_Click(object sender, RoutedEventArgs e)
        {
            TabControl window = new TabControl();
            window.Show();
        }
    }
}
