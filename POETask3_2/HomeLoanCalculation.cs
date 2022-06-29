using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POETask3_2
{
    class HomeLoanCalculation : Expense
    {
        //This will calculate HIRE PURCHASE for the general items such as the special items and Buy home
        public override double calculateCost(double PurchasePrice, double homeDeposit, double InterstRate, double Time)
        {

            

            double nPurchasePrice = PurchasePrice - homeDeposit;

            double nInterest = InterstRate / 100;

            double nTime = Time / 12;



            double A = nPurchasePrice * (1 + nInterest * nTime);

            double Mounthly = A / Time;

            return Mounthly;
        }
    }
}
