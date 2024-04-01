namespace Messages
{
    public class Message
    {
        public string username { get; set; }
        public string text { get; set; }

        public Message(string name, string message) 
        { 
            username = name;
            text = message;
        }
    }
}
