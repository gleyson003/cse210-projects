public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal (string name, string description, int points) : base(name, description, points)
    {

    }

    public override void  RecordEvent()
    {
        _isComplete = true;

        Console.WriteLine($"Congratulations! You have earned {_points} points!");
    }

    public override bool IsComplete()
    {
        if (_isComplete)
        {
            return true;
        }
        else
        {
            return false;
        }       
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_isComplete}";
    }
    
}