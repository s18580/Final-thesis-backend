namespace Application.Tests.TestData
{
    public class AssignmentTestData
    {
        public static AssignmentData GetAssignment()
        {
            return new AssignmentData("Main Admin", true);
        }
    }

    public struct AssignmentData
    {
        public string Name { get; set; }
        public bool IsLeader { get; set; }

        public AssignmentData(string name, bool isLeader)
        {
            Name = name;
            IsLeader = isLeader;
        }
    }
}
