using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBill
{
    class Program
    {
        
        //*** starting Program ****
        static void Main(string[] args)
        {
           //Reading file path and file name
            string filename = string.Empty;
            Console.WriteLine("Enter valid file name: ");
            filename = Console.ReadLine();
            //Checking file is empty
            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("The file name is empty");
                Console.ReadKey();
                return;
            }

            //Reading and writing file
            FileRead Fr = new FileRead();
            FileWrite Wr = new FileWrite();

            //Getting path file => (Input.txt)
            filename = Path.GetFileName(filename);
            try
            {
                Fr.FileExist(filename);
                List<Trip> LP = Fr.OpenFile(filename);

                //Writing the expenses using writefile
                Wr.WriteTripExpense(LP);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
    }
}
