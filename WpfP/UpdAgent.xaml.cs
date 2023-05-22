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
using Path = System.IO.Path;

namespace WpfP
{
    /// <summary>
    /// Логика взаимодействия для UpdAgent.xaml
    /// </summary>
    public partial class UpdAgent : Page
    {
        public Frame frame1;
        public UpdAgent(Frame frame)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Agent( frame1));
        }
    }
}
