using System;
using System.ServiceModel;

namespace Wcf.Client
{
    internal class Program
    {
        [ServiceContract]
        public interface IMessageService
        {
            [OperationContract]
            string[] GetMessages(string nickname);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to call the service");
            Console.ReadLine();
            var address = "net.tcp://localhost:8080/MessageService";
            var binding = new NetTcpBinding(SecurityMode.None);
            var factory = new ChannelFactory<IMessageService>(binding, address);
            var channel = factory.CreateChannel();
            var messages = channel.GetMessages("Mysttic");
            foreach (var m in messages)
            {
                Console.WriteLine(m);
            }
            Console.ReadLine();
        }
    }
}