using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WcfServiceForBackupProtocolFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://172.20.254.120/WcfServiceForBackupProtocolFiles:80");
            using (ServiceHost host = new ServiceHost(typeof(FileService), baseAddress))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                host.Open();

                Timer timer = new Timer(1000 * 60 * 30);
                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer.Enabled = true;

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("StartedTime: {0}", DateTime.Now);
                Console.WriteLine("Don't press <Enter>");
                Console.ReadLine();

                host.Close();

                void OnTimedEvent(object source, ElapsedEventArgs e)
                {
                    Console.WriteLine("now " + DateTime.Now);
                    TimerHolder.Counter++;
                    if (TimerHolder.Counter == 3)
                    {
                        host.Close();
                        Environment.Exit(0);
                    }
                }
            }
        }
        
    }

    public static class TimerHolder
    {
        public static int Counter = 0;
    }
}
