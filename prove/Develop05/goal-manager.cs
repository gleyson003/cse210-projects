public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    
    public GoalManager ()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int userChoice = 0;

        do
        {
            Console.WriteLine($"You have {_score} points\n");
            Console.WriteLine($"Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            //I added a validator to the user input
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 6)
            {
                Console.WriteLine("Invalid choice. Please select a valid option (1-6).");
                Console.Write("Select a choice from the menu: ");
            }

            switch (userChoice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    Console.WriteLine("\n");
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option (1-6).");
                    break;
            }

        } while (userChoice != 6);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You now have {_score} points.");
    }

    public void ListGoalNames()
    {
        int index = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{index}. {g.GetShortName()}");
            index++;
        }
    }

    public void ListGoalDetails()
    {
        int index = 1;
        foreach (Goal g in _goals)
        {
            if(g.IsComplete())
            {
                Console.WriteLine($"{index}. [X] {g.GetDetailsString()}");
                index++;
            }
            else
            {
                Console.WriteLine($"{index}. [] {g.GetDetailsString()}");
                index++;
            }
            
        }
    }

    public void CreateGoal()
    {
        int goalType = 0;
        int goalPoints = 0;
        string goalName = "";
        string goalDescription = "";
        bool isValidGoalType = false;

        //I added a validator to the user input
        while (!isValidGoalType)
        {
            Console.WriteLine($"\nThe types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");

            if (int.TryParse(Console.ReadLine(), out goalType))
            {
                if (goalType >= 1 && goalType <= 3)
                {
                    isValidGoalType = true;
                }
                else
                {
                    Console.WriteLine("Invalid goal type. Please enter a valid type (1, 2, or 3).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer (1, 2, or 3).");
            }
        }

        Console.Write("What is the name of your goal? ");
        goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        goalPoints = int.Parse(Console.ReadLine());

        bool userIncorrectValue = true;
        while (userIncorrectValue)
        {
            if(goalType == 1)
            {
                SimpleGoal goal = new SimpleGoal(goalName, goalDescription, goalPoints);
                _goals.Add(goal);
                userIncorrectValue = false;
            } 
            else if (goalType == 2)
            {
                EternalGoal goal = new EternalGoal(goalName, goalDescription, goalPoints);
                _goals.Add(goal);
                userIncorrectValue = false;
            }
            else if (goalType == 3) 
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal goal = new ChecklistGoal(goalName, goalDescription, goalPoints, target, bonus);
                _goals.Add(goal);
                userIncorrectValue = false;
            }
            else
            {
                Console.WriteLine("Invalid goal type. Please enter a valid type.");
                goalType = int.Parse(Console.ReadLine());
            }
        }

        Console.Clear();       
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int goalAccomplish = int.Parse(Console.ReadLine());

        int goalIndex = goalAccomplish - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal accomplishedGoal = _goals[goalIndex];

            accomplishedGoal.RecordEvent();

            int accomplishGoalPoints = accomplishedGoal.GetPoints();
            _score += accomplishGoalPoints;        
        }
        DisplayPlayerInfo();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"Score: {_score}");

            foreach (Goal g in _goals)
            {
                outputFile.Write($"{g}:");
                outputFile.WriteLine($"{g.GetStringRepresentation()}");
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            if (line.StartsWith("Score:"))
            {
                _score = int.Parse(line.Substring(6));
            }
            else
            {
                string[] parts = line.Split(':');
                string type = parts[0].Trim();
                string data = parts[1].Trim();

                if (type == "SimpleGoal")
                {
                    string[] goalData = data.Split(',');
                    string name = goalData[0].Trim();
                    string description = goalData[1].Trim();
                    int points = int.Parse(goalData[2].Trim());
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    string[] goalData = data.Split(',');
                    string name = goalData[0].Trim();
                    string description = goalData[1].Trim();
                    int points = int.Parse(goalData[2].Trim());
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (type == "ChecklistGoal")
                {
                    string[] goalData = data.Split(',');
                    string name = goalData[0].Trim();
                    string description = goalData[1].Trim();
                    int points = int.Parse(goalData[2].Trim());
                    int target = int.Parse(goalData[3].Trim());
                    int bonus = int.Parse(goalData[4].Trim());
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    _goals.Add(goal);
                }
            }
        }
    }
}