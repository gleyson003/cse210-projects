public class ReflectingActivity : Activity
{
    private List<string> _quetions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string randomPrompt = _prompts[random.Next(_prompts.Count)];

        return randomPrompt;
    }

    public void DisplayPrompt()
    {
        string showPrompt = GetRandomPrompt();

        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine($"\n---{showPrompt}---\n");

        Console.WriteLine($"When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
    }

    public List<string> GetRandomQuestion()
    {
        List<string> randomQuestions = new List<string>();

        Random random = new Random();
        int index1 = random.Next(_quetions.Count);
        int index2;
        do
        {
            index2 = random.Next(_quetions.Count);
        } while (index2 == index1);

        randomQuestions.Add(_quetions[index1]);
        randomQuestions.Add(_quetions[index2]);

        return randomQuestions;
    }

    private void DisplayQuestions()
    {
        Console.Clear();
        List<string> getQuestions = GetRandomQuestion();

        Console.Write($"> {getQuestions[0]} ");
        ShowSpinner(_duration / 2);

        Console.Write($"\n> {getQuestions[1]} ");
        ShowSpinner(_duration / 2);
        Console.WriteLine("\n");
    }
}

