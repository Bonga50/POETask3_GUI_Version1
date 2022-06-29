using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POETask3_2
{
    class BuyCar : Expense
    {
        //calculates hire purchase fro car, This is a duplicate method and can be removed.
        public override double calculateCost(double PurchasePrice, double CarDeposit,double Interest,double Time)
        {
           
            
            double nPurchasePrice = PurchasePrice - CarDeposit;
            
            double nInterest = Interest / 100;
            
            double nTime = Time / 12;
            


            double A = nPurchasePrice * (1 + nInterest*nTime);
            
            double Mounthly = A / Time;

            return Mounthly;
        }
    }
}
