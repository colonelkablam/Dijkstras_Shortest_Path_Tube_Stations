using System.Diagnostics;  // StopWatch + TimeSpan
using System.Linq;

namespace Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            /////////////// MEGA-TESTING PROG ///////////////////            

            // List to hold all stations names
            List<string> stations = new List<string>();
            // call function to populate stations dictionary from csv file
            PopulateStationsList();

            // start and finish default stations
            string startStation = "Vauxhall";
            string endStation = "Paddington";

            // number of tests to run
            int testCycles = 100;

            BenchmarkingResults benchmarkingResults = new BenchmarkingResults();
            ConsistencyResults consistencyResults = new ConsistencyResults();
            int consistencyTestNum = 1;

            PrintStations();
            Console.ReadKey();

            // start the menu
            bool exit = false;

            // menu loop to get inputs and run tests
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
                        startStation = SelectStation();
                        break;
                    // CHANGE END STATION
                    case 2:
                        Console.Clear();
                        endStation = SelectStation();
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
                        
                        Console.WriteLine($"\nPress any key to return to the main menu...");
                        Console.ReadKey();
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
                        
                        Console.WriteLine($"\nPress any key to return to the main menu...");
                        Console.ReadKey();
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
            } // end of menu loop

            // MAIN FUNCTIONS

            // function to test CONSISTENCY between versions
            List<JourneyLinkedList> RunConsistencyTest(string startStation, string endStation)
            {
                // create a list to hold Versions to be tested
                List<ITestable> testables = new List<ITestable>();

                // create an instance of version 1 and add to list
                testables.Add(new Version1(1));
                //testables.Add(new Version1());
                testables.Add(new Version3(3));

                // list to hold result from each test on a version
                List<JourneyLinkedList> results = new List<JourneyLinkedList>();

                //// iterate through versions ////
                foreach (ITestable version in testables)
                {
                    // catch and return any error from running application
                    try
                    {
                        JourneyLinkedList calculatedPath = version.CalcualteShortestPath(startStation, endStation);
                        results.Add(calculatedPath);
                        Console.WriteLine($"Version {version.VersionNumber} execution: successful");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Version {version.VersionNumber} execution: failed");
                        Console.WriteLine($"error message: {e.Message}");
                    }
                }
                Console.WriteLine($"Press any key to see the results:\n");
                Console.ReadKey();
                foreach (JourneyLinkedList route in results)
                {
                    route.DisplayAll();
                }
                return results;

            }   // end of CONSISTENCY test function


            // function to return BENCHMARK result for different paths for each version
            BenchmarkResult RunBenchmarkTest(string startStation, string endStation, int testCycles)
            {
                // create a list to hold Versions to be tested
                List<ITestable> testables = new List<ITestable>();

                // create an instance of version 1, version 2 and Version 3
                testables.Add(new Version1(1));
                //testables.Add(new Version2());
                testables.Add(new Version3(3));

                // create a new result to populate with times
                BenchmarkResult results = new BenchmarkResult($"{startStation} to {endStation}");

                //// iterate through versions ////
                foreach (ITestable version in testables)
                {
                    // initialise a default time (to catch invalid result)
                    double averageTime = -1;

                    // catch and return any error from running application
                    try
                    {
                        // create new stopwatch
                        Stopwatch timer = new Stopwatch();

                        // run the test the requested number of times
                        for (int i = 0; i < testCycles; i++)
                        {
                            // start the timer
                            timer.Start();

                            // run the version with the start and finish stations
                            version.CalcualteShortestPath(startStation, endStation);

                            // stop the timer
                            timer.Stop();

                            double progress = 1 + (100 / testCycles) * i;
                            // display a progress 'bar'
                            if ((int)(progress) % 5 == 0)
                            {
                                Console.Write(".");
                            }

                        }

                        // get the timespan 
                        TimeSpan timeTaken = timer.Elapsed;

                        // get a float for the average per cycle
                        averageTime = timeTaken.TotalMilliseconds / testCycles;

                        Console.WriteLine($"Version {version.VersionNumber} execution: successful");
                        Console.WriteLine($"finished testing in {timeTaken.TotalSeconds} seconds...");

                        // add time taken per cycle to dictionary
                        results.AddTime(version.VersionNumber, averageTime);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Version {version.VersionNumber} execution: failed");
                        Console.WriteLine($"error message: {e.Message}");
                        results.AddTime(version.VersionNumber, averageTime);

                    } // end of try/catch exception

                } // end of iteration through vaersions

                Console.WriteLine($"Press any key to see the results:\n");
                Console.ReadKey();
                results.DisplayTimes();
                return results;

            }   // end of BENCHMARK test function


            // function to select a valid station
            string SelectStation()
            {
                string selection;
                while (true)
                {
                    Console.WriteLine("Input Station:");
                    string input = Console.ReadLine();

                    if (stations.Contains(input))
                    {
                        selection = input;
                        break;
                    }
                    Console.WriteLine("Invalid Input. Station Not Found.");
                }
                return selection;
            }

            // function to input valid number of tests
            void InputNumberOfTests()
            {
                int input;
                Console.WriteLine("Please enter an number between 1000 - 1000000: ");
                if (int.TryParse(Console.ReadLine(), out input) & (input >= 1000 && input <= 1000000))
                {
                    testCycles = input;
                }
            }

            // function to create Stations Dictionary
            void PopulateStationsList()
            {
                // reading csv file and instantiating objects to pass into dictionary
                using (var reader = new StreamReader("stations3.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        // names taken from csv file used to populate adjacency lists of app versions
                        string stationName = values[1];

                        if (!stations.Contains(stationName))
                        {
                            stations.Add(stationName);
                        }

                    }
                }
            } // end of populate stations

            void PrintStations()
            {
                stations.Sort();
                foreach (var station in stations)
                {
                    Console.WriteLine(station);
                }
            }

        } // end of MAIN()
    }
}