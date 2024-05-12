using System;
using System.ServiceModel;

namespace Wcf.Server
{
    internal class Program
    {
        [ServiceContract]
        public interface IMessageService
        {
            [OperationContract]
            string[] GetMessages(string nickname);
        }

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class MessageService : IMessageService
        {
            public string[] GetMessages(string nickname)
            {
                Console.WriteLine($"GetMessages called by {nickname}");
                return new string[] { "Hello", "World" };
            }
        }

        private static void Main(string[] args)
        {
            var uris = new Uri[1];
            string address = "net.tcp://localhost:8080/MessageService";
            uris[0] = new Uri(address);
            IMessageService message = new MessageService();
            ServiceHost host = new ServiceHost(message, new Uri(address));
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IMessageService), binding, address);
            host.Opened += (sender, eventArgs) => Console.WriteLine("Service is running");
            host.Open();
            Console.ReadLine();
        }
    }
}