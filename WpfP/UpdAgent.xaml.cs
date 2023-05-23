using Aspose.BarCode.Generation;
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
        object Item;
        Agent thisAgent;
        List<Агент> агент = new List<Агент>();
        List<Газеты> газеты = new List<Газеты>();
        string Log;
        public UpdAgent(string log, Frame frame, Agent агент)
        {
            InitializeComponent();
            DataContext = this;
            frame1 = frame;
            thisAgent = agent;
            Log = log;
            агент = Entities.GetContext().Агент.ToList();

            for (int i = 0; i < агент.Count; i++)
            {
                if (агент[i].agent == thisAgent.agent)
                {
                    id_tipA.Text = агент[i].Тип_агента.ToString();
                    nameA.Text = агент[i].Наименование_агента.ToString();
                    pochtaA.Text = агент[i].Электронная_почта_агента.ToString();
                    telA.Text = агент[i].Телефон_агента.ToString();
                    adressA.Text = агент[i].Юридический_адрес.ToString();
                    DA.Text = агент[i].Директор.ToString();
                    dataUpd.Text = газеты[i].data.ToString();
                    KPPA.Text = агент[i].КПП.ToString();
                    INNA.Text = агент[i].ИНН.ToString();
                    break;
                }
            }
        }
        private void Result_Delete(object sender, RoutedEventArgs e)
        {
            List<Агент> агент = new List<Агент> { };
            агент = Entities.GetContext().Агент.ToList();
            try
            {
                for (int i = 0; i < агент.Count; i++)
                {
                    if (агент[i].agent == Item.GetType().GetProperty("agent1").GetValue(Item))
                    {
                        Entities.GetContext().Агент.Remove(агент[i]);
                        Entities.GetContext().SaveChanges();
                        break;
                    }
                }
                frame1.Navigate(new Agent(Log, frame1, Item));
            }
            catch
            {
                MessageBox.Show("Вы не можете удалить данного агента, пока не будет удален результат");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
            {
                frame1.Navigate(new Agent(frame1));
            }
            private void UpdData_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                List<Агент> List_Agents = new List<Агент>();
                List<Газеты> List_Gazet = new List<Газеты>();
            int id_t;
            char n;
            char p;
            char tel;
            DateTime d;
            char ad;
            char da;
            char k;
            char inn;
            int count = Entities.GetContext().Агент.Count();
                List_Agents = Entities.GetContext().Агент.ToList();

                // List_Results[0].id = count + 1;
                if (int.TryParse(id_tipA.Text, out id_t))
                {
                    if (int.TryParse(nameA.Text, out n))
                    {
                        if (int.TryParse(pochtaA.Text, out p))
                        {
                            if (char.TryParse(telA.Text, out tel))
                            {
                                if (char.TryParse(adressA.Text, out ad))
                                {
                                    if (char.TryParse(DA.Text, out da))
                                    {
                                        if (char.TryParse(KPPA.Text, out k))
                                        {
                                            if (char.TryParse(INNA.Text, out inn))
                                            {
                                                if (DateTime.TryParse(dataUpd.Text, out d))
                                                {
                                                    List_Agents[0].Тип_агента = id_t;
                                                    List_Agents[0].Наименование_агента = n.ToString();
                                                    List_Agents[0].Электронная_почта_агента = p.ToString();
                                                    List_Agents[0].Телефон_агента = tel.ToString();
                                                    List_Gazet[0].Дата_реализации = d;
                                                    List_Agents[0].Юридический_адрес = ad.ToString();
                                                    List_Agents[0].Директор = da.ToString();
                                                    List_Agents[0].КПП = k;
                                                    List_Agents[0].ИНН = inn;
                                                    Entities.GetContext().SaveChanges();
                                                    frame1.Navigate(new Agent(Log, frame1, Item));
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Неверно введёна дата");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Неверно введён ИНН");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Неверно введён КПП");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Неверно введён Директор");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверно введён адрес");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверно введён телефон агента");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введёна электронная почта");
                    }

                }
                else
                {
                    MessageBox.Show("Неверно введёно наименование агента");
                }
            }
        
    } 
}
