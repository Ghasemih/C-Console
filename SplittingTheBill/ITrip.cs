using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplittingTheBill
{

    //This interface is made to prevent DIP Principle violation
    //I was busy these two days(had couple of interviews) so I didn't have time to get it work with the application
    public interface ITrip
    {
         int TripId { get; set; }
         List<List<float>> TripExpenses { get; set; }
         float AverageExpense();

         float PersonExpense(int index);

         List<float> PaidOrCollectList();


    }
}
