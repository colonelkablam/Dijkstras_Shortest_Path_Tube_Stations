using System.Diagnostics;  // StopWatch + TimeSpan

// May 2023
// Nick Harding w19249722 UoW DSaA Courswork 7SENG010W_CW
// Testing and benchmarking program for three different versions of Dijkstra's Shortest Path Algo

namespace Testing
{
    public class Program
    {
        static void Main(string[] args)
        {   
            // Sync console and file writer for logging use of program //
            // Create a StreamWriter object to write to the log file
            StreamWriter fileWriter = new StreamWriter("use_log.txt");
            // Create a synchronized writer for the console
            TextWriter consoleWriter = TextWriter.Synchronized(Console.Out);
            // Create a synchronized writer for the file writer
            TextWriter fileSync = TextWriter.Synchronized(fileWriter);
            // Redirect the standard output stream to console and the file log
            Console.SetOut(new WriteToFile(consoleWriter, fileSync));


                            /////////////// MAIN TESTING PROG ///////////////////            

            // List to hold all stations names
            List<string> stations = new List<string>();

            // call function to populate stations dictionary from csv file
            PopulateStationsList();

            // create a list to hold Versions to be tested
            List<ITestable> testables = new List<ITestable>();

            // create an instance of version 1,2 and 3 and add to ITestable list
            testables.Add(new Version1(1));
            testables.Add(new Version2(2));
            testables.Add(new Version3(3));

            // new version to be tested
            testables.Add(new Version4(4));

            // start and finish default stations
            string startStation = "Baker Street";
            string endStation = "Tower Hill";

            // number of tests to run default
            int testCycles = 10000;

            // create results storage objects
            BenchmarkingResults benchmarkingResults = new BenchmarkingResults();
            ConsistencyResults consistencyResults = new ConsistencyResults();

            // start the menu
            bool exit = false;

            // menu loop to get inputs and run tests
            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine("******************************************************");
                Console.WriteLine("         Testing Different Implementations of");
                Console.WriteLine("      >>  Dijkstra's Shortest Path Algorithm  <<");
                Console.WriteLine("          CONSISTENCY check and BENCHMARKING");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("                                     current:");
               Console.WriteLine($"1. Change the START station        > {startStation}");
               Console.WriteLine($"2. Change the END station          > {endStation}");
               Console.WriteLine($"3. Change number of test cycles    > {testCycles}");
                Console.WriteLine();
                Console.WriteLine("4. Run a CONSISTENCY test");
               Console.WriteLine($"5.   - Display results log ({consistencyResults.GetNumTests()})");
                Console.WriteLine();
                Console.WriteLine("6. Run a BENCHMARKING test");
               Console.WriteLine($"7.   - Display results log ({benchmarkingResults.GetNumTests()})");
                Console.WriteLine();
                Console.WriteLine("8. Print results tables to txt file");
                Console.WriteLine("9. Clear results");
                Console.WriteLine("10. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice (1-10): \n");

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
                        Console.WriteLine("////////////////////////////");
                        Console.WriteLine("Running Consistency Test...");
                        Console.WriteLine("////////////////////////////");

                        // runs a consistencey test testult
                        List<JourneyLinkedList> result = RunConsistencyTest(startStation, endStation);
                        // add it to main results
                        consistencyResults.AddRoutes(consistencyResults.GetNumTests() + 1, result, $"{startStation} - {endStation}");
                        
                        Console.WriteLine($"\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    // DISPLAY TABLE OF CONSISTENCY RESULTS
                    case 5:
                        Console.Clear();
                        consistencyResults.DisplayResultsTable();
                        Console.WriteLine($"\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    // BENCHMARKING TEST
                    case 6:
                        Console.Clear();
                        Console.WriteLine("////////////////////////////");
                        Console.WriteLine("Running Benchmarking Test...");
                        Console.WriteLine("////////////////////////////");

                        // returns a BenchmarkResult object array
                        benchmarkingResults.AddResult(RunBenchmarkTest(startStation, endStation, testCycles));
                        
                        Console.WriteLine($"\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    // DISPLAY TABLE OF BENCHMARK RESULTS
                    case 7:
                        Console.Clear();
                        benchmarkingResults.DisplayResultsTable();
                        Console.WriteLine($"\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    // PRINT RESULTS TO .TXT FILE
                    case 8:
                        Console.Clear();
                        PrintAllLogs();
                        Console.ReadKey();
                        break;

                    // CLEAR RESULTS
                    case 9:
                        benchmarkingResults.ClearLog();
                        consistencyResults.ClearLog();
                        Console.Clear();
                        Console.WriteLine("Results logs cleared, press any key to return to main menu...");
                        Console.ReadKey();
                        break;

                    // EXIT
                    case 10:
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
                        Console.WriteLine();
                        Console.WriteLine($"Version {version.VersionNumber} execution: successful");
                    }
                    catch (Exception e)
                    {
                        JourneyLinkedList failedPath = new JourneyLinkedList(version.VersionNumber);
                        results.Add(failedPath);
                        Console.WriteLine($"Version {version.VersionNumber} execution: failed");
                        Console.WriteLine($"error message: {e.Message}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Press any key to see the results:\n");
                Console.ReadKey();
                Console.Clear();
                foreach (JourneyLinkedList route in results)
                {
                    route.DisplayAll();
                }
                return results;

            }   // end of CONSISTENCY test function


            // function to return BENCHMARK result for different paths for each version
            BenchmarkResult RunBenchmarkTest(string startStation, string endStation, int cycles)
            {
                // create a new result to populate with times
                BenchmarkResult results = new BenchmarkResult($"{startStation} to {endStation}", cycles);

                Console.WriteLine($"Number of cycles - {cycles}\n");

                //// iterate through versions ////
                foreach (ITestable version in testables)
                {
                    // initialise a default time (to catch invalid result)
                    double averageTime = -1;
                    // progress monitoring
                    double progress = 0;

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

                            // calculate and display progress
                            progress = (1 / (double)testCycles) * (i+1);
                            Console.Write($"\rProgress: {progress.ToString("P2")}");
                        }

                        // get the timespan 
                        TimeSpan timeTaken = timer.Elapsed;

                        // get a float for the average per cycle
                        averageTime = timeTaken.TotalMilliseconds / testCycles;

                        Console.WriteLine();
                        Console.WriteLine($"\nVersion {version.VersionNumber} execution: successful");
                        Console.WriteLine($"finished executing in {timeTaken.TotalSeconds.ToString("F2")} seconds...");

                        // add time taken per cycle to dictionary
                        results.AddTime(version.VersionNumber, averageTime);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Version {version.VersionNumber} execution: failed");
                        Console.WriteLine($"error message: {e.Message}");
                        results.AddTime(version.VersionNumber, averageTime);
                    } // end of try/catch exception
                    Console.WriteLine();

                } // end of iteration through vaersions
                Console.WriteLine($"Press any key to see the results:\n");
                Console.ReadKey();
                Console.Clear();
                results.DisplayTimes();
                return results;

            }   // end of BENCHMARK test function


            // function to select a valid station
            string SelectStation()
            {
                string selection;
                while (true)
                {
                    Console.WriteLine("Input Station (type 'list' to see stations):");
                    string input = Console.ReadLine();

                    if (input == "list")
                    {
                        PrintStations();
                        continue;
                    }
                    else if(stations.Contains(input))
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
                Console.WriteLine("Please enter an number between 1 - 1,000,000: ");
                if (int.TryParse(Console.ReadLine(), out input) & (input >= 1 && input <= 1000000))
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
                        // need to and from stations (due to the format of the csv file
                        string stationName1 = values[1];
                        string stationName2 = values[2];

                        // check both from and to stations in csv to get all names
                        if (!stations.Contains(stationName1))
                        {
                            stations.Add(stationName1);
                        }
                        if (!stations.Contains(stationName2))
                        {
                            stations.Add(stationName2);
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

            // create log txt files of results
            void PrintAllLogs()
            {
                Console.WriteLine("\nPlease enter a txt file name (no need for '.txt'): ");
                string input = Console.ReadLine();
                // strip the puctuation
                string fileName = PunctStrip.fileName(input);
                // format the sring
                string logName = string.Format("{0}_{1:yyyy-MM-dd}.txt", fileName, DateTime.Now);

                // Create a StreamWriter object to write to the log file
                StreamWriter logWriter = new StreamWriter(logName);
                // Create a synchronized writer for the file writer
                TextWriter log = TextWriter.Synchronized(logWriter);
                // Redirect the standard output stream to console and the file log
                Console.SetOut(new WriteToFile(log));

                // display logs
                Console.WriteLine("CONSISTENCY LOG:\n");
                benchmarkingResults.DisplayResultsTable();
                Console.WriteLine("BENCHMARKING LOG:\n");
                consistencyResults.DisplayResultsTable();

                // Close console and file sync //
                // Restore the standard output stream to the console and use log
                Console.SetOut(new WriteToFile(fileSync, consoleWriter));
                // Close the file writer
                logWriter.Close();
                Console.WriteLine($"File saved to {logName}, press any key to continue...");
            }

            // Close console and file sync //
            // Restore the standard output stream to the console
            Console.SetOut(consoleWriter);
            // Close the file writer
            fileWriter.Close();

        } // end of MAIN()
    }
}