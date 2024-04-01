using Microsoft.AspNetCore.SignalR;
using Users;
using Messages;

namespace SignalRApp
{
    public class ChatHub : Hub
    {
        private readonly UsersRepository usersRepository;
        private readonly MessagesRepository messagesRepository;

        public ChatHub() 
        {
            usersRepository = new UsersRepository();
            messagesRepository = new MessagesRepository();
        }

        public Task<bool> Authorize(string login, string password)
        {
            return Task.FromResult(usersRepository.Authorize(login, password));
        }

        public Task<List<Message>> InitializeMessages()
        {
            return Task.FromResult(messagesRepository.GetAllMessages());
        }

        public async Task Send(string username, string message)
        {
            messagesRepository.AddMessage(username, message);
            await this.Clients.All.SendAsync("Receive", username, message);
        }

        
    }
}