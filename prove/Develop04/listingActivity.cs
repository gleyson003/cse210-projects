public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };


    public ListingActivity(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage ();

        Console.WriteLine("List as many responses you can to the following prompt: ");
        Console.WriteLine($"\n---{GetRandomPrompt()}---\n");

        GetListFromUser();
        
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string randomPrompt = _prompts[random.Next(_prompts.Count)];

        return randomPrompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("You may begin:");
        ShowCountDown(5);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {   
                Console.Write("> ");
                string response = Console.ReadLine();
                responses.Add(response);
            }
        }

        return responses;     
    }
}