# server_client
 In this project, server and client were created with C#.
When working with TCP sockets (client and server), we can use the .NET library that will make our work easier.  

NuGet Package: https://www.nuget.org/packages/SimpleTCP/    
  
A TCP client is set to port 8910 connecting to 127.0.0.1.  
You can refer to the image below for the form screen of the server project.  

  
  ![image](https://user-images.githubusercontent.com/101124940/160110392-256d78bb-d931-40fd-9711-bd3476df7960.png)  
        
    
    
  You can refer to the image below for the form screen of the client project.  
  ![image](https://user-images.githubusercontent.com/101124940/160110465-dfb929a8-fe02-4718-9bb3-848d26e0e188.png)  
   
   

  
      //This code is used to receive a message event on the server each time you see a new line \n (character 13) and to repeat incoming messages.  
       private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTCP.SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Clear();
                txtStatus.Text += e.MessageString;
                e.ReplyLine(string.Format("{0}", e.MessageString));
            });
            
         }


