using System.Text;

namespace Messages
{
    public class MessagesRepository
    {
        private readonly List<Message> messages = new List<Message>();
        public MessagesRepository()
        {
            InitializeMessages();
        }

        public void AddMessage(string username, string message)
        {
            messages.Add(new Message(username, message));

            StreamWriter fileWriter = new StreamWriter("Messages/messages.txt");
            foreach (var mess in messages)
                fileWriter.WriteLine("{0};;{1}", mess.username, mess.text);

            fileWriter.Close();
            fileWriter.Dispose();
        }

        public List<Message> GetAllMessages()
        {
            return messages;
        }

        private void InitializeMessages()
        {
            StreamReader fileReader = new StreamReader("Messages/messages.txt", Encoding.UTF8);
            while(true)
            {
                var dataLine = fileReader.ReadLine();
                if (dataLine == null)
                    break;

                var pair = dataLine.Split(";;");
                if (pair.Length != 2)
                    break;

                messages.Add(new Message(pair[0], pair[1]));
            }

            fileReader.Close();
            fileReader.Dispose();
        }

    }
}
