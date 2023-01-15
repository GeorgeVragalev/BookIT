namespace Backend.Models;

public class MessageStructure
{
    public string Title { get; set; }
    public string BodyMessage { get; set; }
    public string ButtonTitle { get; set; }

    public MessageStructure()
    {
        Title = "";
        BodyMessage = "";
        ButtonTitle = "";
    }

    public MessageStructure(string title, string bodyMessage, string buttonTitle)
    {
        Title = title;
        BodyMessage = bodyMessage;
        ButtonTitle = buttonTitle;
    }
}