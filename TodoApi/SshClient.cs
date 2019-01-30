using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi
{
    public class SshClient
    {
        readonly ConnectionInfo ConnectionInfo;
        private readonly Renci.SshNet.SshClient ssh;

        public Encoding encoding = Encoding.UTF8;
        

        public SshClient( string serverName, int port, Encoding encoding, string name, string password)
        {
            this.encoding = encoding;
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(name, password)
                });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }
        public SshClient(string serverName, int port, string name, string password)
        {
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(name, password)
                });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }

        public SshClient(string serverName, int port, Encoding encoding, string name, PrivateKeyFile KeyFiles)
        {
            this.encoding = encoding;
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PrivateKeyAuthenticationMethod(name, KeyFiles)
                    });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }
        public SshClient(string serverName, int port, string name, PrivateKeyFile KeyFiles)
        {
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PrivateKeyAuthenticationMethod(name, KeyFiles)
                    });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }

        public void Connect()
        {
            if (ssh.IsConnected == false)
            {
                ssh.Connect(); // эта штука кидается исключениями
            }
        }
        
        public SshCommand GetCommand(string Command)
        {
            if (ssh.IsConnected == true)
            {
                return ssh.CreateCommand(Command, encoding);
            }
            throw new Exception("No connected SSH");
        }

        public string ThrowCommand(string Command)
        {
            if (ssh.IsConnected == true)
            {
                return ssh.CreateCommand(Command, encoding).Execute(); // эта штука тоже кидается исключениями
            }
            return "No SSH connection";
        }

        public void Disconnect()
        {
            if (ssh.IsConnected)
            {
                ssh.Disconnect();
            }
        }
    }   
}
