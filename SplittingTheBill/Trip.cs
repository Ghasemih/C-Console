using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBill
{
    public class Trip : ITrip
    {
        public int TripId { get; set; }
        public List<List<float>> TripExpenses { get; set; }

        //Calculating average in one trip
        public float AverageExpense()
        {
            float Totalsum = 0;
            foreach(var ListTE in TripExpenses)
            {
                foreach(float TE in ListTE)
                {
                    Totalsum += TE;
                }
            }

            return Totalsum / TripExpenses.Count;
        }
        

        //Person expenses
        public float PersonExpense(int index)
        {
            float PersonSum = 0;
            foreach(float PE in TripExpenses[index])
            {
                PersonSum += PE;
            }

            return PersonSum;
        }


        //Calculating who ows and who has to be paid
        public List<float> PaidOrCollectList()
        {
            List<float> PaidCollectList = new List<float>();
            float NetCollectPaid ;
            float NetExpepense = AverageExpense();
            for(int i=0; i < TripExpenses.Count; i++)
            {
                NetCollectPaid = NetExpepense - PersonExpense(i);
                PaidCollectList.Add(NetCollectPaid);
            }

            return PaidCollectList;
        }
    }
}
