using System.Text;

namespace Users
{
    public class UsersRepository
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>();
        public UsersRepository()
        {
            InitializeUsers();
        }

        public bool Authorize(string login, string password)
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password))
                return false;

            if (users.ContainsKey(login))
            {
                if (users[login] != password)
                    return false;
            }
            else AddUser(login, password);

            return true; 
        }

        private void AddUser(string login, string password)
        {
            users.Add(login, password);

            StreamWriter fileWriter = new StreamWriter("Users/users.txt");
            foreach (var user in users)
                fileWriter.WriteLine("{0};;{1}", user.Key, user.Value);

            fileWriter.Close();
            fileWriter.Dispose();
        }

        private void InitializeUsers()
        {
            StreamReader fileReader = new StreamReader("Users/users.txt", Encoding.UTF8);
            while(true)
            {
                var dataLine = fileReader.ReadLine();
                if (dataLine == null)
                    break;

                var pair = dataLine.Split(";;");
                if (pair.Length != 2)
                    break;

                users.Add(pair[0], pair[1]);
            }

            fileReader.Close();
            fileReader.Dispose();
        }

    }
}
