﻿using Adjacency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Version2 : ITestable
    {
        //// ITestable name added ////
        public int VersionNumber { get; }

        private int numVertices = 64;
        WeightedEdge[] adjacencyList;
        WeightedEdge[] edges;
        private int[] distTo;

        public Version2(int version)
        {
            //// Itesable - version number needed ////
            this.VersionNumber = version;

            //Initialising Adjacency List
            adjacencyList = new WeightedEdge[numVertices];
            //Initalising edges array
            edges = new WeightedEdge[numVertices];
            //Initialising Dist To array and setting all values to max
            distTo = new int[numVertices];
            GenerateAdjacencyList();
        }

        public JourneyLinkedList CalcualteShortestPath(string start, string end)
        {
            DijkstraShortestPath Dijkstra = new DijkstraShortestPath();

            JourneyLinkedList results = Dijkstra.DijkstraMethod(start, end, adjacencyList, edges, distTo, VersionNumber);

            return results;
        }

        public void GenerateAdjacencyList()
        {
            adjacencyList[0] = new WeightedEdge("Aldgate", "Liverpool Street", 9, "Metropolitan", null);
            WeightedEdge aldgate = new WeightedEdge("Aldgate", "Tower Hill", 9, "Circle", null);
            adjacencyList[0].Next = aldgate;
            adjacencyList[1] = new WeightedEdge("Angel", "Kings Cross St Pancras", 16, "Northern", null);
            WeightedEdge angel = new WeightedEdge("Angel", "Old Street", 20, "Northern", null);
            adjacencyList[1].Next = angel;
            adjacencyList[2] = new WeightedEdge("Baker Street", "Marylebone", 6, "Bakerloo", null);
            WeightedEdge baker = new WeightedEdge("Baker Street", "Bond Street", 16, "Jubilee", null);
            adjacencyList[2].Next = baker;
            WeightedEdge baker2 = new WeightedEdge("Baker Street", "Regents Park", 10, "Bakerloo", null);
            baker.Next = baker2;
            WeightedEdge baker3 = new WeightedEdge("Baker Street", "Edgware Road (Circle Line)", 10, "Hammersmith & City", null);
            baker2.Next = baker3;
            WeightedEdge baker4 = new WeightedEdge("Baker Street", "Great Portland Street", 13, "Metropolitan", null);
            baker3.Next = baker4;

            adjacencyList[3] = new WeightedEdge("Bank", "Liverpool Street", 10, "Central", null);
            WeightedEdge bank = new WeightedEdge("Bank", "Moorgate", 9, "Northern", null);
            adjacencyList[3].Next = bank;
            WeightedEdge bank2 = new WeightedEdge("Bank", "St Pauls", 9, "Central", null);
            bank.Next = bank2;
            WeightedEdge bank3 = new WeightedEdge("Bank", "London Bridge", 6, "Northern", null);
            bank2.Next = bank3;
            WeightedEdge bank4 = new WeightedEdge("Bank", "Waterloo", 33, "Waterloo & City", null);
            bank3.Next = bank4;
            adjacencyList[4] = new WeightedEdge("Barbican", "Farringdon", 8, "Metropolitan", null);
            WeightedEdge barbican = new WeightedEdge("Barbican", "Moorgate", 10, "Metropolitan", null);
            adjacencyList[4].Next = barbican;
            adjacencyList[5] = new WeightedEdge("Bayswater", "Notting Hill Gate", 10, "District", null);
            WeightedEdge bayswater = new WeightedEdge("Bayswater", "Paddington", 17, "District", null);
            adjacencyList[5].Next = bayswater;
            adjacencyList[6] = new WeightedEdge("Blackfriars", "Mansion House", 10, "District", null);
            WeightedEdge blackfriars = new WeightedEdge("Blackfriars", "Temple", 10, "District", null);
            adjacencyList[6].Next = blackfriars;
            adjacencyList[7] = new WeightedEdge("Bond Street", "Oxford Circus", 7, "Central", null);
            WeightedEdge bond = new WeightedEdge("Bond Street", "Green Park", 14, "Jubilee", null);
            adjacencyList[7].Next = bond;
            WeightedEdge bond2 = new WeightedEdge("Bond Street", "Marble Arch", 7, "Central", null);
            bond.Next = bond2;
            WeightedEdge bond3 = new WeightedEdge("Bond Street", "Baker Street", 16, "Jubilee", null);
            bond2.Next = bond3;
            adjacencyList[8] = new WeightedEdge("Borough", "London Bridge", 9, "Northern", null);
            WeightedEdge borough = new WeightedEdge("Borough", "Elephant and Castle", 13, "Northern", null);
            adjacencyList[8].Next = borough;
            adjacencyList[9] = new WeightedEdge("Cannon Street", "Monument", 5, "District", null);
            WeightedEdge cannonstreet = new WeightedEdge("Cannon Street", "Mansion House", 4, "District", null);
            adjacencyList[9].Next = cannonstreet;
            adjacencyList[10] = new WeightedEdge("Chancery Lane", "St Pauls", 14, "Central", null);
            WeightedEdge chancerylane = new WeightedEdge("Chancery Lane", "Holborn", 8, "Central", null);
            adjacencyList[10].Next = chancerylane;
            adjacencyList[11] = new WeightedEdge("Charing Cross", "Piccadilly Circus", 11, "Bakerloo", null);
            WeightedEdge charingcross = new WeightedEdge("Charing Cross", "Embankment", 3, "Northern", null);
            adjacencyList[11].Next = charingcross;
            WeightedEdge charingcross2 = new WeightedEdge("Charing Cross", "Leicester Square", 7, "Northern", null);
            charingcross.Next = charingcross2;
            adjacencyList[12] = new WeightedEdge("Covent Garden", "Leicester Square", 4, "Piccadilly", null);
            WeightedEdge coventgarden = new WeightedEdge("Covent Garden", "Holborn", 8, "Piccadilly", null);
            adjacencyList[12].Next = coventgarden;
            adjacencyList[13] = new WeightedEdge("Earls Court", "Gloucester Road", 12, "District", null);
            WeightedEdge earlscourt = new WeightedEdge("Earls Court", "High Street Kensington", 18, "District", null);
            adjacencyList[13].Next = earlscourt;

            adjacencyList[14] = new WeightedEdge("Edgware Road (Bakerloo Line)", "Paddington", 11, "Bakerloo", null);           // added an extra vertex for Edgware Rd (Circle line)
            WeightedEdge edgwareroad = new WeightedEdge("Edgware Road (Bakerloo Line)", "Marylebone", 7, "Bakerloo", null);     // 
            adjacencyList[14].Next = edgwareroad;

            adjacencyList[63] = new WeightedEdge("Edgware Road (Circle Line)", "Baker Street", 10, "Hammersmith & City", null); // 
            WeightedEdge edgwareroad2 = new WeightedEdge("Edgware Road (Circle Line)", "Paddington", 10, "District", null);     // 
            adjacencyList[63].Next = edgwareroad2;

            adjacencyList[15] = new WeightedEdge("Elephant & Castle", "Lambeth North", 18, "Bakerloo", null);
            WeightedEdge elephantcastle = new WeightedEdge("Elephant & Castle", "Borough", 13, "Northern", null);
            adjacencyList[15].Next = elephantcastle;
            adjacencyList[16] = new WeightedEdge("Embankment", "Charing Cross", 3, "Bakerloo", null);
            WeightedEdge embankment = new WeightedEdge("Embankment", "Temple", 9, "District", null);
            adjacencyList[16].Next = embankment;
            WeightedEdge embankment2 = new WeightedEdge("Embankment", "Waterloo", 6, "Northern", null);
            embankment.Next = embankment2;
            WeightedEdge embankment3 = new WeightedEdge("Embankment", "Westminster", 10, "District", null);
            embankment2.Next = embankment3;
            adjacencyList[17] = new WeightedEdge("Euston", "Warren Street", 9, "Victoria", null);
            WeightedEdge euston = new WeightedEdge("Euston", "Kings Cross St Pancras", 12, "Northern", null);
            adjacencyList[17].Next = euston;
            adjacencyList[18] = new WeightedEdge("Euston Square", "Kings Cross St Pancras", 15, "Metropolitan", null);
            WeightedEdge eustonsquare = new WeightedEdge("Euston Square", "Great Portland Street", 10, "Metropolitan", null);
            adjacencyList[18].Next = eustonsquare;
            adjacencyList[19] = new WeightedEdge("Farringdon", "Kings Cross St Pancras", 26, "Metropolitan", null);
            WeightedEdge farringdon = new WeightedEdge("Farringdon", "Barbican", 8, "Metropolitan", null);
            adjacencyList[19].Next = farringdon;
            adjacencyList[20] = new WeightedEdge("Gloucester Road", "South Kensington", 8, "District", null);
            WeightedEdge gloucesterroad = new WeightedEdge("Gloucester Road", "Earls Court", 12, "District", null);
            adjacencyList[20].Next = gloucesterroad;
            adjacencyList[21] = new WeightedEdge("Goodge Street", "Tottenham Court Road", 7, "Northern", null);
            WeightedEdge goodgestreet = new WeightedEdge("Goodge Street", "Warren Street", 12, "Northern", null);
            adjacencyList[21].Next = goodgestreet;
            adjacencyList[22] = new WeightedEdge("Great Portland Street", "Baker Street", 13, "Metropolitan", null);
            WeightedEdge greatportlandstreet = new WeightedEdge("Great Portland Street", "Euston Square", 10, "Metropolitan", null);
            adjacencyList[22].Next = greatportlandstreet;
            adjacencyList[23] = new WeightedEdge("Green Park", "Westminster", 21, "Jubilee", null);
            WeightedEdge greenpark = new WeightedEdge("Green Park", "Hyde Park Corner", 12, "Piccadilly", null);
            adjacencyList[23].Next = greenpark;
            WeightedEdge greenpark2 = new WeightedEdge("Green Park", "Victoria", 19, "Victoria", null);
            greenpark.Next = greenpark2;
            WeightedEdge greenpark3 = new WeightedEdge("Green Park", "Bond Street", 14, "Jubilee", null);
            greenpark2.Next = greenpark3;
            WeightedEdge greenpark4 = new WeightedEdge("Green Park", "Piccadilly Circus", 8, "Piccadilly", null);
            greenpark3.Next = greenpark4;
            WeightedEdge greenpark5 = new WeightedEdge("Green Park", "Oxford Circus", 15, "Victoria", null);
            greenpark4.Next = greenpark5;
            adjacencyList[24] = new WeightedEdge("High Street Kensington", "Earls Court", 18, "District", null);
            WeightedEdge highstreetkensington = new WeightedEdge("High Street Kensington", "Notting Hill Gate", 13, "District", null);
            adjacencyList[24].Next = highstreetkensington;
            adjacencyList[25] = new WeightedEdge("Holborn", "Chancery Lane", 8, "Central", null);
            WeightedEdge holborn = new WeightedEdge("Holborn", "Covent Garden", 8, "Piccadilly", null);
            adjacencyList[25].Next = holborn;
            WeightedEdge holborn2 = new WeightedEdge("Holborn", "Tottenham Court Road", 10, "Central", null);
            holborn.Next = holborn2;
            WeightedEdge holborn3 = new WeightedEdge("Holborn", "Russell Square", 9, "Piccadilly", null);
            holborn2.Next = holborn3;
            adjacencyList[26] = new WeightedEdge("Hyde Park Corner", "Knightsbridge", 7, "Piccadilly", null);
            WeightedEdge hydeparkcorner = new WeightedEdge("Hyde Park Corner", "Green Park", 12, "Piccadilly", null);
            adjacencyList[26].Next = hydeparkcorner;
            adjacencyList[27] = new WeightedEdge("Kings Cross St Pancras", "Euston Square", 15, "Metropolitan", null);
            WeightedEdge kingsx = new WeightedEdge("Kings Cross St Pancras", "Euston", 12, "Northern", null);
            adjacencyList[27].Next = kingsx;
            WeightedEdge kingsx2 = new WeightedEdge("Kings Cross St Pancras", "Russell Square", 14, "Piccadilly", null);
            kingsx.Next = kingsx2;
            WeightedEdge kingsx3 = new WeightedEdge("Kings Cross St Pancras", "Farringdon", 26, "Metropolitan", null);
            kingsx2.Next = kingsx3;
            WeightedEdge kingsx4 = new WeightedEdge("Kings Cross St Pancras", "Angel", 16, "Northern", null);
            kingsx3.Next = kingsx4;
            adjacencyList[28] = new WeightedEdge("Knightsbridge", "South Kensington", 17, "Piccadilly", null);
            WeightedEdge knightsbridge = new WeightedEdge("Knightsbridge", "Hyde Park Corner", 7, "Piccadilly", null);
            adjacencyList[28].Next = knightsbridge;
            adjacencyList[29] = new WeightedEdge("Lambeth North", "Waterloo", 9, "Bakerloo", null);
            WeightedEdge lambethnorth = new WeightedEdge("Lambeth North", "Elephant & Castle", 18, "Bakerloo", null);
            adjacencyList[29].Next = lambethnorth;
            adjacencyList[30] = new WeightedEdge("Lancaster Gate", "Marble Arch", 15, "Central", null);
            WeightedEdge lancastergate = new WeightedEdge("Lancaster Gate", "Queensway", 10, "Central", null);
            adjacencyList[30].Next = lancastergate;
            adjacencyList[31] = new WeightedEdge("Leicester Square", "Charing Cross", 7, "Northern", null);
            WeightedEdge leicestersquare = new WeightedEdge("Leicester Square", "Piccadilly Circus", 6, "Piccadilly", null);
            adjacencyList[31].Next = leicestersquare;
            WeightedEdge leicestersquare2 = new WeightedEdge("Leicester Square", "Tottenham Court Road", 8, "Northern", null);
            leicestersquare.Next = leicestersquare2;
            WeightedEdge leicestersquare3 = new WeightedEdge("Leicester Square", "Covent Garden", 4, "Piccadilly", null);
            leicestersquare2.Next = leicestersquare3;
            adjacencyList[32] = new WeightedEdge("Liverpool Street", "Aldgate East", 11, "Hammersmith & City", null);
            WeightedEdge liverpoolstreet = new WeightedEdge("Liverpool Street", "Moorgate", 6, "Metropolitan", null);
            adjacencyList[32].Next = liverpoolstreet;
            WeightedEdge liverpoolstreet2 = new WeightedEdge("Liverpool Street", "Bank", 10, "Central", null);
            liverpoolstreet.Next = liverpoolstreet2;
            WeightedEdge liverpoolstreet3 = new WeightedEdge("Liverpool Street", "Aldgate", 9, "Metropolitan", null);
            liverpoolstreet2.Next = liverpoolstreet3;
            adjacencyList[33] = new WeightedEdge("London Bridge", "Bank", 6, "Northern", null);
            WeightedEdge londonbridge = new WeightedEdge("London Bridge", "Southwark", 19, "Jubilee", null);
            adjacencyList[33].Next = londonbridge;
            WeightedEdge londonbridge2 = new WeightedEdge("London Bridge", "Borough", 9, "Northern", null);
            londonbridge.Next = londonbridge2;
            adjacencyList[34] = new WeightedEdge("Mansion House", "Cannon Street", 4, "District", null);
            WeightedEdge mansionhouse = new WeightedEdge("Mansion House", "Blackfriars", 10, "District", null);
            adjacencyList[34].Next = mansionhouse;
            adjacencyList[35] = new WeightedEdge("Marble Arch", "Bond Street", 7, "Central", null);
            WeightedEdge marblearch = new WeightedEdge("Marble Arch", "Lancaster Gate", 15, "Central", null);
            adjacencyList[35].Next = marblearch;
            adjacencyList[36] = new WeightedEdge("Marylebone", "Edgware Road (Bakerloo Line)", 7, "Bakerloo", null); // (Bakerloo Line) added
            WeightedEdge marylebone = new WeightedEdge("Marylebone", "Baker Street", 6, "Bakerloo", null);
            adjacencyList[36].Next = marylebone;
            adjacencyList[37] = new WeightedEdge("Monument", "Tower Hill", 10, "District", null);
            WeightedEdge monument = new WeightedEdge("Monument", "Cannon Street", 5, "District", null);
            adjacencyList[37].Next = monument;
            adjacencyList[38] = new WeightedEdge("Moorgate", "Barbican", 10, "Metropolitan", null);
            WeightedEdge moorgate = new WeightedEdge("Moorgate", "Old Street", 9, "Northern", null);
            adjacencyList[38].Next = moorgate;
            WeightedEdge moorgate2 = new WeightedEdge("Moorgate", "Liverpool Street", 6, "Metropolitan", null);
            moorgate.Next = moorgate2;
            WeightedEdge moorgate3 = new WeightedEdge("Moorgate", "Bank", 9, "Northern", null);
            moorgate2.Next = moorgate3;
            adjacencyList[39] = new WeightedEdge("Notting Hill Gate", "Queensway", 8, "Central", null);
            WeightedEdge nottinghill = new WeightedEdge("Notting Hill Gate", "Holland Park", 10, "Central", null);
            adjacencyList[39].Next = nottinghill;
            WeightedEdge nottinghill2 = new WeightedEdge("Notting Hill Gate", "High Street Kensington", 13, "District", null);
            nottinghill.Next = nottinghill2;
            WeightedEdge nottinghill3 = new WeightedEdge("Notting Hill Gate", "Bayswater", 10, "District", null);
            nottinghill2.Next = nottinghill3;
            adjacencyList[40] = new WeightedEdge("Old Street", "Angel", 20, "Northern", null);
            WeightedEdge oldstreet = new WeightedEdge("Old Street", "Moorgate", 9, "Northern", null);
            adjacencyList[40].Next = oldstreet;
            adjacencyList[41] = new WeightedEdge("Oxford Circus", "Regents Park", 15, "Bakerloo", null);
            WeightedEdge oxfordcircus = new WeightedEdge("Oxford Circus", "Tottenham Court Road", 9, "Central", null);
            adjacencyList[41].Next = oxfordcircus;
            WeightedEdge oxfordcircus2 = new WeightedEdge("Oxford Circus", "Green Park", 15, "Victoria", null);
            oxfordcircus.Next = oxfordcircus2;
            WeightedEdge oxfordcircus3 = new WeightedEdge("Oxford Circus", "Piccadilly Circus", 12, "Bakerloo", null);
            oxfordcircus2.Next = oxfordcircus3;
            WeightedEdge oxfordcircus4 = new WeightedEdge("Oxford Circus", "Bond Street", 7, "Central", null);
            oxfordcircus3.Next = oxfordcircus4;
            WeightedEdge oxfordcircus5 = new WeightedEdge("Oxford Circus", "Warren Street", 18, "Victoria", null);
            oxfordcircus4.Next = oxfordcircus5;

            adjacencyList[42] = new WeightedEdge("Paddington", "Bayswater", 17, "District", null);
            WeightedEdge paddington = new WeightedEdge("Paddington", "Edgware Road (Circle Line)", 10, "Hammersmith & City", null); /// 
            adjacencyList[42].Next = paddington;
            WeightedEdge paddington2 = new WeightedEdge("Paddington", "Edgware Road (Bakerloo Line)", 11, "Bakerloo", null); 
            adjacencyList[42].Next = paddington2;


            adjacencyList[43] = new WeightedEdge("Piccadilly Circus", "Oxford Circus", 12, "Bakerloo", null);
            WeightedEdge piccadillycircus = new WeightedEdge("Piccadilly Circus", "Green Park", 8, "Piccadilly", null);
            adjacencyList[43].Next = piccadillycircus;
            WeightedEdge piccadillycircus2 = new WeightedEdge("Piccadilly Circus", "Charing Cross", 11, "Bakerloo", null);
            piccadillycircus.Next = piccadillycircus2;
            WeightedEdge piccadillycircus3 = new WeightedEdge("Piccadilly Circus", "Leicester Square", 6, "Piccadilly", null);
            piccadillycircus2.Next = piccadillycircus3;
            adjacencyList[44] = new WeightedEdge("Pimlico", "Vauxhall", 18, "Victoria", null);
            WeightedEdge pimlico = new WeightedEdge("Pimlico", "Victoria", 12, "Victoria", null);
            adjacencyList[44].Next = pimlico;
            adjacencyList[45] = new WeightedEdge("Queensway", "Lancaster Gate", 10, "Central", null);
            WeightedEdge queensway = new WeightedEdge("Queensway", "Notting Hill Gate", 8, "Central", null);
            adjacencyList[45].Next = queensway;
            adjacencyList[46] = new WeightedEdge("Regents Park", "Baker Street", 10, "Bakerloo", null);
            WeightedEdge regentspark = new WeightedEdge("Regents Park", "Oxford Circus", 15, "Bakerloo", null);
            adjacencyList[46].Next = regentspark;
            adjacencyList[47] = new WeightedEdge("Russell Square", "Holborn", 9, "Piccadilly", null);
            WeightedEdge russellsquare = new WeightedEdge("Russell Square", "Kings Cross St Pancras", 14, "Piccadilly", null);
            adjacencyList[47].Next = russellsquare;
            adjacencyList[48] = new WeightedEdge("Sloane Square", "Victoria", 13, "District", null);
            WeightedEdge sloanesquare = new WeightedEdge("Sloane Square", "South Kensington", 17, "District", null);
            adjacencyList[48].Next = sloanesquare;
            adjacencyList[49] = new WeightedEdge("South Kensington", "Sloane Square", 17, "District", null);
            WeightedEdge southkensinton = new WeightedEdge("South Kensington", "Gloucester Road", 8, "District", null);
            adjacencyList[49].Next = southkensinton;
            WeightedEdge southkensington2 = new WeightedEdge("South Kensington", "Knightsbridge", 17, "Piccadilly", null);
            southkensinton.Next = southkensington2;
            adjacencyList[50] = new WeightedEdge("Southwark", "London Bridge", 19, "Jubilee", null);
            WeightedEdge southwark = new WeightedEdge("Southwark", "Waterloo", 8, "Jubilee", null);
            adjacencyList[50].Next = southwark;
            adjacencyList[51] = new WeightedEdge("St James Park", "Westminster", 11, "District", null);
            WeightedEdge stjamespark = new WeightedEdge("St James Park", "Victoria", 11, "District", null);
            adjacencyList[51].Next = stjamespark;
            adjacencyList[52] = new WeightedEdge("St Pauls", "Bank", 9, "Central", null);
            WeightedEdge stpauls = new WeightedEdge("St Pauls", "Chancery Lane", 14, "Central", null);
            adjacencyList[52].Next = stpauls;
            adjacencyList[53] = new WeightedEdge("Temple", "Blackfriars", 10, "District", null);
            WeightedEdge temple = new WeightedEdge("Temple", "Embankment", 9, "District", null);
            adjacencyList[53].Next = temple;
            adjacencyList[54] = new WeightedEdge("Tottenham Court Road", "Holborn", 10, "Central", null);
            WeightedEdge tottenhamcourtroad = new WeightedEdge("Tottenham Court Road", "Leicester Square", 8, "Northern", null);
            adjacencyList[54].Next = tottenhamcourtroad;
            WeightedEdge tottenhamcourtroad2 = new WeightedEdge("Tottenham Court Road", "Oxford Circus", 9, "Central", null);
            tottenhamcourtroad.Next = tottenhamcourtroad2;
            WeightedEdge tottenhamcourtroad3 = new WeightedEdge("Tottenham Court Road", "Goodge Street", 7, "Northern", null);
            tottenhamcourtroad2.Next = tottenhamcourtroad3;
            adjacencyList[55] = new WeightedEdge("Tower Hill", "Aldgate", 9, "Circle", null);
            WeightedEdge towerhill = new WeightedEdge("Tower Hill", "Aldgate East", 10, "District", null);
            adjacencyList[55].Next = towerhill;
            WeightedEdge towerhill2 = new WeightedEdge("Tower Hill", "Monument", 10, "District", null);
            towerhill.Next = towerhill2;
            adjacencyList[56] = new WeightedEdge("Victoria", "St James Park", 11, "District", null);
            WeightedEdge victoria = new WeightedEdge("Victoria", "Pimlico", 12, "Victoria", null);
            adjacencyList[56].Next = victoria;
            WeightedEdge victoria2 = new WeightedEdge("Victoria", "Sloane Square", 13, "District", null);
            victoria.Next = victoria2;
            WeightedEdge victoria3 = new WeightedEdge("Victoria", "Green Park", 19, "Victoria", null);
            victoria2.Next = victoria3;
            adjacencyList[57] = new WeightedEdge("Warren Street", "Goodge Street", 7, "Northern", null);
            WeightedEdge warrenstreet = new WeightedEdge("Warren Street", "Oxford Circus", 18, "Victoria", null);
            adjacencyList[57].Next = warrenstreet;
            WeightedEdge warrenstreet2 = new WeightedEdge("Warren Street", "Euston", 9, "Victoria", null);
            warrenstreet.Next = warrenstreet2;
            adjacencyList[58] = new WeightedEdge("Waterloo", "Embankment", 6, "Bakerloo", null);
            WeightedEdge waterloo = new WeightedEdge("Waterloo", "Southwark", 8, "Jubilee", null);
            adjacencyList[58].Next = waterloo;
            WeightedEdge waterloo2 = new WeightedEdge("Waterloo", "Bank", 33, "Waterloo & City", null);
            waterloo.Next = waterloo2;
            WeightedEdge waterloo3 = new WeightedEdge("Waterloo", "Lambeth North", 9, "Bakerloo", null);
            waterloo2.Next = waterloo3;
            WeightedEdge waterloo4 = new WeightedEdge("Waterloo", "Westminster", 17, "Jubilee", null);
            waterloo3.Next = waterloo4;
            adjacencyList[59] = new WeightedEdge("Westminster", "Embankment", 10, "District", null);
            WeightedEdge westminster = new WeightedEdge("Westminster", "Waterloo", 17, "Jubilee", null);
            adjacencyList[59].Next = westminster;
            WeightedEdge westminster2 = new WeightedEdge("Westminster", "St James Park", 11, "District", null);
            westminster.Next = westminster2;
            WeightedEdge westminster3 = new WeightedEdge("Westminster", "Green Park", 21, "Jubilee", null);
            westminster2.Next = westminster3;
            adjacencyList[60] = new WeightedEdge("Aldgate East", "Tower Hill", 10, "District", null);
            WeightedEdge aldgateeast = new WeightedEdge("Aldgate East", "Liverpool Street", 11, "Waterloo", null);
            adjacencyList[60].Next = aldgateeast;
            adjacencyList[61] = new WeightedEdge("Holland Park", "Notting Hill Gate", 10, "Central", null);
            adjacencyList[62] = new WeightedEdge("Vauxhall", "Pimlico", 18, "Victoria", null);

        } // end of generate Adjacency list
            
    }
            
}
