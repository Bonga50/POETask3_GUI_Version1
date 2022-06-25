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
        BuyCar CarObj = new BuyCar();
        public static Rentalwindow instance;
        int Carchoice;
        public Rentalwindow()
        {
            InitializeComponent();
            colapsItems();
            lblError.Visibility = Visibility.Collapsed;
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
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            mainWindow.Visibility = Visibility.Visible;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //This will check if car  item already exists in the list 
            bool CaralreadyExists = MainWindow.SendingList.Any(x => x.Expense.Equals("Car"));
            if (Carchoice == 0)
            {
                double purchasePrice = double.Parse(txtCarPurchase.Text);
                double depositPrecntage = double.Parse(txtCardeposit.Text);
                double interestRate = double.Parse(txtCarInterest.Text);
                double numOfMonths = 24;
                double Answer = CarObj.calculateCost(purchasePrice, depositPrecntage, interestRate, numOfMonths);
                //add car to list of expenses.
                try
                {
                    MainWindow.SendingList.Add(new Expensedata()
                    {

                        Expense = "Car",
                        Amount = Answer + double.Parse(txtCarInsuranse.Text)

                    });
                }
                catch (System.Exception)
                {

                    lblError.Visibility = Visibility.Visible;
                }
              

            } else if (Carchoice ==1) {
                MainWindow.SendingList.Add(new Expensedata()
                {

                    Expense = "Car",
                    Amount = 0

                }) ;
            }
            cmbCar.Visibility = Visibility.Collapsed;
            lblBuyCar.Text = ""; 
            CarPlusExpenses.ItemsSource = MainWindow.SendingList;

        }


    }

}
