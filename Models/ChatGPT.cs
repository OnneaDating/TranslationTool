namespace OnneaRE.Models;
public class ChatGPT
{
    public string id { get; set; }
    public string @object { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public List<Choice> choices { get; set; } = new List<Choice>();
    public Usage usage { get; set; } = new Usage();
}
