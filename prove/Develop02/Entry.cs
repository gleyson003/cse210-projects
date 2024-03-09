public class Entry
{
    public string _entryText;
    public string _promptText;
    public string _date;

    public void Display ()
    {
        Console.WriteLine($"Date {_date} - Prompt: {_promptText}\n{_entryText}");
    }
}