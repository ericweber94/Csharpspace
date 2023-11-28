public class MathAssignment : Assignment
{
    private string textbookSection1;
    private string problems1;
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        textbookSection1 = textbookSection;
        problems1 = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {textbookSection1} Problems {problems1}";
    }
}