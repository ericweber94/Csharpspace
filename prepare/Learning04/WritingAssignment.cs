public class WritingAssignment : Assignment
{
    private string title1;
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        title1 = title;
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return $"{title1} by {studentName}";
    }
}