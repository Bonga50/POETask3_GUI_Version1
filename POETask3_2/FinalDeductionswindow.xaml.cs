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
    public partial class FinalDeductionsWindow : Window
    {
        public FinalDeductionsWindow()
        {
            InitializeComponent();
            lblHomeLoanAlert.Text = HomeLoanAlert(MainWindow.UserIncomeAmount,HomeLoan.homeAmount);
            dataFinalExpenses.ItemsSource = MainWindow.SendingList.OrderByDescending(x => x.Amount);
        }

        private String HomeLoanAlert(double UserIncome,double HomeLoan) {
            double UserincomePercentage = (UserIncome * 75) / 100;
            String message;
            if (HomeLoan > UserincomePercentage)
            {
                message = "A homeloan is unlikely, 75% of your income is \n " + UserincomePercentage + " and your monthly home loan repayment will be \n" + HomeLoan + "Sorry, Sed life" ;
            }
            else { message = "A homeloan is likely, 75% of your income is \n " + UserincomePercentage + " and your monthly home loan repayment will be \n" + HomeLoan + " Nice Job"; }

            return message;
        }
    }
}
