using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SplittingTheBill
{
   public  class FileWrite
    {
        
        public void WriteTripExpense(List<Trip> lp)
       {
            using(TextWriter Wr = new  StreamWriter(".//Output.txt"))  
            {
                string _out ;
               foreach(Trip t in lp)
               {

                   //calculating for all trip
                   List<float> PORC = t.PaidOrCollectList();
                   
                   foreach (float f in PORC)
                   {

                       //Finding who ows and who has to get paid
                       _out = (f < 0) ? "($" + (Math.Abs(Math.Round(f, 2, MidpointRounding.AwayFromZero))).ToString() + ")" :
                                             "$" + (Math.Round(f, 2, MidpointRounding.ToEven)).ToString();
                       Wr.WriteLine(_out);
                   }

                   //Adding new line
                   Wr.WriteLine(string.Empty);
               }
              
            }
          
       }
    }
}
