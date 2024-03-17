using System.Text;
using System.Linq;

public class Scripture 
{
    private Reference _reference; 
    private List<Word> _words;

    public Scripture(Reference reference, string text) 
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordsList = text.Split(new char[] { ' ', '.', ',', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string word in wordsList)
        {
            Word wordClass = new Word(word);
            _words.Add(wordClass);
        }
    }

    public void HideRandomWords (int numberToHide)
    {
        Random random = new Random();
        HashSet<int> randomNumbers = new HashSet<int>();

        while (randomNumbers.Count < numberToHide)
        {
            int randomNumber = random.Next(_words.Count());
            if (!_words[randomNumber].IsHidden())
            {
                randomNumbers.Add(randomNumber);
            }
        }

        foreach (int number in randomNumbers)
        {
            _words[number].Hide();
        }
    }

    public string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        foreach (Word word in _words)
        {
            builder.Append(word.GetDisplayText());
            builder.Append(" ");
        }

        return $"{_reference.GetDisplayText()} {builder.ToString().Trim()}";
    }

    public bool IsCompletelyHidden ()
    {
        return _words.All(word => word.IsHidden());
    }
}