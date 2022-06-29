using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POETask3_2
{
    abstract class Expense
    {
        //Abstact class for general calculation
        //P = Purchase price 
        //D = Deposit
        //I = intrerst
        //N = time
        public abstract double calculateCost(double P,double D,double I,double N);
    }
}
