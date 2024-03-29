public class Activity 
{
    protected string _name; 
    protected string _description;
    protected int _duration;

    public Activity (string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage ()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for you session? ");

        _duration = int.Parse(Console.ReadLine());
            
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine("\n");
        
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!! \n\nYou have completed another {_duration} seconds of the {_name}.");
        Thread.Sleep(1000);

        ShowSpinner(10);

    }

    public void ShowSpinner (int seconds)
    {
        List<string> animationStrings = new List<string>()
        {
            "|", "/", "-", "\\", "|", "/", "-", "\\"
        };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i> 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }       
    }

}