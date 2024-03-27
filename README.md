// May 2023
// Nick Harding w19249722 UoW DSaA Group Courswork 7SENG010W_CW
// Testing and benchmarking program for three different versions of Dijkstra's Shortest Path Algo

Introduction 

The brief for this project was to develop three versions of software that find the fastest walking route between London Underground train stations in Zone 1, as shown on the ‘Walking times between stations on the same line’ map provided by Transport For London (TFL, 2020). 
Versions 1 & 2 are to implement only hand coded software, using only the basic ‘built-in’ data types and classes available in C#. Version 1 will use an adjacency matrix approach to represent the tube network, and version 2 an adjacency list. Version 3 is to replace the use of hand coded software data structures/algorithms with software available as part of the .NET Framework Libraries.
A testing and benchmarking program is to also be developed, to run a series of tests on each of the versions and record and output the results in the form of tables. The testing software is to perform consistency and benchmarking tests. The results of these tests will be used to compare and analyse the data structures and algorithms used in each version.

team Members

-Samuel Jones
Design and implement Version 1 (hand coded without .NET) a console based application to calculate the shortest walking path between underground stations using an adjacency matrix approach.
-Laurence Kember
Design and implement Version 2 of the application (also hand coded without .NET) but used an adjacency list approach. 
-Alperen Safi
Design and implement Version 3 of the application using software available as part of the .NET Framework Libraries. 
-Nicholas Harding
Design and build a testing and benchmarking program to run a series of different tests on each of the applications.
All group members shared the elements of their project with the team on a shared drive as they developed. It was everyone’s role to review, support, and give feedback when issues arose. The main project deliverables were contributed to by all members

Conclusion

Dijkstra’s Shortest Path algorithm was chosen by the group as it finds the shortest path from any specified vertex to any other vertex, and all the other vertices in the graph. The problem presented, calculating the shortest path of walking routes between underground stations, can be modelled as such. Dijkstra’s algorithm works only for connected graphs. It can only provide the value or cost of the shortest paths found and works for both directed and undirected graphs (the problem in this instance being an undirected weighted graph). These properties make it a suitable choice of algorithm for these applications.
Were the data set to be extended beyond zone 1, it could be expected that the relative inefficiency of the adjacency matrix compared to the adjacency list versions would increase, given that zone 1 is the most densely populated region of the map. It might also be expected that the superior performance of version 2 over version 3 for longer routes could potentially come into its own in such a scenario. 
On the other hand, were the task to be extended to a more sophisticated walking route calculator, for example by using the full set of pedestrian routes available in central London, the edge to vertex ratio might be expected to increase; were that to be the case, the gap between version 1 and the adjacency list versions might be expected to narrow somewhat; although it would remain to be seen whether an adjacency matrix structure would ever be the a preferable choice for modelling a scenario such as this, where for example direct links between distant vertices would presumably be exceptionally rare.
In either case, as the size of the graph in question increased, assuming no corresponding increase in graph density, the relative impact of the adjacency matrix vs list factor in the efficiency of the algorithm would increase for a given typical journey, and an extension of this coursework might examine the relative performance of the three versions with a variety of graph sizes and densities. 
All told, it can be seen how the complexity and consequent performance of a given algorithm and its implementation is something which should be given thought as choices are made in the initial conception and design stage, and not merely as a diverting afterthought once the software is complete and ready for testing.
Finally, a more sophisticated version of the TfL walking times map itself can be conceived of, where variations in walking time in different directions along the same graph edge are taken into account. (For example, anyone who has attempted the steeply uphill walk from King’s Cross to Angel will understand that this is unlikely in practice to have the same duration as the reverse journey for all but the most vigorous of walkers.) Modelling this scenario would require a directed graph, rather than the undirected graph used in this task, and an overhaul of the data set used; the routes generated might well be expected to turn up some potentially enlightening results for London pedestrians.
