using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POETask3_2
{
    class HomeLoanCalculation : Expense
    {
        public override double calculateCost(double PurchasePrice, double homeDeposit, double InterstRate, double Time)
        {

            double nDeposit = (PurchasePrice * homeDeposit) / 100;

            double nPurchasePrice = PurchasePrice - nDeposit;

            double nInterest = InterstRate / 100;

            double nTime = Time / 12;



            double A = nPurchasePrice * (1 + nInterest * nTime);

            double Mounthly = A / Time;

            return Mounthly;
        }
    }
}
