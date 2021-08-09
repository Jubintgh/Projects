using System.IO;
using static System.Console;


namespace File_IO_Methods

{
    // Method for reading files into an array
    class Mymethod
    {

        public static void readingFile(string[] args)

        {

            // defining variables for array
            string[,] myArray = { };
            int rows;
            int i, j;
            rows = fileToArray("DataBase.txt", ref myArray);

            // to write the records of the line
            for (i = 0; i < myArray.GetLength(0); ++i)

            {

                for (j = 0; j < myArray.GetLength(1); ++j)

                {

                    Write("{0}, ", myArray[i, j]);

                }

                WriteLine();

            }
            WriteLine("Rows --> {0}", rows);
        }

        // Public method to read file into an accesible 2D array 

        public static int fileToArray(string fileName, ref string[,] Arr2D)

        {
            // to define variables for the method
            string[] records = { };
            string lineRead = "";
            int userCount = 0;
            int n, j;
            // read the file
            FileStream inFile =

            new FileStream(fileName, FileMode.Open, FileAccess.Read);

            StreamReader reader = new StreamReader(inFile);
            // put each line into an array
            while ((lineRead = reader.ReadLine()) != null)

            {
                records = lineRead.Split(',');
                userCount++;
            }
            // define size of 2D array based on number of rows and columns
            Arr2D = new string[userCount, records.Length];

            inFile.Seek(0, SeekOrigin.Begin);

            n = 0;

            while ((lineRead = reader.ReadLine()) != null)

            {
                records = lineRead.Split(',');

                for (j = 0; j < Arr2D.GetLength(1); ++j)

                {
                    Arr2D[n, j] = records[j];
                }

                n++;
            }
            // close the file
            reader.Close();
            inFile.Close();
            // return the 2D array
            return n;
        }
    }
}
