public class Journal 
{
    List<Entry> _entries;

    
    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll ()
    {
        foreach (Entry entry in _entries) 
        {
            entry.Display();
            Console.WriteLine("");
        }
    }

    public void SaveToFile (string file)
    {
        string fileName = file;

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date {entry._date} - Prompt: {entry._promptText}\n{entry._entryText}\n");
            }
        }
    }

    public void LoadFromFile (string file)
    {
        string filename = file;
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}