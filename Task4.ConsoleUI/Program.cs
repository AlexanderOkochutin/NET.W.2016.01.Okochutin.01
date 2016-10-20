using System;
using System.Collections.Generic;
using System.Linq;
using Task4.Logic;

namespace Task4.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           
            do
            {
                Console.WriteLine("Enter array of int in next format  -m a0,a1,a2  or -r min,max,count "); // -m manual enter array in next format 1,2,3... or 1 2 3
                Console.WriteLine("example of input info: -m 1,14,3,8,19 or -r -5,20,10");                 // -r random array in range from min to max and count of elem
                Console.WriteLine(new string('*',67));
                string inputData = Console.ReadLine(); // get input data in format -param a,b,c...
                Random rand = new Random();
                int[] rsltArray = null;
                bool tryAgain = true;
                string cmdParam = "noParam";
                if (inputData.Length >= 2)
                {
                    cmdParam = inputData.Substring(0, 2);
                }
                if (cmdParam == "-m") // manual input array
                {
                    while (tryAgain) // in case of fail repeat 
                    {
                        try
                        {
                            rsltArray = Array.ConvertAll(inputData.Substring(3).Split(new char[] { ' ', ',' }), int.Parse); // parse string[] into int[]
                            tryAgain = false; // set in case of success
                        }

                        catch
                        {
                            Console.WriteLine("****Please check input information, and try again!****");
                            Console.WriteLine("****example of input info: -m 1,2,3  or  -m 1 2 3 ****");
                            inputData = Console.ReadLine(); // in case of fail repeat enter of info
                        }
                    }
                }

                if (cmdParam == "-r") // random input array
                {
                    while (tryAgain) // in case of fail repeat
                    {
                        try
                        {
                            int[] randParam = Array.ConvertAll(inputData.Substring(3).Split(new char[] { ' ', ',' }), int.Parse); // parse string[] into int[]
                            if (randParam[2] <= 0)
                            {
                                throw new Exception();
                            }

                            rsltArray = new int[randParam[2]];
                            Console.WriteLine("not sorted array:");
                            for (int i = 0; i < randParam[2]; i++)
                            {
                                rsltArray[i] = rand.Next((int)randParam[0], (int)randParam[1]);
                                Console.Write(rsltArray[i].ToString() + ",");
                            }
                            Console.WriteLine();
                            tryAgain = false; // set in case of success
                        }

                        catch
                        {
                            Console.WriteLine("****Please check input information, and try again!****");
                            Console.WriteLine("****example of input info: -r min,max,count  or  -r min max count ****");
                            inputData = Console.ReadLine(); // in case of fail repeat enter of info
                        }
                    }
                }

                if (tryAgain == false) // if parse is successfull than choose type of sort increase or decrease
                {
                    Console.WriteLine("enter -i for increase sort or -d for decrease sort");
                    string sortType = Console.ReadLine();
                    if (sortType == "-i") // increase
                    {
                        rsltArray.MergeSort(new ExtensionToolsForArray.IncComparer<int>());
                        Console.WriteLine("Sorted array");
                    }

                    else if (sortType == "-d") // decrease
                    {
                        rsltArray.MergeSort(new ExtensionToolsForArray.DecComparer<int>());
                        Console.WriteLine("Sorted array");
                    }
                    else
                    {
                        Console.WriteLine("Not correct sort_type");
                    }
                    
                    foreach (int i in rsltArray)
                    {
                        Console.WriteLine(i);
                    }
                }

                else // if parse fail repeat enter info
                {
                    Console.WriteLine("check input information!");
                }

                Console.WriteLine("enter 'stop' to exit program or press 'enter' to continue");

            } while (Console.ReadLine() != "stop");
        }
    }
    
}
