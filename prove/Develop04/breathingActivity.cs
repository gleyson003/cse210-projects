public class BreathingActivity : Activity
{
    public BreathingActivity (string name, string description, int duration) : base(name, description, duration)
    {
    }
    
    public void Run ()
    {   
        DisplayStartingMessage();

        int activityDuration = _duration;
        
        while (activityDuration > 0)
        {
            Console.Write($"Breathe in...");

           ShowCountDown(4);

            Console.Write($"\nNow breathe out...");

            ShowCountDown(6);

            activityDuration -= 10;

            Console.WriteLine("\n");
        }

        DisplayEndingMessage();      
    }
}