using System.Security.Cryptography.X509Certificates;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal (string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void  RecordEvent()
    {
        _amountCompleted += 1;
        
        bool completed = IsComplete();
        
        if (completed == true)
        {
            _points += _bonus;
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
        }
    }

    public override bool IsComplete()
    {
        if (_amountCompleted < _target)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
    
    public int GetBonus()
    {
        return _bonus;
    }
}