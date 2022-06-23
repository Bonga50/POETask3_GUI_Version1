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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            
        }

        private void btnExpenseCal_Click(object sender, RoutedEventArgs e)
        {
            //list initalize [1](Chand, n.d.)
            List<Expensedata> Expenses = new List<Expensedata>();
            try
            {
                Expenses.Add(new Expensedata()
                {
                    Expense = "Grocery",
                    Amount = Double.Parse(txtGrocery.Text)

                });

            }
            catch (Exception)
            {

                lblError.Visibility = Visibility.Visible;
            }
            
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

            dataExpense.ItemsSource = Expenses;



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
 */
