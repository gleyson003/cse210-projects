using System.Text.RegularExpressions;

public class Word 
{
    private string _text;
    private bool _isHidden;

    public Word(string text) 
    {
        _text = text;
    }

    public void Hide ()
    {
        string underscoredWord = new string('_', _text.Length);
        _text = underscoredWord;
        _isHidden = true;
    }

    public void Show ()
    {
        _text = _text;
    }

    public bool IsHidden ()
    {
        foreach (char c in _text)
        {
            if (c != '_')
            {
                return false;
            }
        }
        
        return true;
    }

    public string GetDisplayText ()
    {
        return _text;
    }
}