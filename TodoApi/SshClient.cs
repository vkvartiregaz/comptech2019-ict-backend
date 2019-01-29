using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi
{
    public class SshClient
    {
        readonly ConnectionInfo ConnectionInfo;
        private readonly Renci.SshNet.SshClient Ssh;
        
        public SshClient(string ServerName, int Port, string Charset, string Name, string Password)
        {
            ConnectionInfo = new ConnectionInfo(ServerName, Port, Name,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(Name, Password)
                    /*,new PrivateKeyAuthenticationMethod(rsaKey)*/
                });
            Ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }

        public void Connect()
        {
            Ssh.Connect(); // эта штука кидается исключениями
        }
        
        public string ThrowCommand(string Command)
        {
            return Ssh.CreateCommand(Command).Execute(); // эта штука тоже кидается исключениями
        }

        public void Disconnect()
        {
            if(Ssh.IsConnected)
                Ssh.Disconnect();
        }
    }   
}
