using System;
using System.Linq;
using System.Windows;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FinalDeductionsWindow : Window
    {
        public FinalDeductionsWindow()
        {
            InitializeComponent();
            //homeloan alert
            lblHomeLoanAlert.Text = HomeLoanAlert(MainWindow.UserIncomeAmount, HomeLoan.homeAmount);
            dataFinalExpenses.ItemsSource = MainWindow.SendingList.OrderByDescending(x => x.Amount);
            //expenses alert 
            lblExpenseAlert.Text =  ExpenseAlert(MainWindow.TotalExpenses, Rentalwindow.CarAmount, HomeLoan.homeAmount, MainWindow.UserIncomeAmount, MainWindow.Tax);
        }

        private String HomeLoanAlert(double UserIncome, double HomeLoan)
        {
            double UserincomePercentage = (UserIncome * 75) / 100;
            String message;
            if (HomeLoan > UserincomePercentage)
            {
                message = "A homeloan is unlikely, 75% of your income is \n " + UserincomePercentage + " and your monthly home loan repayment will be \n" + HomeLoan + "Sorry, Sed life";
            }
            else { message = "A homeloan is likely, 75% of your income is \n " + UserincomePercentage + " and your monthly home loan repayment will be \n" + HomeLoan + " Nice Job"; }

            return message;
        }
        private String ExpenseAlert(double totalExpenses, double Car, double Homeamount, double UserIncome, double Tax)
        {
            double TaxdeductedIncome = UserIncome - Tax;
            double finalExpense = totalExpenses + Car + Homeamount;
            double leftOverAmount = TaxdeductedIncome - finalExpense;
            double precentageOfIncome = (TaxdeductedIncome * 75) / 100;
            String message2;
            if (finalExpense > (TaxdeductedIncome))
            {
                message2 = "Your buget is unstable, 75% of your Tax deducted Income is $" + precentageOfIncome + "\n and your expenses are finalized to $" + finalExpense + ".\n Make a few changes to your buget";

            }
            else
            {
                message2 = "Your buget is stable, 75% of your Tax deducted Income is $" + precentageOfIncome + "\n and your expenses are finalized to $" + finalExpense + ".\n Great!";
            }

            return message2;
        }
    }
}
