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
using System.Windows.Shapes;

namespace InvestStat
{
    /// <summary>
    /// Логика взаимодействия для CreateCompany.xaml
    /// </summary>
    public partial class CreateCompany : Window
    {
        public CreateCompany()
        {
            InitializeComponent();
            comboBox_Industries.ItemsSource = Enum.GetNames(typeof(Industry));
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateArgs())
            {
                var baseDate = calendar_baseDate.SelectedDate.HasValue ? calendar_baseDate.SelectedDate.Value.ToShortDateString() : calendar_baseDate.DisplayDate.ToShortDateString();
                SaveCompanyInformation(textBox_CompanyName.Text, textBox_CompanyShortName.Text, baseDate, comboBox_Industries.SelectedItem.ToString());
                this.Close();
            }
        }

        private bool ValidateArgs()
        {
            if (ValidateField("Company name", textBox_CompanyName))
                if (ValidateField("Company short name", textBox_CompanyShortName))
                    if (ValidateField("Industry", comboBox_Industries))
                        return true;
            return false;
        }
        private bool ValidateField(string fieldName,Control fieldBox)
        {
            if(fieldBox is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show(fieldName+" is empty!");
                    fieldBox.BorderBrush = Brushes.Red;
                    return false;
                }
            }
            if (fieldBox is ComboBox comboBox)
            {
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Need selecting "+ fieldName);
                    fieldBox.BorderBrush = Brushes.Red;
                    return false;
                }
            }
            fieldBox.BorderBrush = new SolidColorBrush(Colors.Black) { Opacity = 0.54 };
            return true;
        }
        private void SaveCompanyInformation(string companyName,string companyShortName,string baseDate,string industry)
        {
            using(CompanyContext context = new CompanyContext())
            {
                int id = 0;
                var result=context.Companies.FirstOrDefault();
                if (result != null)
                {
                    id = context.Companies.Max(x => x.Id);
                    ++id;
                }
                    
                
                context.Companies.Add(new Company
                {
                    Id=id,
                    Name = companyName,
                    ShortName = companyShortName,
                    BaseDate = baseDate,
                    Industry = (Industry)Enum.Parse(typeof(Industry), industry)
                });
                
                context.SaveChanges();
            }
        }

    }
}
