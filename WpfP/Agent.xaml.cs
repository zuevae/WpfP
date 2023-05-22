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

namespace WpfP
{
    /// <summary>
    /// Логика взаимодействия для Agent.xaml
    /// </summary>
    public partial class Agent : Page
    {
        public Frame frame1;
        public Agent(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboType_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboType_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
