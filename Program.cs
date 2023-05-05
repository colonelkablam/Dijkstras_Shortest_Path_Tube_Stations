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
            string startStation = string.Empty;
            string endStation = string.Empty;

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
                Console.WriteLine("            - CONSISTENCY check and BENCHMARKING -");
                Console.WriteLine("******************************************************************");
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Type in stations to walk between for consistency check");
                Console.WriteLine("2. Choose number of tests iterations (1-100) for benchmarking");
                Console.WriteLine("3. Run CONSISTENCY test");
                Console.WriteLine("4. Run BENCHMARK test");
                Console.WriteLine("5. Print results of tests");
                Console.WriteLine("6. Exit");
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
                        if (startStation == string.Empty || endStation == string.Empty)
                        {
                            Console.WriteLine("No stations selected");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();
                            Console.WriteLine("Running Consistency test...");
                            Console.WriteLine();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();

                            // returns a TestResult object array
                            ConsistencyResults[] results = RunConsistencyTest(startStation, endStation);
                        }

                        break;
                    case 4:
                        if (startStation == string.Empty || endStation == string.Empty)
                        {
                            Console.WriteLine("No stations selected");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();
                            Console.WriteLine("Running Benchmarking test...");
                            Console.WriteLine();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();

                            // returns a BenchmarkResult object array
                            List<BenchmarkResults> results = RunBenchmarkTest(startStation, endStation, testCycles);
                        }

                        break;
                    case 5:
                        // print results to go here
                        break;
                    case 6:
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

            // function to test CONSISTENCY
            List<ConsistencyResults> RunConsistencyTest(string startStation, string endStation)
            {
                // create an array to contain the test results
                List<ConsistencyResults> results = new List<ConsistencyResults>();

                // create an instance of solution 1
                Version3 version3 = new Version3();
                // generate its AL
                version3.GenerateAdjacencyList();

                // initialise return string representing path
                string calculatedPath = "no path returned by Version";

                // run the algo with the start and finish stations
                calculatedPath = version3.CalcualteShortestPath(startStation, endStation);

                Console.WriteLine($"Route to test: {startStation} to {endStation}");
                Console.WriteLine($"===============================================");
                Console.WriteLine($"Version 3:");
                Console.WriteLine($"{calculatedPath}");
                Console.WriteLine($"---------------------------------------------");

                Console.ReadKey();
                return results;

            }   // end of CONSISTENCY test

            // function to return BENCHMARK result for different paths for each version
            List<BenchmarkResults> RunBenchmarkTest(string startStation, string endStation, int testCount)
            {
                // create new stopwatches
                Stopwatch timerV1 = new Stopwatch();
                Stopwatch timerV2 = new Stopwatch();
                Stopwatch timerV3 = new Stopwatch();

                // create an list to contain the test results
                List<BenchmarkResults> results = new List<BenchmarkResults>();

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

                }

                // get the timespan
                TimeSpan timeV1 = timerV1.Elapsed;

                // result3.AddTiming
                // string totalTimeString = String.Format("{0}", totalTime);

                Console.WriteLine($"Route to test: {startStation} to {endStation}, {testCount} cycles");
                Console.WriteLine($"=================================================================");
                Console.WriteLine($"Version 3 execution time: {timeV1.Milliseconds} ms");
                Console.WriteLine($"---------------------------------------------");


                Console.ReadKey();
                return results;

            }   // end of BENCHMARK test


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
                int input = -1;
                Console.WriteLine("Please enter an number between 1 and 1000: ");
                if (int.TryParse(Console.ReadLine(), out input) & (input >= 1 && input <= 1000))
                {
                    testCycles = input;
                }
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