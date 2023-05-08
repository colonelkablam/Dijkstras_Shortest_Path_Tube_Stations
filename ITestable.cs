namespace Testing
{
    public interface ITestable
    {
        // name needed to display version being tested
        public int VersionNumber { get; }    

        // main function to return a result needed
        public JourneyLinkedList CalcualteShortestPath(string start, string end);

    }
}
