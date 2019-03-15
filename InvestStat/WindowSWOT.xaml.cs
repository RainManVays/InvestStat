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
    /// Логика взаимодействия для WindowSWOT.xaml
    /// </summary>
    public partial class WindowSWOT : Window
    {
        Company _Company;
        CompanySWOT _CompanySWOT;
        public WindowSWOT(Company company,CompanySWOT companySWOT)
        {
            _Company = company;
            _CompanySWOT = companySWOT;
            InitializeComponent();
            textBlock_CompanyName.Text = _Company.Name;
            AppendSWOTToListBox();
        }

        private void AppendSWOTToListBox()
        {
            //refact this eye pain
            if(_CompanySWOT != null)
            {
                if(_CompanySWOT.Strengths!=null)
                foreach (var item in _CompanySWOT.Strengths.Split(';'))
                        if (!string.IsNullOrWhiteSpace(item))
                            listBox_Strengths.Items.Add(item);
                if (_CompanySWOT.Opportunities != null)
                    foreach (var item in _CompanySWOT.Opportunities?.Split(';'))
                        if(!string.IsNullOrWhiteSpace(item))
                            listBox_Opportunities.Items.Add(item);
                if (_CompanySWOT.Threats != null)
                    foreach (var item in _CompanySWOT.Threats?.Split(';'))
                        if (!string.IsNullOrWhiteSpace(item))
                            listBox_Threats.Items.Add(item);
                if (_CompanySWOT.Weaknesses != null)
                    foreach (var item in _CompanySWOT.Weaknesses?.Split(';'))
                        if (!string.IsNullOrWhiteSpace(item))
                            listBox_Weaknesses.Items.Add(item);
            }
        }

        private void Button_addStrengths_Click(object sender, RoutedEventArgs e)
        {
            AppendTextToList(textBox_Strengths, listBox_Strengths);
        }

        private const int MAX_TEXT_ROW_LEN = 50;
        private void AppendTextToList(TextBox textBox, ListBox listBox)
        {
            string text = textBox.Text;
            text = text.Replace(';', ',');
            if (text.Length > MAX_TEXT_ROW_LEN)
            {
                int divideResult = text.Length / MAX_TEXT_ROW_LEN;
                for(int i= MAX_TEXT_ROW_LEN; i< MAX_TEXT_ROW_LEN * divideResult;i+= MAX_TEXT_ROW_LEN)
                    text = text.Insert(i, "\n");
            }

            if (text.Length > 1000)
            {
                MessageBox.Show("Text length is very long!");
            }
            if (!string.IsNullOrWhiteSpace(text))
            {
                listBox.Items.Add("-" + text);
            }
            textBox.Text = "";
        }
        private void DelListBoxPosition(ListBox listBox)
        {
            if(listBox.SelectedIndex != -1)
                listBox.Items.Remove(listBox.SelectedValue);
        }

        private void Button_delStrengths_Click(object sender, RoutedEventArgs e)
        {
            DelListBoxPosition(listBox_Strengths);
        }

        private void Button_addWeaknesses_Click(object sender, RoutedEventArgs e)
        {
            AppendTextToList(textBox_Weaknesses, listBox_Weaknesses);
        }

        private void Button_delWeaknesses_Click(object sender, RoutedEventArgs e)
        {
            DelListBoxPosition(listBox_Weaknesses);
        }

        private void Button_addOpportunities_Click(object sender, RoutedEventArgs e)
        {
            AppendTextToList(textBox_Opportunities, listBox_Opportunities);
        }

        private void Button_delOpportunities_Click(object sender, RoutedEventArgs e)
        {
            DelListBoxPosition(listBox_Opportunities);
        }

        private void Button_addThreats_Click(object sender, RoutedEventArgs e)
        {
            AppendTextToList(textBox_Threats, listBox_Threats);
        }

        private void Button_delThreats_Click(object sender, RoutedEventArgs e)
        {
            DelListBoxPosition(listBox_Threats);
        }
        private CompanySWOT ConvertSwotListsToStrings(int companyId,ItemCollection strengths,ItemCollection opportunities,ItemCollection weaknesses,ItemCollection threats)
        {
            var company = new CompanySWOT();
            company.CompanyId = companyId;
            foreach (var item in strengths)
                company.Strengths += item + ";";
            foreach (var item in opportunities)
                company.Opportunities += item + ";";
            foreach (var item in weaknesses)
                company.Weaknesses += item + ";";
            foreach (var item in threats)
                company.Threats += item + ";";
            return company;
        }
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new CompanySWOTContext()){
               var result= context.CompanySWOT.FirstOrDefault(x => x.CompanyId == _Company.Id);
                var swot = ConvertSwotListsToStrings(_Company.Id, listBox_Strengths.Items, listBox_Opportunities.Items, listBox_Weaknesses.Items, listBox_Threats.Items);
                if (result == null)
                {
                    context.CompanySWOT.Add(swot);
                }
                if (result != null)
                {
                    result.Strengths = swot.Strengths;
                    result.Opportunities = swot.Opportunities;
                    result.Threats = swot.Threats;
                    result.Weaknesses = swot.Weaknesses;
                }
                context.SaveChanges();
            }
            this.Close();
        }
    }
}
