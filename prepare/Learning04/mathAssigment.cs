public class MathAssigment : Assignment
{
    private string _textbook;
    private string _problems;

    public MathAssigment (string studentName, string topic, string textbook, string problems) : base (studentName, topic)
    {
        _textbook = textbook;
        _problems = problems;
    }

    public string GetHomeworkList ()
    {
        return $"Section {_textbook} Problems {_problems}";
    }
}