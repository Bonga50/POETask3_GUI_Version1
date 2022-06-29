using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for Rentalwindow.xaml
    /// </summary>
    public partial class Rentalwindow : Window
    {
        //This window will get the Car amount 
        BuyCar CarObj = new BuyCar();
        public static Rentalwindow instance;
        int Carchoice;
        public static double CarAmount;
        bool isValid;

        //variables for car
        double purchasePrice;
        double depositPrecntage;
        double interestRate;
        double numOfMonths;
        double Answer;
        public Rentalwindow()
        {
            InitializeComponent();
            colapsItems();
            lblError.Visibility = Visibility.Collapsed;
            btnNext2.Visibility = Visibility.Collapsed;
        }

        private void cmbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCar.SelectedIndex.Equals(0))
            {

                visableItems();
                Carchoice = 0;

            }
            else if (cmbCar.SelectedIndex.Equals(1))
            {
                colapsItems();
                Carchoice = 1;
                btnCalculate.Visibility = Visibility.Visible;
            }
        }

        public void colapsItems()
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
        public void visableItems()
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //[6] (Chand, n.d.-b)
            MessageBoxResult result = MessageBox.Show("Are you sure, (This will discard all data and you will start again" +
                ")", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Collapsed;
                mainWindow.Visibility = Visibility.Visible;
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Collapsed;
            //This will check if car  item already exists in the list 
            //bool CaralreadyExists = MainWindow.SendingList.Any(x => x.Expense.Equals("Car"));

            //Error handleing 
            if (Carchoice == 0)
            {
                try
                {
                    purchasePrice = double.Parse(txtCarPurchase.Text);
                    depositPrecntage = double.Parse(txtCardeposit.Text);
                    interestRate = double.Parse(txtCarInterest.Text);
                    numOfMonths = 60;
                    Answer = CarObj.calculateCost(purchasePrice, depositPrecntage, interestRate, numOfMonths) + double.Parse(txtCarInsuranse.Text);

                    isValid = true;

                }
                catch (System.Exception)
                {

                    lblError.Visibility = Visibility.Visible;
                    isValid = false;

                }

            }
            else if (Carchoice == 1)
            {
                Answer = 0;
                isValid = true;
            }


            //add car to list of expenses.
            //this will not execute as long as errors are detectable
            if (isValid == true) {
                if (Carchoice == 0)
                {
                    MainWindow.SendingList.Add(new Expensedata()
                    {

                        Expense = "Car",
                        Amount = Answer

                    });
                   



                } else if (Carchoice == 1) {
                    MainWindow.SendingList.Add(new Expensedata()
                    {

                        Expense = "Car",
                        Amount = 0

                    });
                }


                cmbCar.Visibility = Visibility.Collapsed;
                lblBuyCar.Text = "               Calculated   ";
                btnNext2.Visibility = Visibility.Visible;
                btnCalculate.Visibility = Visibility.Collapsed;
                CarPlusExpenses.ItemsSource = MainWindow.SendingList;
            }

        }

        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
          
                HomeLoan HomeObj = new HomeLoan();
                this.Hide();
                HomeObj.Show();

        }
    }

}
/*Refernces 
 * [6] Chand, M. (n.d.-b). MessageBox In WPF. C-Sharpcorner. Retrieved June 26, 2022, from 
 * https://www.c-sharpcorner.com/UploadFile/mahesh/messagebox-in-wpf/
 */