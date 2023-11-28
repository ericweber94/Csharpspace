public class Assignment
{
    private string studentName1;
    private string topic1;

    public Assignment(string studentName, string topic)
    {
        studentName1 = studentName;
        topic1 = topic;
    }
    public string GetStudentName()
    {
        return studentName1;
    }
    public string GetTopic()
    {
        return topic1;
    }
    public string GetSummary()
    {
        return studentName1 + " - " + topic1;
    }
}