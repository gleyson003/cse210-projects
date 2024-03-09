public class PromptGenerator
{
    public List<string> _prompts;

    public string GetRandomPrompt ()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }
}