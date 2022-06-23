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
        }

        private void btnExpenseCal_Click(object sender, RoutedEventArgs e)
        {
            //list initalize
            List<Expensedata> Expenses = new List<Expensedata>();

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
            Expenses.Add(new Expensedata()
            {
                Expense = "Total",
                Amount = Double.Parse(txtCellPhone.Text) + Double.Parse(txtOther.Text)+
                Double.Parse(txtTravel.Text)

            });

            Expenses.OrderByDescending();

        }


    }

    class Expensedata
    {
        public String Expense { get; set; }
        public double Amount { get; set; }
    }

}
