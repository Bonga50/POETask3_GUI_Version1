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
    /// Interaction logic for Rentalwindow.xaml
    /// </summary>
    public partial class Rentalwindow : Window
    {
        double carTotal = 0;
        public Rentalwindow()
        {
            InitializeComponent();
            //make the car items appear only when yes is selected 
            txtCarMake.Visibility = Visibility.Collapsed;
            txtCarModel.Visibility = Visibility.Collapsed;
            txtCarPurchase.Visibility = Visibility.Collapsed;
            txtCardeposit.Visibility = Visibility.Collapsed;
            txtCarInterest.Visibility = Visibility.Collapsed;
            txtCarInsuranse.Visibility = Visibility.Collapsed;
            //make the lables appear only when yes is selected
            lblCarmake.Visibility = Visibility.Collapsed;
            lblCarModel.Visibility = Visibility.Collapsed;
            lblPurchase.Visibility = Visibility.Collapsed;
            lbldeposit.Visibility = Visibility.Collapsed;
            lblInterest.Visibility = Visibility.Collapsed;
            lblInsurance.Visibility = Visibility.Collapsed;
            //button
            btnCalculate.Visibility = Visibility.Collapsed;
        }

        private void cmbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCar.SelectedIndex.Equals(0)) 
            {
                //make the car items appear only when yes is selected 
                txtCarMake.Visibility = Visibility.Visible;
                txtCarModel.Visibility = Visibility.Visible;
                txtCarPurchase.Visibility = Visibility.Visible;
                txtCardeposit.Visibility = Visibility.Visible;
                txtCarInterest.Visibility = Visibility.Visible;
                txtCarInsuranse.Visibility = Visibility.Visible;
                //make the lables appear only when yes is selected
                lblCarmake.Visibility = Visibility.Visible;
                lblCarModel.Visibility = Visibility.Visible;
                lblPurchase.Visibility = Visibility.Visible;
                lbldeposit.Visibility = Visibility.Visible;
                lblInterest.Visibility = Visibility.Visible;
                lblInsurance.Visibility = Visibility.Visible;
                btnCalculate.Visibility = Visibility.Visible;


            } 
            else if (cmbCar.SelectedIndex.Equals(1))
            {
                //make the car items appear only when yes is selected 
                txtCarMake.Visibility = Visibility.Collapsed;
                txtCarModel.Visibility = Visibility.Collapsed;
                txtCarPurchase.Visibility = Visibility.Collapsed;
                txtCardeposit.Visibility = Visibility.Collapsed;
                txtCarInterest.Visibility = Visibility.Collapsed;
                txtCarInsuranse.Visibility = Visibility.Collapsed;
                //make the lables appear only when yes is selected
                lblCarmake.Visibility = Visibility.Collapsed;
                lblCarModel.Visibility = Visibility.Collapsed;
                lblPurchase.Visibility = Visibility.Collapsed;
                lbldeposit.Visibility = Visibility.Collapsed;
                lblInterest.Visibility = Visibility.Collapsed;
                lblInsurance.Visibility = Visibility.Collapsed;
                //button
                btnCalculate.Visibility = Visibility.Collapsed;

                

            }
            
        }
    }
}
