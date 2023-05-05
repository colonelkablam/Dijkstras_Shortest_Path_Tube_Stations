using System;              
using System.Diagnostics;  // StopWatch + TimeSpan

namespace Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            /////////////// MEGA-TESTING PROG ///////////////////            

            // Dictionary to hold all stations, names = keys, station = station
            Dictionary<string, Station> stations = new Dictionary<string, Station>();
            // call function to populate stations dictionary from csv file
            PopulateStationsDictionay();

            // start and finish stations
            string startStation = "nothing selected";
            string endStation = "nothing selected";

            // number of tests to run
            int testCycles = 10;     

            // start the menu
            bool exit = false;

            // main program loop to get inputs and run test
            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine("******************************************************************");
                Console.WriteLine("Testing 3 Different Implementations of Dijkstra's Search Algorithm");
                Console.WriteLine("      - check for consistency and time taken to execute -");
                Console.WriteLine("******************************************************************");
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Type in stations to walk between");
                Console.WriteLine("2. Choose number of tests iterations (1-100)");
                Console.WriteLine("3. Run test");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine($"Current station selections:");
                Console.WriteLine($"start:\t\t{startStation}\nend:\t\t{endStation}");
                Console.WriteLine($"iterations: {testCycles}");
                Console.WriteLine();
                Console.Write("Enter your choice (1-4): ");

                // read user selection
                int selection;
                int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        SelectStation();
                        break;

                    case 2:
                        Console.Clear();
                        InputNumberOfTests();
                        break;

                    case 3:
                        if (startStation == "" || endStation == "")
                        {
                            Console.WriteLine("No stations selected");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("//////////////////");
                            Console.WriteLine();
                            Console.WriteLine("Running test...");
                            Console.WriteLine();
                            Console.WriteLine("//////////////////");
                            Console.WriteLine();

                            // returns a TestResult object
                            TestResult[] results = RunTest(startStation, endStation, testCycles);
                        }

                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1,2,3 or 4 only");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                }
            }  
            
            // FUNCTIONS

            // function to 
            TestResult[] RunTest(string startStation, string endStation, int testCount)
            {
                // create new stopwatches
                Stopwatch timerV1 = new Stopwatch();
                Stopwatch timerV2 = new Stopwatch();
                Stopwatch timerV3 = new Stopwatch();

                // create an array to contain the test results
                TestResult[] results = new TestResult[3];

                // results
                TestResult? result1 = null;
                TestResult? result2 = null;
                TestResult? result3 = null;

                // create an instance of solution 1
                Version3 version3 = new Version3();
                version3.GenerateAdjacencyList();

                // run the test the requested number of times
                for (int i = 0; i < testCount; i++)
                {
                    // start the timer for V1
                    timerV1.Start();
                    
                    // run the algo with the start and finish stations
                    version3.CalcualteShortestPath(startStation, endStation);
                    
                    // stop the timer for V1
                    timerV1.Stop();

                    // get the timespan
                    TimeSpan timeV1 = timerV1.Elapsed;

                    // add the 
                    // totalTime += timeV1.TotalMilliseconds;
                }

                // result3.AddTiming
                // string totalTimeString = String.Format("{0}", totalTime);

                Console.ReadKey();
                return results;

            }


            // function to select a valid station
            void SelectStation()
            {
                while(true)
                {
                    Console.WriteLine("Input start Station:");
                    startStation = Console.ReadLine();

                    if (stations.ContainsKey(startStation))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input. Station Not Found.");
                }
                while (true)
                {
                    Console.WriteLine("Input end Station:");
                    endStation = Console.ReadLine();

                    if (stations.ContainsKey(endStation))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input. Station Not Found.");
                }
            }

            // function to input valid number of tests
            void InputNumberOfTests()
            {

            }

            // function to create Stations Dictionary
            void PopulateStationsDictionay()
            { 

                // reading csv file and instantiating objects to pass into dictionary
                using (var reader = new StreamReader("stations3.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        string lineName = values[0];
                        string fromName = values[1];
                        string toName = values[2];
                        int time = int.Parse(values[3]);

                        Station fromStation, toStation;

                        // Check to make sure we don't get separate stations for (eg. bakerloo oxford st and central oxford st)
                        if (!stations.ContainsKey(fromName))
                        {
                            fromStation = new Station(fromName);
                            stations[fromName] = fromStation;
                        }
                        else
                        {
                            fromStation = stations[fromName];
                        }

                        if (!stations.ContainsKey(toName))
                        {
                            toStation = new Station(toName);
                            stations[toName] = toStation;
                        }
                        else
                        {
                            toStation = stations[toName];
                        }

                        // Add the connection between the two stations
                        fromStation.Neighbours.AddLast((toStation, lineName, time));
                        toStation.Neighbours.AddLast((fromStation, lineName, time));
                    }
                }
            }

        }
    }
}