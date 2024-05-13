using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingServiceHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HelloRemotingService.HelloRemotingService remotingService = new HelloRemotingService.HelloRemotingService();
            TcpChannel tcpChannel = new TcpChannel(8085);
            ChannelServices.RegisterChannel(tcpChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(HelloRemotingService.HelloRemotingService), "GetMessage", WellKnownObjectMode.Singleton);
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}