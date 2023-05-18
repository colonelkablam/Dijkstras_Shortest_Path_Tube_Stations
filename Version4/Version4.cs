using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Version4 : ITestable
    {
        private TubeStation[] stations;
        private Graph graph = new Graph();

        public int VersionNumber { get; }

        // constructor
        public Version4(int version)
        {
            //// ITestable - initialise name ////
            VersionNumber = version;

            stations = new TubeStation[]
            {
                new TubeStation(0, "Elephant and Castle", "Bakerloo" , "Northern"),
                new TubeStation(1, "Lambeth North", "Bakerloo"),
                new TubeStation(2, "Waterloo", "Bakerloo", "Jubilee", "Northern", "Waterloo & City"),
                new TubeStation(3, "Embankment", "Bakerloo" , "District",  "Northern"),
                new TubeStation(4, "Charing Cross", "Bakerloo", "Northern"),
                new TubeStation(5, "Piccadilly Circus", "Bakerloo", "Piccadilly"),
                new TubeStation(6, "Oxford Circus", "Bakerloo", "Central", "Victoria"),
                new TubeStation(7, "Regents Park", "Bakerloo"),
                new TubeStation(8, "Baker Street", "Bakerloo", "Hammersmith & City", "Jubilee", "Metropolitan"),
                new TubeStation(9, "Marylebone", "Bakerloo"),
                new TubeStation(10, "Edgware Road (Bakerloo Line)", "Bakerloo"),
                new TubeStation(11, "Notting Hill Gate", "Central", "District"),
                new TubeStation(12, "Queensway", "Central"),
                new TubeStation(13, "Lancaster Gate", "Central"),
                new TubeStation(14, "Marble Arch", "Central"),
                new TubeStation(15, "Bond Street", "Central", "Jubilee"),
                new TubeStation(16, "Tottenham Court Road", "Central", "Northern"),
                new TubeStation(17, "Holborn", "Central", "Piccadilly"),
                new TubeStation(18, "Chancery Lane", "Central"),
                new TubeStation(19, "St Pauls", "Central"),
                new TubeStation(20, "Bank", "Central", "Northern", "Waterloo & City"),
                new TubeStation(21, "Tower Hill", "Circle", "District"),
                new TubeStation(22, "Edgware Road (Circle Line)","Circle", "District", "Hammersmith & City"),
                new TubeStation(23, "Paddington", "Circle", "District", "Bakerloo"),
                new TubeStation(24, "Bayswater", "Circle", "District"),
                new TubeStation(25, "High Street Kensington", "Circle", "District"),
                new TubeStation(26, "Earls Court", "Circle", "District", "Piccadilly"),
                new TubeStation(27, "Gloucester Road", "Circle", "District"),
                new TubeStation(28, "South Kensington", "Circle", "District"),
                new TubeStation(29, "Sloane Square", "Circle", "District"),
                new TubeStation(30, "Victoria", "Circle", "District", "Victoria"),
                new TubeStation(31, "St James Park", "Circle", "District"),
                new TubeStation(32, "Westminster", "Circle", "District", "Jubilee"),
                new TubeStation(33, "Temple", "Circle", "District"),
                new TubeStation(34, "Blackfriars", "Circle", "District"),
                new TubeStation(35, "Mansion House", "Circle", "District"),
                new TubeStation(36, "Cannon Street", "Circle", "District"),
                new TubeStation(37, "Monument", "Circle", "District"),
                new TubeStation(38, "Aldgate East", "District", "Hammersmith & City"),
                new TubeStation(39, "Aldgate", "Circle", "Metropolitan"),
                new TubeStation(40, "Liverpool Street", "Central", "Hammersmith & City", "Metropolitan", "Circle"),
                new TubeStation(41, "Green Park", "Jubilee", "Piccadilly", "Victoria"),
                new TubeStation(42, "Southwark", "Jubilee"),
                new TubeStation(43, "London Bridge", "Jubilee", "Northern"),
                new TubeStation(44, "Euston Square", "Metropolitan", "Circle", "Hammersmith & City"),
                new TubeStation(45, "Kings Cross St Pancras", "Metropolitan", "Northern", "Piccadilly", "Victoria", "Circle", "Hammersmith & City"),
                new TubeStation(46, "Great Portland Street", "Metropolitan", "Circle", "Hammersmith & City"),
                new TubeStation(47, "Warren Street", "Northern", "Victoria"),
                new TubeStation(48, "Goodge Street", "Northern"),
                new TubeStation(49, "Leicester Square", "Northern", "Piccadilly"),
                new TubeStation(50, "Borough", "Northern"),
                new TubeStation(51, "Moorgate", "Northern", "Central", "Metropolitan", "Hammersmith & City"),
                new TubeStation(52, "Old Street", "Northern"),
                new TubeStation(53, "Angel", "Northern"),
                new TubeStation(54, "Euston", "Northern", "Victoria"),
                new TubeStation(55, "Russell Square", "Piccadilly"),
                new TubeStation(56, "Covent Garden", "Piccadilly"),
                new TubeStation(57, "Hyde Park Corner", "Piccadilly"),
                new TubeStation(58, "Knightsbridge", "Piccadilly"),
                new TubeStation(59, "Pimlico", "Victoria"),
                new TubeStation(60, "Vauxhall", "Victoria"),
                new TubeStation(61, "Barbican", "Metropolitan", "Circle", "Hammersmith & City"),
                new TubeStation(62, "Farringdon", "Metropolitan", "Circle", "Hammersmith & City")

            };


            // Then you add edges to the graph like so:
            graph.AddEdge(stations[0], stations[1], 18);
            graph.AddEdge(stations[1], stations[2], 9);
            graph.AddEdge(stations[2], stations[3], 6);
            graph.AddEdge(stations[3], stations[4], 3);
            graph.AddEdge(stations[4], stations[5], 11);
            graph.AddEdge(stations[5], stations[6], 12);
            graph.AddEdge(stations[6], stations[7], 15);
            graph.AddEdge(stations[7], stations[8], 10);
            graph.AddEdge(stations[8], stations[9], 6);
            graph.AddEdge(stations[9], stations[10], 7);

            graph.AddEdge(stations[10], stations[23], 11);
            graph.AddEdge(stations[11], stations[12], 8);
            graph.AddEdge(stations[12], stations[13], 10);
            graph.AddEdge(stations[13], stations[14], 15);
            graph.AddEdge(stations[14], stations[15], 7);
            graph.AddEdge(stations[15], stations[6], 7);
            graph.AddEdge(stations[6], stations[16], 9);
            graph.AddEdge(stations[16], stations[17], 10);
            graph.AddEdge(stations[17], stations[18], 8);
            graph.AddEdge(stations[18], stations[19], 14);

            graph.AddEdge(stations[19], stations[20], 9);
            graph.AddEdge(stations[20], stations[40], 10);
            graph.AddEdge(stations[21], stations[39], 9);
            graph.AddEdge(stations[22], stations[23], 10);
            graph.AddEdge(stations[23], stations[24], 17);
            graph.AddEdge(stations[24], stations[11], 10);
            graph.AddEdge(stations[11], stations[25], 13);
            graph.AddEdge(stations[25], stations[26], 18);
            graph.AddEdge(stations[26], stations[27], 12);
            graph.AddEdge(stations[27], stations[28], 8);

            graph.AddEdge(stations[28], stations[29], 17);
            graph.AddEdge(stations[29], stations[30], 13);
            graph.AddEdge(stations[30], stations[31], 11);
            graph.AddEdge(stations[31], stations[32], 11);
            graph.AddEdge(stations[32], stations[3], 10);
            graph.AddEdge(stations[3], stations[33], 9);
            graph.AddEdge(stations[33], stations[34], 10);
            graph.AddEdge(stations[34], stations[35], 10);
            graph.AddEdge(stations[35], stations[36], 4);
            graph.AddEdge(stations[36], stations[37], 5);

            graph.AddEdge(stations[37], stations[21], 10);
            graph.AddEdge(stations[21], stations[38], 10);
            graph.AddEdge(stations[22], stations[8], 10);
            graph.AddEdge(stations[40], stations[38], 11);
            graph.AddEdge(stations[8], stations[15], 16);
            graph.AddEdge(stations[15], stations[41], 14);
            graph.AddEdge(stations[41], stations[32], 21);
            graph.AddEdge(stations[32], stations[2], 17);
            graph.AddEdge(stations[2], stations[42], 8);
            graph.AddEdge(stations[42], stations[43], 19);

            graph.AddEdge(stations[44], stations[45], 15);
            graph.AddEdge(stations[39], stations[40], 9);
            graph.AddEdge(stations[40], stations[51], 6);
            graph.AddEdge(stations[51], stations[61], 10);
            graph.AddEdge(stations[61], stations[62], 8);
            graph.AddEdge(stations[62], stations[45], 26);
            graph.AddEdge(stations[45], stations[44], 15);
            graph.AddEdge(stations[44], stations[46], 10);
            graph.AddEdge(stations[46], stations[8], 13);
            graph.AddEdge(stations[47], stations[48], 7);

            graph.AddEdge(stations[48], stations[16], 7);
            graph.AddEdge(stations[16], stations[49], 8);
            graph.AddEdge(stations[49], stations[4], 7);
            graph.AddEdge(stations[0], stations[50], 13);
            graph.AddEdge(stations[50], stations[43], 9);
            graph.AddEdge(stations[43], stations[20], 6);
            graph.AddEdge(stations[20], stations[51], 9);
            graph.AddEdge(stations[51], stations[52], 9);
            graph.AddEdge(stations[52], stations[53], 20);
            graph.AddEdge(stations[53], stations[45], 16);

            graph.AddEdge(stations[45], stations[54], 12);
            graph.AddEdge(stations[45], stations[55], 14);
            graph.AddEdge(stations[55], stations[17], 9);
            graph.AddEdge(stations[17], stations[56], 8);
            graph.AddEdge(stations[56], stations[49], 4);
            graph.AddEdge(stations[49], stations[5], 6);
            graph.AddEdge(stations[5], stations[41], 8);
            graph.AddEdge(stations[41], stations[57], 12);
            graph.AddEdge(stations[57], stations[58], 7);
            graph.AddEdge(stations[58], stations[28], 17);

            graph.AddEdge(stations[54], stations[47], 9);
            graph.AddEdge(stations[47], stations[6], 18);
            graph.AddEdge(stations[6], stations[41], 15);
            graph.AddEdge(stations[41], stations[30], 19);
            graph.AddEdge(stations[30], stations[59], 12);
            graph.AddEdge(stations[59], stations[60], 18);
            graph.AddEdge(stations[2], stations[20], 33);

        }

        public JourneyLinkedList CalcualteShortestPath(string start, string end)
        {

            int sourceID = TubeStation.GetStationIDByName(stations, start);
            TubeStation sourcestation = stations[sourceID];

            int destinationID = TubeStation.GetStationIDByName(stations, end);
            TubeStation destinationstation = stations[destinationID];

            // Now you can run Dijkstra's algorithm
            JourneyLinkedList route = graph.Dijkstra(sourcestation, destinationstation, VersionNumber);


            return route;

        }
    }
}
