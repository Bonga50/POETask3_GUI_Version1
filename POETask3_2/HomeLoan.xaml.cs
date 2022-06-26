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
    /// Interaction logic for HomeLoan.xaml
    /// </summary>
    public partial class HomeLoan : Window
    {
        public HomeLoan()
        {
            InitializeComponent();
            //will appear when an error is caught
            lblError.Visibility = Visibility.Collapsed;
            btnHomeloanCalc.Visibility = Visibility.Collapsed;
            invisableBuy();
            invisableRental();
        }

        private void cmbBuyHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBuyHome.SelectedIndex.Equals(0))
            {
                invisableBuy();
                visableRental();
               

            } else if (cmbBuyHome.SelectedIndex.Equals(1)) {
                invisableRental();
                visableBuy();
            }
            btnHomeloanCalc.Visibility = Visibility.Visible;

        }
        
        private void invisableRental()
        {
            //if the user picks buy the Rent items disappear
            txtRentalAmount.Visibility = Visibility.Collapsed;
            lblRenting.Visibility = Visibility.Collapsed;
   
        }
        private void visableRental() {
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

        }
    }
}
