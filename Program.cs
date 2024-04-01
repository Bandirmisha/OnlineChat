using SignalRApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear(); 
options.DefaultFileNames.Add("chat.html"); 
app.UseDefaultFiles(options); 

app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");
app.Run();