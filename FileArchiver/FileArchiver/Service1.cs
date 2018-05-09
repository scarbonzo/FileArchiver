using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileArchiver
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer m_mainTimer;
        int scanInterval = 60 * 60000; //How often to scan the devices in milliseconds (minutes * 60000)

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Create the Main timer
            m_mainTimer = new System.Timers.Timer
            {
                Interval = scanInterval
            };
            m_mainTimer.Elapsed += m_mainTimer_Elapsed;
            m_mainTimer.AutoReset = true;
#if DEBUG
            Scan(); //Run Scan Manually
#else
            m_mainTimer.Start(); //Start timer only in Release
#endif           
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            m_mainTimer.Stop();
        }

        static void m_mainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Scan();
        }

        static void Scan()
        {
            Console.WriteLine("Staring Scan...");

            Console.WriteLine("Finished Scaning...");
        }
    }
}
