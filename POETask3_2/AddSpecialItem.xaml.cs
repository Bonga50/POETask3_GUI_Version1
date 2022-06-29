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

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddSpecialItem : Window
    {
        public static double SpecialItemMonthly;
        public static String SpecialItemName;
        public AddSpecialItem()
        {
            InitializeComponent();
            lblError.Visibility = Visibility.Collapsed;
            btnAddItemToList.Visibility = Visibility.Collapsed;
        }
        bool isValid;
        double FullAmount;
        double Deposit;
        double InterestRate;
        double time;
        private void btnNewItemCalculate_Click(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Collapsed;
            
            try
            {
                 FullAmount = double.Parse(txtNewItemAmount.Text);
                 Deposit = double.Parse(txtNewItemDeposit.Text);
                 InterestRate = double.Parse(txtItemInterestRate.Text);
                 time = double.Parse(txtAmountMonths.Text);
                
                isValid = true;
            }
            catch (Exception)
            {
                isValid = false;
                lblError.Visibility = Visibility.Visible;
            }

            if (isValid == true)
            {

                lblError.Visibility = Visibility.Collapsed;
                btnNewItemCalculate.Visibility = Visibility.Collapsed;
                btnAddItemToList.Visibility = Visibility.Visible;
                HomeLoanCalculation calcObj = new HomeLoanCalculation();
                SpecialItemMonthly = calcObj.calculateCost(FullAmount, Deposit, InterestRate, time);

                SpecialItemName = txtNewItemName.Text;

              

                
            }
        }

        private void btnAddItemToList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SendingList.Add(new Expensedata
            {
                Expense = SpecialItemName,
                Amount = SpecialItemMonthly

            });

            FinalDeductionsWindow FinObj = new FinalDeductionsWindow();
            this.Hide();
            FinObj.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            FinalDeductionsWindow FinObj = new FinalDeductionsWindow();
            this.Hide();
            FinObj.Show();

        }
    }
}
