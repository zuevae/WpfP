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
        List<Агент> агент = new List<Агент>();
        public Agent(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            агент = Entities.GetContext().Агент.ToList();
            Gaz.ItemsSource = агент;
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            var poisk = Entities.GetContext().Агент.ToList();
            poisk = poisk.Where(p => p.Наименование_агента.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            Gaz.ItemsSource = poisk;
        }

        private void ComboType_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            //Update();
        }

        private void ComboType_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var currentService = Entities.GetContext().Service.ToList();
            //if (ComboType_Copy.SelectedIndex == 1)
            //{
            //    for (int i = 0; i < currentService.Count; i++)
            //    {
            //        if (currentService[i].price > 500)
            //        {
            //            currentService.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //}
            //currentService = currentService.Where(p => p.Наименование_агента.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            //LViewServ.ItemsSource = currentService.ToList();
        }
        private async void Gaz_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(100);
            object j = Gaz.SelectedItem;
            //frame1.Navigate(new update(frame1, j)); //при нажтии переход на другую страницу(update)
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new addAgent(frame1));
        }
    }
}
