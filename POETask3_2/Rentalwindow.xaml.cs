using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for Rentalwindow.xaml
    /// </summary>
    public partial class Rentalwindow : Window
    {
        //to close the current window when back is clicked 
       
        public static Rentalwindow instance;
        double carTotal = 0;
        public Rentalwindow()
        {
            InitializeComponent();
            colapsItems();
        }

        private void cmbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCar.SelectedIndex.Equals(0))
            {

                visableItems();

            }
            else if (cmbCar.SelectedIndex.Equals(1))
            {
                colapsItems();

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
        public void visableItems() {
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
            MainWindow.
            CarPlusExpenses.ItemsSource = LoadExpenseData();
        }

        private List<Expensedata> LoadExpenseData()
        {
            //list initalize for expenses [1](Chand, n.d.)
            List<Expensedata> Expenses = new List<Expensedata>();

            try
            {
                Expenses.Add(new Expensedata()
                {

                    Expense = "Grocery",
                    Amount = MainWindow.Groceries

                }) ;
/*                Expenses.Add(new Expensedata()
                {
                    Expense = "Water and lights",
                    Amount = Double.Parse(txtWater.Text)

                });
                Expenses.Add(new Expensedata()
                {
                    Expense = "Travel costs (including petrol)",
                    Amount = Double.Parse(txtTravel.Text)

                });
                Expenses.Add(new Expensedata()
                {
                    Expense = "Cell phone and telephone",
                    Amount = Double.Parse(txtCellPhone.Text)

                });
                Expenses.Add(new Expensedata()
                {
                    Expense = "Other expenses",
                    Amount = Double.Parse(txtOther.Text)

                });

                Groceries = double.Parse(txtGrocery.Text);
                //the next button will not appear until the user enters all values correctly
                btnNext.Visibility = Visibility.Visible;*/

            }
            catch (System.Exception)
            {
                /*btnNext.Visibility = Visibility.Collapsed;
                lblError.Visibility = Visibility.Visible;*/
            }

            return Expenses;

        }
    }
  
}
