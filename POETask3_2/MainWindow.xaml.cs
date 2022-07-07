using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //From this window we get Total expenses , tax and total
        //[4](TACV - The Amazing Code-Verse, 2021)
        //instance for main window to use main window properties in other windows
        public static MainWindow instance;

        public static double TotalExpenses;
        public static double UserIncomeAmount;
        public static double Tax;
        //[3] (Kumar, n.d.)
        public static ObservableCollection<Expensedata> SendingList;
        public static ObservableCollection<Expensedata> SendingUserIncome;
        Rentalwindow NextObj = new Rentalwindow();
        public MainWindow()
        {
            InitializeComponent();
            //instance so the list can be sent to next class
            instance = this;
            //will appear only when an error is caught
            lblError.Visibility = Visibility.Collapsed;
            btnNext.Visibility = Visibility.Collapsed;


        }

        private void btnExpenseCal_Click(object sender, RoutedEventArgs e)
        {

            lblError.Visibility = Visibility.Collapsed;

            SendingList = LoadExpenseData();
            SendingUserIncome = LoadUserIncomeData();
            //[2](Sort list in descending order in C# | Techie Delight, 2022)
            //the below method sorts the list in decending order using Linq
            dataUserIncome.ItemsSource = LoadUserIncomeData().OrderByDescending(x => x.Amount);
            dataExpense.ItemsSource = LoadExpenseData().OrderByDescending(x => x.Amount);



        }
        //this method loads the list of expenses
        //[1](Chand, n.d.)
        private ObservableCollection<Expensedata> LoadExpenseData()
        {
            //list initalize for expenses [1](Chand, n.d.)
            ObservableCollection<Expensedata> Expenses = new ObservableCollection<Expensedata>();

            try
            {
                Expenses.Add(new Expensedata()
                {

                    Expense = "Grocery",
                    Amount = Double.Parse(txtGrocery.Text)

                });
                Expenses.Add(new Expensedata()
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
                TotalExpenses =
                  Double.Parse(txtGrocery.Text) +
                  Double.Parse(txtWater.Text) +
                  Double.Parse(txtTravel.Text) +
                  Double.Parse(txtCellPhone.Text) +
                  Double.Parse(txtOther.Text);
                //the next button will not appear until the user enters all values correctly
                btnNext.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                btnNext.Visibility = Visibility.Collapsed;
                lblError.Visibility = Visibility.Visible;
            }
          

            return Expenses;

        }
        //User income data such as total income , and expenses or tax
        private ObservableCollection<Expensedata> LoadUserIncomeData()
        {
            //Gross income and tax 
            ObservableCollection<Expensedata> UserIncome = new ObservableCollection<Expensedata>();

            try
            {
                UserIncome.Add(new Expensedata()
                {
                    Expense = "Gross Income",
                    Amount = double.Parse(txtGross.Text)
                });
                UserIncome.Add(new Expensedata()
                {
                    Expense = "Tax",
                    Amount = double.Parse(txtTax.Text)
                });
                //total of all expenses
                UserIncome.Add(new Expensedata()
                {
                    Expense = "Total Expenses",
                    Amount = TotalExpenses


                });

                UserIncomeAmount = double.Parse(txtGross.Text);
                Tax = double.Parse(txtTax.Text);



            }
            catch (Exception)
            {
                btnNext.Visibility = Visibility.Collapsed;
                lblError.Visibility = Visibility.Visible;
            }
           
            return UserIncome;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NextObj.Show();
            //this.Close();
            this.Visibility = Visibility.Collapsed;


        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class Expensedata
    {

        public String Expense { get; set; }
        public double Amount { get; set; }
    }

}
/*Refernces
 * 
 * [1] Chand, M. (n.d.). DataGrid in WPF. C-Sharpcorner. Retrieved June 22, 2022, from
 * https://www.c-sharpcorner.com/UploadFile/mahesh/datagrid-in-wpf/
 * 
 * [2] Techie Delight. 2022. Sort list in descending order in C# | Techie Delight. [online] Available at:
 * <https://www.techiedelight.com/sort-list-in-descending-order-in-csharp/> 
 * [Accessed 23 June 2022].
 * 
 * [3] Kumar, P. (n.d.). ObservableCollection in WPF. C-Sharpcorner. Retrieved June 26, 2022, from
 * https://www.c-sharpcorner.com/UploadFile/e06010/observablecollection-in-wpf/
 * 
 * [4] TACV - The Amazing Code-Verse. (2021, February 28). BEST Way to SEND DATA between Multiple Forms | C# Windows Form [Video].
 * YouTube. https://www.youtube.com/watch?v=t-4caAZKLJw
 * 
 * //References 
/*[5] W3schools.com. 2022. C# Abstraction. [online] Available at: <https://www.w3schools.com/cs/cs_abstract.php> 
 * [Accessed 11 May 2022].
 
 [6]Docs.microsoft.com. 2022. Double.Parse Method (System). [online] Available at:
<https://docs.microsoft.com/en-us/dotnet/api/system.double.parse?view=net-6.0>
[Accessed 11 May 2022].
 [7] Sars.gov.za. 2022. [online] Available at: 
<https://www.sars.gov.za/wp-content/uploads/Ops/Guides/PAYE-GEN-01-G01-Guide-for-Employers-in-respect-of-Tax-Deduction-Tables-External-Guide.pdf> 
[Accessed 12 May 2022].
 [8] W3schools.com. 2022. C# Arrays. [online] Available at: 
<https://www.w3schools.com/cs/cs_arrays.php>
[Accessed 12 May 2022].
 
 [9] w3resource. 2022. C# - Read and Print elements of an array - w3resource. [online] Available at: 
<https://www.w3resource.com/csharp-exercises/array/csharp-array-exercise-1.php> 
[Accessed 12 May 2022].
[10]Tutorialspoint.com. 2022. Sort KeyValuePairs in C#. [online] Available at: 
<https://www.tutorialspoint.com/sort-keyvaluepairs-in-chash>
[Accessed 30 May 2022].
 [11]GeeksforGeeks. 2022. C# | Delegates - GeeksforGeeks. [online] Available at:
<https://www.geeksforgeeks.org/c-sharp-delegates/>
[Accessed 23 May 2022].*/

