using InvestStat.Context;
using InvestStat.model;
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

namespace InvestStat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CreateCompany _createCompany = new CreateCompany();
        WindowSWOT _WindowSWOT = new WindowSWOT();
        public MainWindow()
        {
            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            using (var cont = new CompanyContext())
            {
                var result = cont.Companies.ToList();
                if (result != null)
                {
                    listBox_companies.ItemsSource = result;
                }
            }
        }
        private void Button_CreateCompany_Click(object sender, RoutedEventArgs e)
        {
            if(!_createCompany.IsVisible)
                _createCompany.Show();

        }

        private void Button_DeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            if(listBox_companies.SelectedIndex != -1)
            {
                Company selectedCompany = (Company)listBox_companies.SelectedItem;
                using(var context=new CompanyContext())
                {
                    context.Companies.Remove(context.Companies.Find(selectedCompany.Id));
                    context.SaveChanges();
                }
                Refresh();
            }
        }

        private void Button_SWOTcompany_Click(object sender, RoutedEventArgs e)
        {
            if (!_WindowSWOT.IsVisible)
                _WindowSWOT.Show();
        }
    }
}
