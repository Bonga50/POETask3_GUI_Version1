using System;
using System.Windows;
using System.Windows.Controls;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for HomeLoan.xaml
    /// </summary>
    public partial class HomeLoan : Window
    {
        //buy or rent choice
        int choice;
        //will hold value of home loan or renting
        double homeAmount;
        public HomeLoan()
        {
            InitializeComponent();
            //will appear when an error is caught
            lblError.Visibility = Visibility.Collapsed;
            btnHomeloanCalc.Visibility = Visibility.Collapsed;
            invisableBuy();
            invisableRental();
            btnNext3.Visibility = Visibility.Collapsed;
        }

        private void cmbBuyHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBuyHome.SelectedIndex.Equals(0))
            {
                invisableBuy();
                visableRental();
                choice = 0;

            }
            else if (cmbBuyHome.SelectedIndex.Equals(1))
            {
                invisableRental();
                visableBuy();
                choice = 1;
            }
            btnHomeloanCalc.Visibility = Visibility.Visible;

        }

        private void invisableRental()
        {
            //if the user picks buy the Rent items disappear
            txtRentalAmount.Visibility = Visibility.Collapsed;
            lblRenting.Visibility = Visibility.Collapsed;

        }
        private void visableRental()
        {
            //if the user picks renting the renting items appear
            txtRentalAmount.Visibility = Visibility.Visible;
            lblRenting.Visibility = Visibility.Visible;
        }
        private void invisableBuy()
        {

            //if the user picks Rent the buy  items disappear
            txtHomePurchasePrice.Visibility = Visibility.Collapsed;
            lblPurchasePrice.Visibility = Visibility.Collapsed;
            txtHomedeposit.Visibility = Visibility.Collapsed;
            lblDeposit.Visibility = Visibility.Collapsed;
            txtHomeInterest.Visibility = Visibility.Collapsed;
            lblInterest.Visibility = Visibility.Collapsed;
            txtHomeTIme.Visibility = Visibility.Collapsed;
            lblTime.Visibility = Visibility.Collapsed;

        }
        private void visableBuy()
        {
            //if the user picks Buying property ,the buying items appear
            txtHomePurchasePrice.Visibility = Visibility.Visible;
            lblPurchasePrice.Visibility = Visibility.Visible;
            txtHomedeposit.Visibility = Visibility.Visible;
            lblDeposit.Visibility = Visibility.Visible;
            txtHomeInterest.Visibility = Visibility.Visible;
            lblInterest.Visibility = Visibility.Visible;
            txtHomeTIme.Visibility = Visibility.Visible;
            lblTime.Visibility = Visibility.Visible;
        }

        private void btnHomeloanCalc_Click(object sender, RoutedEventArgs e)
        {
            if (choice == 0)
            {
                try
                {
                    homeAmount = double.Parse(txtRentalAmount.Text);

                }
                catch (Exception)
                {

                    lblError.Visibility = Visibility.Visible;
                }
                

            }
            else if (choice == 1)
            {
                try
                {
                    double HomePurchasePrice = double.Parse(txtHomePurchasePrice.Text);
                    double homeDeposit = double.Parse(txtHomedeposit.Text);
                    double homeInterestRate = double.Parse(txtHomeInterest.Text);
                    double homeRepayment = double.Parse(txtHomeTIme.Text);
                    HomeLoanCalculation HomeloancalcOBJ = new HomeLoanCalculation();
                    homeAmount = HomeloancalcOBJ.calculateCost(HomePurchasePrice, homeDeposit, homeInterestRate, homeRepayment);
                }
                catch (Exception)
                {

                    lblError.Visibility = Visibility.Visible;
                }


            }

            MainWindow.SendingList.Add(new Expensedata
            {
                Expense = "Home",
                Amount = homeAmount
            });

            HomeLoanPlusExp.ItemsSource = MainWindow.SendingList;
            btnHomeloanCalc.Visibility = Visibility.Collapsed;
            cmbBuyHome.Visibility = Visibility.Collapsed;
            lblBuyRentQuestion.Text = "            Calculated   ";
            btnNext3.Visibility = Visibility.Visible;
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure, (This will discard all data and you will start again" +
               ")", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.Show();
            }
        }
    }
}
