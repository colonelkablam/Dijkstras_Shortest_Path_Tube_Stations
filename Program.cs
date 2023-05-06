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

            // start and finish default stations
            string startStation = "Vauxhall";
            string endStation = "Paddington";

            // number of tests to run
            int testCycles = 100000;

            BenchmarkingResults benchmarkingResults = new BenchmarkingResults();
            ConsistencyResults consistencyResults = new ConsistencyResults();
            int consistencyTestNum = 1;

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
                Console.WriteLine("1. Change the START station");
                Console.WriteLine("2. Change the END station");
                Console.WriteLine("3. Change number of test cycles for BENCHMARKING");
                Console.WriteLine();
                Console.WriteLine("4. Run CONSISTENCY test");
                Console.WriteLine("5. Display table of results");
                Console.WriteLine();
                Console.WriteLine("6. Run BENCHMARK test");
                Console.WriteLine("7. Display table of results");
                Console.WriteLine();
                Console.WriteLine("8. Print results of tests");
                Console.WriteLine("9. Exit");
                Console.WriteLine();
                Console.WriteLine($"Current Settings:");
                Console.WriteLine($"start:\t\t{startStation}\nend:\t\t{endStation}");
                Console.WriteLine($"iterations:\t{testCycles}");
                Console.WriteLine();
                Console.Write("Enter your choice (1-9): ");

                // read user selection
                int selection;
                int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    // CHANGE START STATION
                    case 1:
                        Console.Clear();
                        SelectStation();
                        break;
                    // CHANGE END STATION
                    case 2:
                        Console.Clear();
                        SelectStation();
                        break;

                    // CHANGE NUMBER OF TEST CYCLES
                    case 3:
                        Console.Clear();
                        InputNumberOfTests();
                        break;

                    // CONSISTANCY TEST
                    case 4:
                        Console.Clear();
                        Console.WriteLine("////////////////////////////\n");
                        Console.WriteLine("Running Consistency test...\n");
                        Console.WriteLine("////////////////////////////\n");
                        Console.WriteLine();

                        // runs a consistencey test testult
                        List<JourneyLinkedList> result = RunConsistencyTest(startStation, endStation);
                        // add it to main results
                        consistencyResults.AddRoutes(consistencyTestNum++, result, $"{startStation} - {endStation}");
                        break;

                    // DISPLAY TABLE OF CONSISTENCY RESULTS
                    case 5:
                        Console.Clear();
                        consistencyResults.DisplayResultsTable();
                        Console.ReadKey();
                        break;

                    // BENCHMARKING TEST
                    case 6:
                        Console.Clear();
                        Console.WriteLine("////////////////////////////\n");
                        Console.WriteLine("Running Benchmarking test...\n");
                        Console.WriteLine("////////////////////////////\n");
                        Console.WriteLine();

                        // returns a BenchmarkResult object array
                        benchmarkingResults.AddResult(RunBenchmarkTest(startStation, endStation, testCycles));
                        break;

                    // DISPLAY TABLE OF BENCHMARK RESULTS
                    case 7:
                        Console.Clear();
                        benchmarkingResults.DisplayResultsTable();
                        Console.ReadKey();

                        break;

                    // PRINT RESULTS TO .TXT FILE
                    case 8:
                        Console.Clear();
                        //consistencyResults.PrintResultsTable();
                        //benchmarkingResults.PrintResultsTable();
                        Console.ReadKey();

                        // EXIT
                        break;
                    case 9:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1,2,3 or 4 only");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                }
            }

            // MAIN FUNCTIONS

            // function to test CONSISTENCY between versions
            List<JourneyLinkedList> RunConsistencyTest(string startStation, string endStation)
            {
                // create a list to hold Versions to be tested
                List<ITestable> testables = new List<ITestable>();

                // create an instance of version 1 and add to list
                testables.Add(new Version1());
                // create an instance of Version 2
                //testables.Add(new Version1());
                // create an instance of Version 3
                testables.Add(new Version3());

                // list to hold result from each test on a version
                List<JourneyLinkedList> results = new List<JourneyLinkedList>();

                // create a List for recording if app executed/crashed
                List<string> miniCrashLog = new List<string>();

                //// iterate through versions ////
                foreach (ITestable version in testables)
                {
                    // catch and return any error from running application
                    try
                    {
                        JourneyLinkedList calculatedPath = version.CalcualteShortestPath(startStation, endStation);
                        results.Add(calculatedPath);
                        miniCrashLog.Add("successful");
                    }
                    catch (Exception e)
                    {
                        miniCrashLog.Add($"failed; {e.Message}");
                    }
                }
                Console.WriteLine($"Finished test: ");
                // print out log
                for (int i = 0; i < miniCrashLog.Count(); i++)
                {
                    Console.WriteLine($"Version {i + 1} executed: {miniCrashLog[i]}");
                }
                Console.WriteLine($"Press any key to return to menu to see print/show results...");
                Console.ReadKey();
                return results;

            }   // end of CONSISTENCY test


            // function to return BENCHMARK result for different paths for each version
            BenchmarkResult RunBenchmarkTest(string startStation, string endStation, int testCycles)
            {
                // create a list to hold Versions to be tested
                List<ITestable> testables = new List<ITestable>();

                // create an instance of version 1, version 2 and Version 3
                testables.Add(new Version1());
                // create an instance of Version 2
                //testables.Add(new Version2());
                // create an instance of Version 3
                testables.Add(new Version3());

                // create a new result to populate with times
                BenchmarkResult results = new BenchmarkResult($"{startStation} to {endStation}");

                //// iterate through versions ////
                int versionNum = 1;
                foreach (ITestable version in testables)
                {
                    // create new stopwatch
                    Stopwatch timer = new Stopwatch();

                    // start the timer
                    timer.Start();

                    // run the test the requested number of times
                    for (int i = 0; i < testCycles; i++)
                    {
                        // run the version with the start and finish stations
                        version.CalcualteShortestPath(startStation, endStation);
                    }
                    // stop the timer
                    timer.Stop();

                    // get the timespan 
                    TimeSpan timeTaken = timer.Elapsed;

                    // get a float for the average per cycle
                    double averageT = timeTaken.TotalMilliseconds / testCycles;

                    Console.WriteLine($"Version {versionNum} finished testing in {timeTaken.TotalMilliseconds / 1000} seconds...");

                    // add time taken per cycle to dictionary
                    results.AddTime(versionNum, averageT);
                    versionNum++;


                    // timer reset
                    timer.Reset();
                }

                Console.WriteLine($"Press any key to return to menu to see print/show results...");
                Console.ReadKey();
                return results;

            }   // end of BENCHMARK test


            // function to select a valid station
            void SelectStation()
            {
                while (true)
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
                Console.WriteLine("Please enter an number between 1000 - 1000000: ");
                if (int.TryParse(Console.ReadLine(), out input) & (input >= 1000 && input <= 1000000))
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