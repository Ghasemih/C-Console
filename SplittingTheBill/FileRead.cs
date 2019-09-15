using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SplittingTheBill
{
    public class FileRead
    {
        //readonly ITrip _trip;
        //readonly ICollection<ITrip> _listTrip;
        List<Trip> listTrip = new List<Trip>();
        StreamReader sr;
        int tripidx = 0;

        //public FileRead()
        //{
        //    _trip = trip;
        //    _listTrip = listTrip;
        //}
    
        public void FileExist(string fileName)
        {
            //bool FileisExist;
            if (File.Exists(fileName) != true)
            {
                throw new FileNotFoundException("File not found");
            }
        }

        public List<Trip> OpenFile(string fileName)
        {
               sr = new StreamReader(fileName);
               string SfirstLine = string.Empty;
               string SsecondrLine = string.Empty;
              
               //Reading as long as it is not null or equal to 0
               while ((SfirstLine = sr.ReadLine()) != null && SfirstLine != "0")
               {
                   PutInList(SfirstLine);
               }
               return listTrip;
        }

        private void PutInList(string SfirstLine)
        {
            //Getting number of people in one trip
            int NumPerson = int.Parse(SfirstLine);


            float Line;
            Trip trip = new Trip();
            trip.TripId = tripidx;


            //Number of time which people have paid
            int NumPiad;


            //ITrip _myTrip;


            //Creating lists for one trip
            List<List<float>> TfList = new List<List<float>>();

            for(int i=1; i <= NumPerson; i++)
            {
                NumPiad = int.Parse(sr.ReadLine());
                List<float> fList = new List<float>();
                int j = 0;
                while(j < NumPiad )
                {
                    Line = float.Parse(sr.ReadLine());
                    fList.Add(Line);
                    j++;
                }
                TfList.Add(fList);
            }

            tripidx++;
            trip.TripExpenses = TfList;
            listTrip.Add(trip);
        } 
    }
}
