using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace POETask3_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblError.Visibility = Visibility.Collapsed;
            btnNext.Visibility = Visibility.Collapsed;
        }

        private void btnExpenseCal_Click(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Collapsed;
            //list initalize [1](Chand, n.d.)
            List<Expensedata> Expenses = new List<Expensedata>();


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

                //the next button will not appear until the user enters all values correctly
                btnNext.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {

                lblError.Visibility = Visibility.Visible;
            }



            //total for all expenses above
            /*Expenses.Add(new Expensedata()
            {
                Expense = "Total",
                Amount = Double.Parse(txtCellPhone.Text) +
                Double.Parse(txtOther.Text)+
                Double.Parse(txtTravel.Text)+
                Double.Parse(txtWater.Text)+
                Double.Parse(txtGrocery.Text)
            });*/


            //[2](Sort list in descending order in C# | Techie Delight, 2022)
            //the below method sorts the list in decending order using Linq
            List<Expensedata> sorted = Expenses.OrderByDescending(x => x.Amount).ToList();
            dataExpense.ItemsSource = sorted;




        }


    }

    class Expensedata
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
 */
