using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FinalDeductionsWindow : Window
    {
        //delegate
        public delegate String CheckProbability(double finalExpenses, double MonthlyGross, double MonthlyGrossPrecentage);//[7](C# | Delegates - GeeksforGeeks, 2022)
        //delegte object
        CheckProbability OBJ1 = new CheckProbability(RepaymentStatus);

        public static double TaxdeductedIncome = MainWindow.UserIncomeAmount - MainWindow.Tax;
        public static double finalExpense = MainWindow.TotalExpenses + Rentalwindow.CarAmount + HomeLoan.homeAmount + MainWindow.Tax;
        public static double leftOverAmount = MainWindow.UserIncomeAmount - finalExpense;
        public static double precentageOfIncome = (MainWindow.UserIncomeAmount * 75) / 100;

         ObservableCollection <Expensedata> FinalUserIncomeDetails = new ObservableCollection<Expensedata>();

        public FinalDeductionsWindow()
        {
           
            InitializeComponent();
            //populate list          
            userIncomeDetails();

            MessageBox.Show(FinalUserIncomeDetails.Count().ToString());
            //homeloan alert
            lblHomeLoanAlert.Text = HomeLoanAlert(MainWindow.UserIncomeAmount, HomeLoan.homeAmount);
            dataFinalExpenses.ItemsSource = MainWindow.SendingList.OrderByDescending(x => x.Amount);
            //expenses alert 
            lblExpenseAlert.Text = OBJ1(finalExpense, MainWindow.UserIncomeAmount,precentageOfIncome);
            dataUserIncomeDetails.ItemsSource = FinalUserIncomeDetails;
            
        }

        private String HomeLoanAlert(double UserIncome, double HomeLoan)
        {
            double UserincomePercentage = (UserIncome * 75) / 100;
            String message;
            if (HomeLoan > UserincomePercentage)
            {
                message = "A homeloan is unlikely, 75% of your income is \n " + UserincomePercentage + " and your monthly home loan repayment will be \n" + HomeLoan + "  Sorry, Sed life";
                
            }
            else { message = "A homeloan is likely, 75% of your income is \n " + UserincomePercentage + " and your monthly home loan repayment will be \n" + HomeLoan + "  Nice Job"; }

            return message;
        }

        private void btnAddSpecialItem_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialItem SpecialObj = new AddSpecialItem();
            SpecialObj.Show();
            this.Hide();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBacktoMain_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure, (This will discard all data and you will start again" +
              ")", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Collapsed;
                mainWindow.Visibility = Visibility.Visible;
            }


        }
        //This method adds the final results calculations
        //It will add Tax deducted Income
        //Final expenses inclucing tax
        //The Amount left over after necesary tax deductions have been made
        private void userIncomeDetails() {
            FinalUserIncomeDetails = MainWindow.SendingUserIncome;
            //will add these only when list size is less than 6 
            if (FinalUserIncomeDetails.Count() < 6)
            {
                FinalUserIncomeDetails.Add(new Expensedata()
                {
                    Expense = "Tax deducted Income",
                    Amount = TaxdeductedIncome
                });
                FinalUserIncomeDetails.Add(new Expensedata()
                {
                    Expense = "Final Total Expenses(with tax)",
                    Amount = finalExpense
                });
                FinalUserIncomeDetails.Add(new Expensedata()
                {
                    Expense = "Amount left after expenses deducted",
                    Amount = leftOverAmount
                });
            }
        }
        //delegate method for altering the user if the expenses are to high
        public static  String RepaymentStatus(double finalExpense, double fulluserIncome, double MonthlyGrossPrecentage)
        {
            String message2;


            if (finalExpense > MonthlyGrossPrecentage)
            {
                message2 =
                  "Your buget is unstable, 75 % of your Tax deducted Income is $"
                   + MonthlyGrossPrecentage + "\n and your expenses are finalized to $" +
                          finalExpense + ".\n Make a few changes to your buget";
                
            }
            else
            {
                message2 = "Your buget is stable, 75% of your Tax deducted Income is $" + MonthlyGrossPrecentage +
                 "\n and your expenses are finalized to $" + finalExpense + ".\n Great!";
            }
            return message2;

        }
    }
}
