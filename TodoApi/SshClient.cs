using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi
{
    public static class SshClient
    {
        public static ConnectionInfo ConnectionInfo;
        private static Renci.SshNet.SshClient ssh = null;

        public static Encoding encoding = Encoding.UTF8;
        

        public static void SetConnectionInfo(string serverName, int port, Encoding encoding, string name, string password)
        {
            SshClient.encoding = encoding;
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(name, password)
                });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }
        public static void SetConnectionInfo(string serverName, int port, string name, string password)
        {
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(name, password)
                });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }

        public static void SetConnectionInfo(string serverName, int port, Encoding encoding, string name, PrivateKeyFile KeyFiles)
        {
            SshClient.encoding = encoding;
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PrivateKeyAuthenticationMethod(name, KeyFiles)
                    });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }
        public static void SetConnectionInfo(string serverName, int port, string name, PrivateKeyFile KeyFiles)
        {
            ConnectionInfo = new ConnectionInfo(serverName, port, name,
                new AuthenticationMethod[]{
                    new PrivateKeyAuthenticationMethod(name, KeyFiles)
                    });
            ssh = new Renci.SshNet.SshClient(ConnectionInfo);
        }

        public static void Connect()
        {
            if (ssh.IsConnected == false)
            {
                ssh.Connect(); // эта штука кидается исключениями
            }
        }
        
        public static SshCommand GetCommand(string Command)
        {
            try
            {
                if (ssh.IsConnected == true)
                {
                    return ssh.CreateCommand(Command, encoding);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            throw new Exception("No connected SSH");
        }

        public static string ThrowCommand(string Command)
        {
            try
            {
                if (ssh.IsConnected == true)
                {
                    return ssh.CreateCommand(Command, encoding).Execute(); // эта штука тоже кидается исключениями
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "No SSH connection";
        }

        public static string Disconnect()
        {
            if (ssh.IsConnected)
            {
                ssh.Disconnect();
                return "Disconnected";
            }
            return "No connection";
        }
    }
}
